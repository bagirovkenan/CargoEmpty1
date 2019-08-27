using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.User
{
    public class UserSearch
    {
        public int Id { get; set; }
        public string UserCode { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
    }
}