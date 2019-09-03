using CargoEmpty.Models.General;
using CargoEmpty.Models.General.Order;
using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Pages.MyAcount
{
    public  class  MyAccountHome
    {
        public  UserDb User { get; set; } = new UserDb();
        public  List<OrderDb> OrderDbs { get; set; } = new List<OrderDb>();
        public  List<MyAddress> MyAdress { get; set; } = new List<MyAddress>();
    }
}