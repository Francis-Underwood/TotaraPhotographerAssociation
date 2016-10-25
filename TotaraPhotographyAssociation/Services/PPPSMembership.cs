﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PayPal.Api;
using System.Web.Mvc;
using TotaraPhotographyAssociation.DomainEntities;

namespace TotaraPhotographyAssociation.Services
{
    public class PPPSMembership
    {
        public static string stockUId;
        public static string planName;
        public static decimal membershipFee;

        public static Payment CreatePayment(string baseUrl, string intent)
        {
            APIContext apiContext = PayPalConfiguration.GetAPIContext();

            // Payment Resource
            Payment payment = new Payment()
            {
                intent = intent,    // `sale` or `authorize`
                payer = new Payer() { payment_method = "paypal" },
                transactions = GetTransactionsList(),
                redirect_urls = GetReturnUrls(baseUrl, intent)
            };

            try
            {
                // Create a payment using a valid APIContext
                Payment createdPayment = payment.Create(apiContext);
                return createdPayment;
            }
            catch (PayPal.PayPalException ex)
            {
                //Logger.Log("Error: " + ex.Message);
                throw new Exception("Navigating to Paypal failed");
            }

        }



        private static List<Transaction> GetTransactionsList()
        {
            // for test
            //discountedAmount = 3.00m;

            // A transaction defines the contract of a payment
            // what is the payment for and who is fulfilling it. 
            var transactionList = new List<Transaction>();


            ItemList itemlist = new ItemList();
            itemlist.items = new List<Item>();

            Item i = new Item();

            i.name = "Purchase " + planName + " from Totara Photographer Association of New Zealand";
            i.currency = "NZD";
            i.price = membershipFee.ToString("#0.00");
            i.quantity = "1";
            i.sku = stockUId; // 

            itemlist.items.Add(i);

            // The Payment creation API requires a list of Transaction; 
            // add the created Transaction to a List
            transactionList.Add(
                new Transaction()
                {
                    description = "Payment of transaction from Totara Photographer Association of New Zealand.",
                    invoice_number = new Random().Next(999999).ToString(), // TODO:, // TODO: 
                    amount = new Amount()
                    {
                        currency = "NZD",
                        total = membershipFee.ToString("#0.00"),  // get total from session     // Total must be equal to sum of shipping, tax and subtotal.
                        details = new Details() // Details: Let's you specify details of a payment amount.
                        {
                            tax = "0",
                            shipping = "0",
                            subtotal = membershipFee.ToString("#0.00")
                            //subtotal = "3.00" // for testing
                        }
                    },
                    // grab from session
                    item_list = itemlist
                }
            );

            return transactionList;
        }


        public static Payment ExecutePayment(string paymentId, string payerId)
        {
            var apiContext = PayPalConfiguration.GetAPIContext();

            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            var payment = new Payment() { id = paymentId };

            // Execute the payment
            Payment executedPayment = null;
            try
            {
                executedPayment = payment.Execute(apiContext, paymentExecution);

                var sale = Sale.Get(apiContext, paymentId);
            }
            catch (Exception ex)
            {
                // log
                return executedPayment;
            }

            return executedPayment;
        }



        private static RedirectUrls GetReturnUrls(string baseUrl, string intent)
        {
            //var returnUrl = intent == "sale" ? "/Order/PaymentSuccessful" : "/Order/AuthorizeSuccessful"; // TODO:
            var returnUrl = "/Membership/PaymentSuccessful";

            // Redirect URLS
            // These URLs will determine how the user is redirected from PayPal 
            // once they have either approved or canceled the payment.
            return new RedirectUrls()
            {
                cancel_url = baseUrl + "/Membership/PaymentCancelled",
                return_url = baseUrl + returnUrl
            };
        }

    }
}