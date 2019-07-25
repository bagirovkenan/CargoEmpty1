using CargoEmpty.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Pages.Faq
{
    public class FaqView: PagesMainModel
    {
       
        public string FaqTitle { get; set; }
        public string FaqContent { get; set; }
    }
}