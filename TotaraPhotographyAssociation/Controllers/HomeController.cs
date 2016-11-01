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
        private TotaraPhotoEntities dbCnxt = new TotaraPhotoEntities();

        public ActionResult Index()
        {
            return View();
        }

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
            //ViewBag.Message = about;
            return View(model);
        }

        // Vincent: only administrator and full member can update the 'About Us' page
        [Authorize(Roles = "full, admin")]
        [HttpPost]
       // [AllowHtml]
        public ActionResult UpdateAbout(EditAboutUsFormViewModel model)
        {
            SysParam about = (from p in this.dbCnxt.SysParams
                            where p.ParaName == "about"
                            select p).FirstOrDefault();
            about.ParaVal = model.AboutUs;

            this.dbCnxt.SaveChanges();

            //ViewBag.Message = about.ParaVal;
            return View("EditAbout", model);
        }


    }
}