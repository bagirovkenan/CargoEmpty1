using CargoEmpty.Models.General.Order;
using CargoEmpty.Models.Pages.Tarif;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General
{
    public class Currency
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public bool IsActive { get; set; }
        public decimal? Value { get; set; }

        [NotMapped]
        public string Activ { get; set; }

        public virtual IEnumerable<Country> Countries { get; set; }

        //public virtual IEnumerable<OrderDb> OrderDbs { get; set; }
    }
}