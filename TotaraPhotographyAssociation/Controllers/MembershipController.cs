using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PayPal.Api;
using TotaraPhotographyAssociation.Models;
using TotaraPhotographyAssociation.Services;

namespace TotaraPhotographyAssociation.Controllers
{
    public class MembershipController : Controller
    {
        private TotaraPhotoEntities dbCnxt = new TotaraPhotoEntities();

        // GET: MemberShip
        [Authorize(Roles = "full, associate, expired, inactive")]
        public ActionResult Index()
        {
            // Vincent: grab current user's id
            string currentUserId = User.Identity.GetUserId();

            // Vincent: get the role of the current user through EF6.0
            string role = (from r in this.dbCnxt.AspNetRoles
                           join ur in this.dbCnxt.AspNetUserRoles on r.Id equals ur.RoleId
                           where ur.UserId == currentUserId
                           select r.Name).FirstOrDefault();

            // Vincent: get the role of the current user
            DateTime? expiryDate = (from ur in this.dbCnxt.AspNetUserRoles
                                    where ur.UserId == currentUserId
                                    select ur.ExpiryDate).FirstOrDefault();

            MembershipViewModel model = new MembershipViewModel()
            {
                Role = role,
                ExpiryDate = expiryDate
            };

            return View(model);
        }

        

        [Authorize(Roles = "full, associate, expired, inactive")]
        public ActionResult Subscribe(string plan)
        {
            ViewBag.Plan = plan;
            return View();
        }



        [HttpPost]
        [Authorize(Roles = "full, associate, expired, inactive")]
        public ActionResult Subscribe(string plan, PurchaseMembershipViewModel vmodel)
        {
            bool isValid = true;

            // Vincent: store the plan user chose in session, for later
            Session["plan"] = plan;

            if (ModelState.IsValid)
            {
                // Vincent: set up paypal payment service
                if (plan == "associate")
                {
                    PPPSMembership.membershipFee = 15.00m;
                    PPPSMembership.planName = "Associate Membership Plan";
                    PPPSMembership.stockUId = "MEMSHP-01";
                }
                else if (plan == "full")
                {
                    PPPSMembership.membershipFee = 25.00m;
                    PPPSMembership.planName = "Full Membership Plan";
                    PPPSMembership.stockUId = "MEMSHP-02";
                }
                else
                {
                    ModelState.AddModelError("PlanLoaded", "The plan is not recognized.");
                }


                // Vincent: go to Paypal
                try
                {
                    Payment payment = PPPSMembership.CreatePayment(GetBaseUrl(), "sale");
                    return Redirect(payment.GetApprovalUrl());
                }
                catch (Exception ex)
                {
                    // log
                    // TODO: go to error
                }
            }

            return View();
        }
        

        [Authorize(Roles = "full, associate, expired, inactive")]
        public ActionResult PaymentSuccessful(string paymentId, string token, string PayerID)
        {
            // Execute Payment
            var payment = PPPSMembership.ExecutePayment(paymentId, PayerID);

            // Vincent: extract the plan info from session
            string membershipPlan = Session["plan"].ToString();
            ViewBag.MembershipPlan = membershipPlan;

            // Vincent: 
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            ApplicationUser u = userManager.FindByName(HttpContext.User.Identity.Name);

            ViewBag.UpdateRole = "no";

            // Vincent: update database
            IdentityResult result = null;

            result = userManager.RemoveFromRole(u.Id, "inactive");

            if (result.Succeeded)
            {
                result = userManager.AddToRole(u.Id, membershipPlan);
                if (result.Succeeded)
                {
                    // TODO: group them in a transaction
                    var ur = (from f in this.dbCnxt.AspNetUserRoles
                              where f.UserId == u.Id
                              select f).FirstOrDefault();
                    ur.ExpiryDate = DateTime.Now.AddYears(1);
                    this.dbCnxt.SaveChanges();

                    ViewBag.UpdateRole = "yes";
                }
                else
                {

                }
            }
            else
            {
                // error
            } 
            
            return View();
        }

        [Authorize(Roles = "full, associate, expired, inactive")]
        public ActionResult PaymentCancelled()
        {
            //return RedirectToAction("Error");
            return View();
        }


        public string ExpirizeMembership()
        {
            try
            {
                int res = this.dbCnxt.ExpirizeMembership();
                return "Success: " + res.ToString();
            }
            catch (Exception e)
            {
                return "Fail: " + e.Message;
            }
        } 

        // just compute the base url: localhost:44000
        private string GetBaseUrl()
        {
            return Request.Url.Scheme + "://" + Request.Url.Host + ":" + Request.Url.Port.ToString();
        }


    }
}