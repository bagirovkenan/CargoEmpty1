using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Bundel
{
    public class PostCreateBundel
    {
        public int UserDbId { get; set; }
        public decimal Price { get; set; }
        public string[] orderId { get; set; }
        public string Note { get; set; }
        public DateTime CreateDate { get; set; }
        public int CountryId { get; set; }

        public int? UnicalNumberReception { get; set; }
        public string CargoType { get; set; }
        public string TransportationInvoiced { get; set; }
        public string InternalTestimonials { get; set; }

        public string ShopName { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public int? AccountNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int? PostCode { get; set; }
    }
}