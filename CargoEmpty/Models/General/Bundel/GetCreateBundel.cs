using CargoEmpty.Models.General.Decleration;
using CargoEmpty.Models.General.Order;
using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Bundel
{
    public class GetCreateBundel
    {
      
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserCod { get; set; }
        public decimal? Balance { get; set; }
        public decimal? BonuceBalance { get; set; }
        public List<OrderDb> Orders { get; set; } = new List<OrderDb>();
        public List<DeclerationDb> Declerations { get; set; } = new List<DeclerationDb>();
        public List<Country> Countries { get; set; } = new List<Country>();

    }
}