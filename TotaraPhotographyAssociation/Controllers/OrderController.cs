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
            //Cart c = (Cart)Session["cart"];

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
            bool isValid = true;

            if (ModelState.IsValid)
            {
                if (cart.Lines.Count() == 0)
                {
                    ModelState.AddModelError("CartLoaded", "There is no item in your cart.");
                    //return View(vmodel);
                }
                else
                {
                    // Vincent: insert Order and OrderDetail record into database
                    string orderID = Guid.NewGuid().ToString();

                    using (var dbContextTransaction = dbCnxt.Database.BeginTransaction())
                    {
                        try
                        {
                            CustomerOrder o = new CustomerOrder();
                            o.Id = orderID;
                            o.ShippingEmail = vmodel.RecepientEmail;
                            o.ShippingFirstName = vmodel.RecepientFirstName;
                            o.ShippingLastName = vmodel.RecepientLastName;
                            o.ShippingPhone = vmodel.RecepientPhone;
                            o.ShippingPostalCode = vmodel.PostalCode;
                            o.DeliveryAddressLine1 = vmodel.DeliveryAddressLine_1;
                            o.DeliveryAddressLine2 = vmodel.DeliveryAddressLine_2;
                            o.OrderStatus = "nonpaid";
                            o.CreatedDate = DateTime.Now;

                            dbCnxt.CustomerOrders.Add(o);

                            int counter = 0;

                            foreach (CartLine l in cart.Lines)
                            {
                                counter++;
                                OrderDetail od = new OrderDetail();
                                od.OrderId = orderID;
                                od.LineNumber = counter;
                                od.ProductId = l.Product.Id;
                                od.Quantity = l.Quantity;
                                od.UnitPrice = l.Product.Price;
                                od.Discount = (1 - 0.10m);
                                od.CreatedDate = o.CreatedDate;

                                dbCnxt.OrderDetails.Add(od);
                            }

                            dbCnxt.SaveChanges();

                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // log
                            dbContextTransaction.Rollback();
                            isValid = false;
                        }

                    }

                    if (isValid)   // writing to db is successful
                    {
                        // go to Paypal
                        PayPalPaymentService.cart = cart;
                        PayPalPaymentService.discount = 1 - 0.10m;  // TODO:
                        PayPalPaymentService.orderId = orderID;
                        // pass discount

                        try
                        {
                            Payment payment = PayPalPaymentService.CreatePayment(GetBaseUrl(), "sale");
                            return Redirect(payment.GetApprovalUrl());
                        }
                        catch (Exception ex)
                        {
                            // log
                            // TODO: go to error
                        }
                    }

                    
                }
            }

            return View(vmodel);
        }



        public ActionResult PaymentSuccessful(string paymentId, string token, string PayerID)
        {
            // Execute Payment
            //var payment = PayPalPaymentService.ExecutePayment(paymentId, PayerID);

            // clear cart
            if (Session != null && Session["cart"] != null)
            {
                Cart c = (Cart)Session["cart"];
                c.Clear();
            }
            
            return View();
        }

        public ActionResult PaymentCancelled()
        {
            // TODO: Handle cancelled payment
            return RedirectToAction("Error");
        }


        public string GetBaseUrl()
        {
            return Request.Url.Scheme + "://" + Request.Url.Host + ":" + Request.Url.Port.ToString();
        }




    }
}