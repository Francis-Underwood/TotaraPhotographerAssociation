﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;
using System.Web.Mvc;
using TotaraPhotographyAssociation.DomainEntities;

namespace TotaraPhotographyAssociation.Services
{
    public class PayPalPaymentService
    {
        static public Cart cart;
        static public decimal discount;
        static public string orderId;
        static public string invoice;


        public static Payment CreatePayment(string baseUrl, string intent)
        { 
            var apiContext = PayPalConfiguration.GetAPIContext();

            // Payment Resource
            var payment = new Payment()
            {
                intent = intent,    // `sale` or `authorize`
                payer = new Payer() { payment_method = "paypal" },
                transactions = GetTransactionsList(),
                redirect_urls = GetReturnUrls(baseUrl, intent)
            };

            // Create a payment using a valid APIContext
            var createdPayment = payment.Create(apiContext);

            return createdPayment;
        }



        private static List<Transaction> GetTransactionsList()
        {
            decimal discountedAmount = cart.ComputeTotalValue();
         
            // A transaction defines the contract of a payment
            // what is the payment for and who is fulfilling it. 
            var transactionList = new List<Transaction>();


            ItemList itemlist = new ItemList();

            foreach(var line in cart.Lines)
            {
                Item i = new Item();
                i.name = line.Product.Name;
                i.currency = "NZD";
                i.price = line.Product.Price.ToString("#0.00");
                i.quantity = line.Quantity.ToString();
                i.sku = line.Product.Id;

                itemlist.items.Add(i);
            }

            // The Payment creation API requires a list of Transaction; 
            // add the created Transaction to a List
            transactionList.Add(
                new Transaction()
                {
                    description = "Payment of transaction from Totara Photographer Association.",
                    invoice_number = "XXXXXXXXXXXXXX", // TODO: 
                    amount = new Amount()
                    {
                        currency = "NZD",
                        total = discountedAmount.ToString("#0.00"),  // get total from session     // Total must be equal to sum of shipping, tax and subtotal.
                        details = new Details() // Details: Let's you specify details of a payment amount.
                        {
                            tax = "0",
                            shipping = "0",
                            subtotal = discountedAmount.ToString("#0.00")
                        }
                    },
                    // grab from session



                    item_list = itemlist


                }
            );

            return transactionList;
        }




        private static RedirectUrls GetReturnUrls(string baseUrl, string intent)
        {
            //var returnUrl = intent == "sale" ? "/Order/PaymentSuccessful" : "/Order/AuthorizeSuccessful"; // TODO:
            var returnUrl = "/Order/PaymentSuccessful";

            // Redirect URLS
            // These URLs will determine how the user is redirected from PayPal 
            // once they have either approved or canceled the payment.
            return new RedirectUrls()
            {
                cancel_url = baseUrl + "/Order/PaymentCancelled",
                return_url = baseUrl + returnUrl
            };
        }








    }
}