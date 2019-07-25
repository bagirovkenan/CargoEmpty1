using CargoEmpty.Models.General;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;
using System.Linq;

namespace CargoEmpty.Models.Pages.Shop
{
    public class ShopView
    {
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string Link { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public int? AccountNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int? PostCode { get; set; }
        public string Activ { get; set; }
        public HttpPostedFileBase ShopImage { get; set; }
        public int CategoryId { get; set; }    //???
       
    }
}