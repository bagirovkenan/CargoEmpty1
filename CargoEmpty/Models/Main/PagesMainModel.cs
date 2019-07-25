using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Main
{
    public class PagesMainModel
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public  string  ImagePath { get; set; }
        [NotMapped]
        public string Activ { get; set; }
    }
}