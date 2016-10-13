﻿using System;
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
        public ActionResult Index()
        {
            List<Product> products = (from p in this.dbCnxt.Products
                                      where p.IsDeleted == false
                                      select p).ToList();
            return View(products);
        }

        public ActionResult Detail(string id = "")
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }
            else
            {
                Product p = (from prd in this.dbCnxt.Products
                             where prd.Id == id
                             select prd).FirstOrDefault();
                return View(p);
            }
        }
    }
}