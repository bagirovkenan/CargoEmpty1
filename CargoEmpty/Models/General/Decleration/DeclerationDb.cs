using CargoEmpty.Models.General.Bundel;
using CargoEmpty.Models.General.Order;
using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Decleration
{
    public class DeclerationDb
    {
        public int Id { get; set; }
        public int BundleCount { get; set; }
        public DateTime OrderDate { get; set; }
        public string FromOrder { get; set; }
        public string ShopName { get; set; }
        public decimal OrderPrice { get; set; }
        public int TrackingCode { get; set; }
        public string InvoicePath { get; set; }
        public string Comment { get; set; }
        public bool Executed { get; set; }
        public bool CreatAdmin { get; set; }
        public bool IsForeignWarehouse { get; set; }

        public double? Weight { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }


        public int BundelsDbId { get; set; }
      
        public int? OrderStatusId { get; set; }



        public int UserDbId { get; set; }
        public virtual UserDb UserDb { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

       



    }
}