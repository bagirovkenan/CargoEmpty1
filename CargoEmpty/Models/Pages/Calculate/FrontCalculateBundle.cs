using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Pages.Calculate
{
    public class FrontCalculateBundle
    {
        public int CountryId { get; set; }
        public int BundelCount { get; set; }
        public decimal BundleLenght { get; set; }
        public decimal BundleWidth { get; set; }
        public decimal BundleHeight { get; set; }
        public decimal BundleWeight { get; set; }
    }
}