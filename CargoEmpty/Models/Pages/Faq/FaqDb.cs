using CargoEmpty.Models.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Models.Pages.Faq
{
    public class FaqDb: PagesMainModel
    {
        public string FaqTitle { get; set; }
        [AllowHtml]
        public string FaqContent { get; set; }
        public DateTime? FaqCreateDate { get; set; }

        
    }
}