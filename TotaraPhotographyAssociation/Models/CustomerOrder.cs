//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TotaraPhotographyAssociation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CustomerOrder
    {
        public string Id { get; set; }
        public string ShippingFirstName { get; set; }
        public string ShippingLastName { get; set; }
        public string ShippingEmail { get; set; }
        public string ShippingPhone { get; set; }
        public string DeliveryAddressLine1 { get; set; }
        public string DeliveryAddressLine2 { get; set; }
        public string ShippingPostalCode { get; set; }
        public string OrderStatus { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string PaypalPaymentId { get; set; }
        public string CustomerId { get; set; }
    }
}
