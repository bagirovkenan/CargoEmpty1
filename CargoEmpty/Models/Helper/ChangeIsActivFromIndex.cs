using CargoEmpty.Context;
using CargoEmpty.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Helper
{

    public static class ChangeIsActivFromIndex
    {
        public static bool ChangeStatus(string status) 
        {
            if (status == "Activ")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}