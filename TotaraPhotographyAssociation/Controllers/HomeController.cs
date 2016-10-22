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


        public ActionResult EditAbout()
        {
            string about = (from p in this.dbCnxt.SysParams
                            where p.ParaName == "about"
                            select p.ParaVal).FirstOrDefault();
            ViewBag.Message = about;
            return View();
        }

        [HttpPost]
        public ActionResult UpdateAbout(string aboutus)
        {
            SysParam about = (from p in this.dbCnxt.SysParams
                            where p.ParaName == "about"
                            select p).FirstOrDefault();
            about.ParaVal = aboutus;

            this.dbCnxt.SaveChanges();

            ViewBag.Message = about.ParaVal;
            return View("EditAbout");
        }


    }
}