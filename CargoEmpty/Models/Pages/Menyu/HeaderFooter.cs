using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Pages.Menyu
{
    public class HeaderFooter
    {
        public List<Menyu> NavItems { get; set; } = new List<Menyu>();
        public string Title { get; set; }
        public string Adress { get; set; }
        public string Mail { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string StartWorkClock { get; set; }
        public string EndWorkClock { get; set; }
        public string StartWorkDay { get; set; }
        public string EndWorkDay { get; set; }      
        public string FaceBookAdress { get; set; }
        public string InstagramAdress { get; set; }
        public string YoutubeAdress { get; set; }       
        public string TitleImagePath { get; set; }
    }
}