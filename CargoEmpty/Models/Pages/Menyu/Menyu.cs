using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Pages.Menyu
{
    public class Menyu
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
    }
}