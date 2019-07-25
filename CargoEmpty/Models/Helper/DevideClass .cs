using CargoEmpty.Models.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CargoEmpty.Models.Helper
{
    //bu lazim deyil(heleki)
    public static class DevideClass
    {
        public static string ClassString(string ElementClass)
        {
            var IndexActiv = ElementClass.LastIndexOf("-");
            var Activ = ElementClass.Substring(IndexActiv + 1);
           

            return Activ;
        }

        public static int ClassInt(string ElementClass)
        {
            var IndexActiv = ElementClass.LastIndexOf("-");
            var ActivId = int.Parse(ElementClass.Substring(0, ElementClass.Length - ElementClass.Substring(IndexActiv).Length));

            return ActivId;
        }

    }
}