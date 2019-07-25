using CargoEmpty.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Models.Pages.About
{
    public class AboutDb:PagesMainModel
    {
        [AllowHtml]
        public string ContentText{ get; set; }
        public DateTime? CreateDate { get; set; }
    }
}