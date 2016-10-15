using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TotaraPhotographyAssociation.Models;
using TotaraPhotographyAssociation.DomainEntities;

namespace TotaraPhotographyAssociation.Controllers
{
    public class CartController : Controller
    {
        private TotaraPhotoEntities dbCnxt = new TotaraPhotoEntities();

        // GET: Cart
        public ActionResult Index(Cart cart, string rtnUrl = "")
        {

            return View(new CartIndexViewModel
                        {
                            Cart = cart,
                            ReturnUrl = rtnUrl
                        }
                );
        }

        public ActionResult AddToCart(Cart cart, string prdId, int qty = 1, string rtnUrl = "")
        {
            Product p = this.dbCnxt.Products.FirstOrDefault(prd => prd.Id == prdId);

            if (p != null)
            {
                cart.AddItem(p, qty);

            }

            return Redirect(rtnUrl);
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }


        public ActionResult UpdateCart(Cart cart)
        {
            foreach (var l in cart.Lines)
            {
                var id = l.Product.Id;
                if (Request[id] != null)
                {
                    int qty = Convert.ToInt32(Request[id]);
                    if (qty < 1)
                    {
                        qty = 1;
                    }
                    l.Quantity = qty;
                }
            }

            if (Request["checkoutMarker"] != null)
            {
                if (Request["checkoutMarker"] == "1")
                    return RedirectToAction("CheckOut", "Cart");
            }

            return RedirectToAction("Index", "Cart");
        }

        public ActionResult RemoveFromCart(Cart cart, string prdId)
        {
            try
            {
                cart.RemoveLine(prdId);
            }
            catch (Exception ex)
            {

            }
            return RedirectToAction("Index", "Cart");
        }


        public ActionResult CheckOut(Cart cart)
        {
            return View();
        }


    }
}