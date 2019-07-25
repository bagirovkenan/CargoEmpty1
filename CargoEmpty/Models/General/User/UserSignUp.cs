using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.User
{
    public class UserSignUp
    {
        

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="Bos Ola Bilmez")]
        [Range(15,75,ErrorMessage ="Yasi Duzgun Daxil Edin")]
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
        [StringLength(7,ErrorMessage ="Fin nomreni Duzgun Daxil edin")]
        public string FINNumber { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        [StringLength(12 , ErrorMessage = "Seria Nomreni Duzgun Daxil Edin")]
        public string IDCardNumber { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        [MinLength(6, ErrorMessage = "Parolun uzunlugu en az 6 olmalidi")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        [MinLength(6, ErrorMessage = "Tekrar Parol Duzgun Deyil")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Condition { get; set; }



    }
}