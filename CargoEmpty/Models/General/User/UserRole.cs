using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.User
{
    public class UserRole
    {
        public int Id { get; set; }

        public int UserDbId { get; set; }
        public virtual UserDb UserDb { get; set; }

        public int RoleId { get; set; }
        public virtual Role Role { get; set; }

    }
}