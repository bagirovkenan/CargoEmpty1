using CargoEmpty.Models.General.Decleration;
using CargoEmpty.Models.General.Order;
using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Bundel
{
    public class BundelsDb
    {

        public int Id { get; set; }
        public double Price { get; set; }
        public double? DeliveryPrice { get; set; }
        public double? TransportationFee { get; set; }
        public double? Weight { get; set; }
        public double? Height { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public int? TrackingNumber { get; set; }
        public int? UnicalNumberReception { get; set; }
        public string Note { get; set; }
        [DisplayName("Teslim Alan")]
        public string RecieverPerson { get; set; }
        [DisplayName("Teslim Edilen")]
        public string SuppliersPerson { get; set; }
        public string CargoType { get; set; }
        public string TransportationInvoiced { get; set; }
        public string InternalTestimonials { get; set; }

        [DisplayName("Yaranma Tarixi(Sifaris edilme)")]
        public DateTime CreateDate { get; set; }
        [DisplayName("Xarici Anbara Gelme Tarixi")]
        public DateTime? ReceivingTime { get; set; }
        [DisplayName("Yola dusme tarixi")]
        public DateTime? OnWay { get; set; }
        [DisplayName("Baki anbarina catma Tarix")]
        public DateTime? InBaku { get; set; }

        [DisplayName("Catdirlima Tarix")]
        public DateTime? DeliveryTime { get; set; }

        //Shop information
        public string ShopName { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public int? AccountNumber { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public int? PostCode { get; set; }

        public string InvoicePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase InvoiceFile { get; set; }

        public int UserDbId { get; set; }
        public virtual UserDb User { get; set; }

        public int CountryId { get; set; }
        //public virtual Country BundelCountry { get; set; }

        public int OrderStatusId { get; set; }
        //public virtual OrderStatus OrderStatus { get; set; }

        public virtual IEnumerable<OrderDb> Orders { get; set; }

        public virtual IEnumerable<DeclerationDb> Declerations { get; set; }

        public virtual IEnumerable<BundelProducts> BundelProducts { get; set; }



    }
}