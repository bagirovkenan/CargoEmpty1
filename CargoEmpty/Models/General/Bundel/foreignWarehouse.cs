using CargoEmpty.Models.General.Decleration;
using CargoEmpty.Models.General.Order;
using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Bundel
{
    public class foreignWarehouse
    {
        public int Id { get; set; }
        public int OrderStatusId { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public int TrackingNumber { get; set; }
        public HttpPostedFileBase InvoiceFile { get; set; }
        public string InvoicePath { get; set; }
        public string Note { get; set; }
        [DisplayName("Teslim Alan")]
        public string RecieverPerson { get; set; }
        [DisplayName("Teslim Edilen")]
        public string SuppliersPerson { get; set; }
        [DisplayName("Xarici Anbara Gelme Tarixi")]
        public DateTime? ReceivingTime { get; set; }

        [Required]
        public int?  [] ProductId { get; set; }
        public string[] ProductName { get; set; }
        public string[] HarmonicCode { get; set; }
        public string[] CountryName { get; set; }
        public int?  [] CustomsValue { get; set; }


    }
}