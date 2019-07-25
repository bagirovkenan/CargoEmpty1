using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CargoEmpty.Models.Helper
{
    public static class GenerateNewCod
    {
        public static string _newcod { get; set; }
        public static  string NewPassword()
        //{
             
        //    Task task1 = new Task(() =>
            {

                Random rnd = new Random();
                _newcod = rnd.Next(1000000, 9999999).ToString();
               
            //});

            //task1.Wait();
            return _newcod;
        }
    }
}