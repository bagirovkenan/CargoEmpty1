using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Order
{
    public class CreateOrderView
    {
        [Required (ErrorMessage ="Bos Ola Bilmez")]
        public string[] OrderName { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public string[] Link { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public double[] Price { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public int[] Quantity { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public string[] Coment { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public bool[] isUrgent { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public int[] CategoryId { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public int CountryId { get; set; }

    }
}