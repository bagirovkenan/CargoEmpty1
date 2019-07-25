using CargoEmpty.Models.General.Decleration;
using CargoEmpty.Models.General.Order;
using CargoEmpty.Models.Pages.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General
{
    public class Category
    {
        public int  Id { get; set; }
        [Required(ErrorMessage ="Bos Ola Bilmez")]
        public string CategoryName { get; set; }
        public bool IsActiv { get; set; }
        [NotMapped]
        public string Activ { get; set; }

        public virtual IEnumerable<ShopDb> Shops { get; set; }

        public virtual IEnumerable<OrderDb> Orders { get; set; }

        public virtual IEnumerable<DeclerationDb> DeclerationDbs { get; set; }

    }
}