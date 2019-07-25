using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Order
{
    public class EditOder
    {
        public int Id { get; set; }
        public string OrderName { get; set; }
        public string Link { get; set; }
        public double Price { get; set; }
        public string Coment { get; set; }
        public int CategoryId { get; set; }
    }
}