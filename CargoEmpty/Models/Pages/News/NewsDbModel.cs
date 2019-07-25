using CargoEmpty.Models.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Models.Pages.News
{
    public class NewsDbModel:PagesMainModel
    {
        public string NewsTitle { get; set; }
        [AllowHtml]
        public string NewsContent { get; set; }
        public DateTime? NewsCreateDate { get; set; }
        public DateTime? NewsRefreshDate { get; set; }
        [NotMapped]
        public HttpPostedFileBase NewsImg { get; set; }
       
    }
}
