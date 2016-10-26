using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PayPal.Api;
using TotaraPhotographyAssociation.Models;
using TotaraPhotographyAssociation.DomainEntities;
using TotaraPhotographyAssociation.Services;

namespace TotaraPhotographyAssociation.Controllers
{
    public class OrderController : Controller
    {
        private TotaraPhotoEntities dbCnxt = new TotaraPhotoEntities();

        // Vincent: display create order form
        [Authorize(Roles = "full, associate")]
        public ActionResult Create(Cart cart)
        {
            return View();
        }

        // Vincent: create order and redirect to Paypal
        [HttpPost]
        [Authorize(Roles = "full, associate")]
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
                            o.CustomerId = User.Identity.GetUserId();   // TODO: check

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

                            Session["orderid"] = orderID;

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
                        PayPalPaymentService.discount = 1 - 0.10m;  // TODO: get it from db
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


        [Authorize(Roles = "full, associate")]
        public ActionResult PaymentSuccessful(string paymentId, string token, string PayerID)
        {
            // Execute Payment
            var payment = PayPalPaymentService.ExecutePayment(paymentId, PayerID);
            
//
            if (Session != null && Session["orderid"] != null)
            {
                string orderID = Session["orderid"].ToString();

                CustomerOrder o = (from co in this.dbCnxt.CustomerOrders
                                   where co.Id == orderID
                                   select co).FirstOrDefault();
                o.OrderStatus = "paid";
                o.PaypalPaymentId = paymentId;
                this.dbCnxt.SaveChanges();

            }

            // clear cart
            if (Session != null && Session["cart"] != null)
            {
                Cart c = (Cart)Session["cart"];
                c.Clear();
            }

            return View();
        }

        [Authorize(Roles = "full, associate")]
        public ActionResult PaymentCancelled()
        {
            //return RedirectToAction("Error");
            return View();
        }

        // just compute the base url: localhost:44000
        private string GetBaseUrl()
        {
            return Request.Url.Scheme + "://" + Request.Url.Host + ":" + Request.Url.Port.ToString();
        }




    }
}