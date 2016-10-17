using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using PayPal.Api;
using TotaraPhotographyAssociation.Models;
using TotaraPhotographyAssociation.DomainEntities;
using TotaraPhotographyAssociation.Services;

namespace TotaraPhotographyAssociation.Controllers
{
    public class OrderController : Controller
    {
        private TotaraPhotoEntities dbCnxt = new TotaraPhotoEntities();
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(Cart cart)
        {
            return View();
        }

        /**/
        [HttpPost]
        public ActionResult Create(Cart cart, CreateOrderViewModel vmodel)
        {
            if (ModelState.IsValid)
            {
                if (cart.Lines.Count() == 0)
                {
                    ModelState.AddModelError("CartLoaded", "There is no item in your cart.");
                    //return View(vmodel);
                }
                else
                {
                    // update database
                    // go to Paypal
                    PayPalPaymentService.cart = cart;
                    PayPalPaymentService.discount = 1-0.10m;
                    PayPalPaymentService.orderId = "XXXXXXX";
                    // pass discount

                    Payment payment = PayPalPaymentService.CreatePayment(GetBaseUrl(), "sale");
                }
            }

            return View(vmodel);
        }



        public ActionResult PaymentSuccessful(string paymentId, string token, string PayerID)
        {
            // Execute Payment
            //var payment = PayPalPaymentService.ExecutePayment(paymentId, PayerID);

            return View();
        }

        public ActionResult PaymentCancelled()
        {
            // TODO: Handle cancelled payment
            return RedirectToAction("Error");
        }


        public string GetBaseUrl()
        {
            HttpContext f =null;

            //Request.Url

           // HttpRequest r = f.Request;

           

            return Request.Url.Scheme + "://" + Request.Url.Host + ":" + Request.Url.Port.ToString();
        }




    }
}