using CargoEmpty.Models.General.Bundel;
using CargoEmpty.Models.General.Decleration;
using CargoEmpty.Models.General.Order;
using CargoEmpty.Models.Main;
using CargoEmpty.Models.Pages.Tarif;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General
{
    public class Country: PagesMainModel
    {
        public string CauntryName { get; set; }

        public int CurrencyId { get; set; }
        public virtual Currency CountryCurrency { get; set; }

        public virtual ICollection<Tarif> Tarifs { get; set; }

        public virtual ICollection<OrderDb> OrderDbs { get; set; }

        public virtual ICollection<DeclerationDb> DeclerationDbs { get; set; }

        public virtual ICollection<BundelsDb> Bundels { get; set; }

        [NotMapped]
        public HttpPostedFileBase CountryFlag { get; set; }


    }
}