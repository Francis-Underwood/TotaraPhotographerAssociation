using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotaraPhotographyAssociation.Models;

namespace TotaraPhotographyAssociation.Controllers
{
    public class NewProductController : Controller
    {
        private TotaraPhotoEntities dbCnxt = new TotaraPhotoEntities();

        // GET: NewProduct
        // Vincent: list all the products
        [Authorize(Roles = "full, associate, expired, inactive")]
        public ActionResult Index()
        {
            List<Product> products = (from p in this.dbCnxt.Products
                                      where p.IsDeleted == false
                                      select p).ToList();
            return View(products);
        }

        // Vincent: display the detail of a product
        [Authorize(Roles = "full, associate, expired, inactive")]
        public ActionResult Detail(string prdId = "")
        {
            // Vince: check the validity 
            if (string.IsNullOrEmpty(prdId))
            {
                return View();
            }
            else
            {
                Product p = (from prd in this.dbCnxt.Products
                             where prd.Id == prdId
                             select prd).FirstOrDefault();
                return View(p);
            }
        }
    }
}