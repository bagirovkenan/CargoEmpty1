using CargoEmpty.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Pages.News
{
    public class NewsViewModel:PagesMainModel
    {
        public string NewsTitle { get; set; }
        public string NewsContent { get; set; }
        public DateTime NewsCreateDate { get; set; }
        public DateTime? NewsRefreshDate { get; set; }
        public HttpPostedFileBase NewsImg { get; set; }
    }
}

