using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotaraPhotographyAssociation.Models;

namespace TotaraPhotographyAssociation.Controllers
{
    public class ResourceController : Controller
    {
        private TotaraPhotoEntities dbCnxt = new TotaraPhotoEntities();
        // GET: Resource
        //[Authorize(Roles = "full,associate")]
        public ActionResult Index()
        {
            List<Resource> queryRes = (from r in this.dbCnxt.Resources
                                       select r).ToList();


            return View(queryRes);
        }



        public FileResult DisplayPDF(int id)
        {
            Resource pdf = (from r in this.dbCnxt.Resources
                            where r.Id == id
                            select r).FirstOrDefault();

            if (pdf != null)
            {
                return File("/ResFiles/" + pdf.FileName, "application/pdf", pdf.FileName);
            }

            return null;
        }


        public ActionResult Badboy(string file)
        {
            ViewBag.File = file;
            return View();
        }


    }
}