using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Bundel
{
    public class BundelProducts
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string HarmonicCode { get; set; }
        public string CountryName { get; set; }
        public int? CustomsValue { get; set; }

        public int BundelsDbId { get; set; }
        public virtual BundelsDb Bundels { get; set; }
    }
}

