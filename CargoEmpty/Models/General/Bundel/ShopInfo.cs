using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Bundel
{
    public class ShopInfo
    {
        public bool Success { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public int? AccountNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int? PostCode { get; set; }
    }
}