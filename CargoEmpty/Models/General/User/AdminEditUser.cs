using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.User
{
    public class AdminEditUser
    {
        public int Id { get;set; }
        public string[] UserRoles { get; set; }
    }

    public class AdminEditCustumer
    {
        public int Id { get; set; }
        public string BlackList { get; set; }
        public string VIPClient { get; set; }
    }
}