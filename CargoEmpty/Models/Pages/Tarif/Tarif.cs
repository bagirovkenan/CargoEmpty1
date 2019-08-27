using CargoEmpty.Models.General;
using CargoEmpty.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Pages.Tarif
{
    public class Tarif : PagesMainModel
    {
        public decimal MaxWeight { get; set; }
        public decimal MinWeight { get; set; }
        public decimal WeightPrice { get; set; }

        public int CountryId {get;set;}
        public virtual Country Country { get; set; }
    }
   
}