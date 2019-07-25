using CargoEmpty.Models.General;
using CargoEmpty.Models.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Pages.Shop
{
    public class ShopDb:PagesMainModel
    {
        public string ShopName { get; set; }
        public string Link { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public int? AccountNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int? PostCode { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}