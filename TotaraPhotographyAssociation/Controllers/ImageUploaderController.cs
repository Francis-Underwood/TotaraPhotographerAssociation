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
        // Vince: ImageUploader controller, it accepts image posting request sent from
        // TinyMCE, and save the image on server, return a piece of JavaScript code to client
        [HttpPost]
        public string UploadImage(HttpPostedFileBase file)
        {
            string fileName;
            string fileExt = "";
            string savedFileName = "";
            
            if (file != null && file.ContentLength > 0)
            {
                string directory = Server.MapPath("~/App_Upload/");
                fileName = Path.GetFileName(file.FileName);
                fileExt = Path.GetExtension(file.FileName).Substring(1);
                fileName = fileName.Substring(0, fileName.LastIndexOf("."));

                /* Vince: file name consists of date + a piece of random string, to avoid 
                 * one image being overwritten
                 */

                DateTime n = DateTime.Now;
                fileName += n.Year.ToString() + n.Month.ToString() + n.Day.ToString()
                            + n.Hour.ToString() + n.Minute.ToString() + n.Second.ToString()
                            + n.Millisecond.ToString();

                // Vince: generate a random string for file name
                savedFileName = VinHelper.CalculateMD5Hash(fileName);

                try
                {
                    file.SaveAs(Path.Combine(directory, savedFileName + "." + fileExt));
                }
                catch (Exception e)
                {
                    return "<script>alert('Failed: " + e + "');</script>";
                }
            }
            else
            {
                return "<script>alert('Failed: Unkown Error. This form only accepts valid images.');</script>";
            }

            return "<script>top.$('.mce-btn.mce-open').parent().find('.mce-textbox').val('" + "/App_Upload/" + savedFileName + "." + fileExt + "').closest('.mce-window').find('.mce-primary').click();</script>";
            
        }


    }
}