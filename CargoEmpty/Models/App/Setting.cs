using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.App
{
    public class Setting
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string  Adress {get;set;}
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string StartWorkClock { get; set; }
        public string EndWorkClock { get; set; }
        public string StartWorkDay { get; set; }
        public string EndWorkDay { get; set; }
        public string WorkDays { get; set; }
        public string FaceBookAdress{get;set;}
        public string InstagramAdress{get;set;}
        public string YoutubeAdress{get;set; }
        public decimal BankSpending { get; set; }
        public decimal UrgentBookingPrice { get; set; }
        public string TitleImagePath { get; set; }
        public decimal USD { get; set; }
        public decimal EUR { get; set; }
        public decimal TRY { get; set; }

        [NotMapped]
        public HttpPostedFileBase TitleImage { get; set; }
    }
}