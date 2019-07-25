using CargoEmpty.Models.General.Decleration;
using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Order
{
    public class OrderDb
    {
        public int Id { get; set; } 
        public string OrderName { get; set; }
        public string Link { get; set; }    
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool Executed { get; set; }  
        public string Coment { get; set; }        
        public DateTime CreatedDate { get; set; }   
        public bool isPaid { get; set; }
        public bool isUrgent { get; set; }
        public bool Ordered { get; set; }
 
        public int UserDbId { get; set; }
        public virtual UserDb UserDb { get; set; }

        public int BundelsDbId { get; set; }
        //public virtual BundelsDb Bundel { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
 
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}