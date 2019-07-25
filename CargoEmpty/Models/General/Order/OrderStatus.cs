using CargoEmpty.Models.General.Bundel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Order
{
    public class OrderStatus
    {
        public int Id { get; set; }
        public string StatusName { get; set; }      

        //public virtual IEnumerable<BundelsDb> BundelsDbs { get; set; }
    }
}