﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TotaraPhotographyAssociation.Models
{
    public class CreateOrderViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string RecepientFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string RecepientLastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string RecepientEmail { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        public string RecepientPhone { get; set; }

        [Required]
        [Display(Name = "Shipping Address Line1")]
        public string DeliveryAddressLine_1 { get; set; }

        
        [Display(Name = "Shipping Address Line2")]
        public string DeliveryAddressLine_2 { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        public string CartLoaded { get; set; }

    }


    public class MembershipViewModel
    {
        public string Role { get; set; }
        public Nullable<DateTime> ExpiryDate { get; set; }
    }


    public class PurchaseMembershipViewModel
    {
        public string Placeholder { get; set; }
    }

    public class EditAboutUsFormViewModel
    {
        [AllowHtml]
        public string AboutUs { get; set; }
    }

}