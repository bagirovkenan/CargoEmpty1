using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Decleration
{
    public class CreateDeclerationWithOrder
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public int CountryId { get; set; }
        public string CurrencyName { get; set; }
        public int CurrencyId { get; set; }
        public DateTime Date { get; set; }
        public int BundelCount { get; set; }
        public decimal Price { get; set; }
        public string Coment { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string ShopName { get; set; }

    }
}