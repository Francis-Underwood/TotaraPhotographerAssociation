using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using TotaraPhotographyAssociation.Models;

namespace TotaraPhotographyAssociation.Controllers
{
    public class HomeController : Controller
    {
        // Vincent: Entity Framework's database context
        private TotaraPhotoEntities dbCnxt = new TotaraPhotoEntities();

        public ActionResult Index()
        {
            return View();
        }

        // Vincent: grab the HTML for about us from DB, display it
        public ActionResult About()
        {
            string about = (from p in this.dbCnxt.SysParams
                            where p.ParaName == "about"
                            select p.ParaVal).FirstOrDefault();
            ViewBag.Message = about;
            return View();
        }

        // Vincent: only administrator and full member can update the 'About Us' page
        [Authorize(Roles = "full, admin")]     
        public ActionResult EditAbout()
        {
            string about = (from p in this.dbCnxt.SysParams
                            where p.ParaName == "about"
                            select p.ParaVal).FirstOrDefault();
            EditAboutUsFormViewModel model = new EditAboutUsFormViewModel() { AboutUs = about };
            return View(model);
        }

        // Vincent: only administrator and full member can update the 'About Us' page
        [Authorize(Roles = "full, admin")]
        [HttpPost]
       // [AllowHtml]
        public ActionResult UpdateAbout(EditAboutUsFormViewModel model)    // Vincent: to apply [AllowHtml], it has to be a model class
        {
            SysParam about = (from p in this.dbCnxt.SysParams
                            where p.ParaName == "about"
                            select p).FirstOrDefault();
            about.ParaVal = model.AboutUs;
            // Vincent: update the data into database
            this.dbCnxt.SaveChanges();  // TODO: some validation need to be done, to stripe <script>, to avoid XSS attack
            return View("EditAbout", model);
        }


    }
}