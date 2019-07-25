using CargoEmpty.Context;
using CargoEmpty.Models.General.Decleration;
using CargoEmpty.Models.General.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CargoEmpty.Models.General.Bundel
{
    public class BundelLinks
    {
        public int Id { get; set; }
        public int UserDbId { get; set; }
        public string OrderLink { get; set; }
        

        public  BundelLinks (OrderDb order)
        {
            Id = order.Id;
            UserDbId = order.UserDbId;
            OrderLink = order.Link;                  
        }

        public BundelLinks(DeclerationDb dec)
        {
            Id = dec.Id;
            UserDbId = dec.UserDbId;          
        }
    }
}