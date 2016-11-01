using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using TotaraPhotographyAssociation;

namespace TotaraPhotographyAssociation.Controllers
{
    public class ImageUploaderController : Controller
    {
        // GET: ImageUploader
        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            string fileName;
            string fileExt = "";
            string savedFileName = "";

            string directory = Server.MapPath("~/App_Upload/");
            fileName = Path.GetFileName(file.FileName);
            fileExt = Path.GetExtension(file.FileName).Substring(1);
            fileName = fileName.Substring(0, fileName.LastIndexOf("."));

            DateTime n = DateTime.Now;
            fileName += n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                        + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                        + n.Millisecond.ToString();
            savedFileName = VinHelper.CalculateMD5Hash(fileName);

            try
            {
                file.SaveAs(Path.Combine(directory, savedFileName + "." + fileExt));
            }
            catch (Exception e)
            {
                /*
                HandleErrorInfo err = new HandleErrorInfo(e, "UploadImage", "ImageUploader");
                return View("~/Views/Shared/Error.cshtml", err);
                */
                return Json(new { location = "error" });
            }

            return Json(new { location = savedFileName + "." + fileExt });
        }


    }
}