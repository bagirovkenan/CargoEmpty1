using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.User
{
    public class UserEdit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        [Range(18, 99, ErrorMessage = "Yasi Duzgun Daxil Edin(Yasiniz 18 den kicik e 99 dan boyuk durse qeyd ola bilmessiz )")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        [EmailAddress]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        [StringLength(7, ErrorMessage = "Fin nomreni Duzgun Daxil edin")]
        public string FINNumber { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        [StringLength(12, ErrorMessage = "Seria Nomreni Duzgun Daxil Edin")]
        public string IDCardNumber { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public string UserName { get; set; }

        public string LastPassword { get; set; }
        public string NewPassword { get; set; }
        public string NewConfirmPassword { get; set; }

      

    }
}