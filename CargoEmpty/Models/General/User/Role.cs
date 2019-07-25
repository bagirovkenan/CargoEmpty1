using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.User
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public virtual IEnumerable<UserRole> UserRoles { get; set; }
    }
}