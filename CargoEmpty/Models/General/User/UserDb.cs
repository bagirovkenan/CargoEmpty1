﻿using CargoEmpty.Models.General.Bundel;
using CargoEmpty.Models.General.Decleration;
using CargoEmpty.Models.General.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.User
{
    public class UserDb
    {
        public int Id { get; set; }

        public string UserCod { get; set; }

        [Required(ErrorMessage ="Bos Ola Bilmez")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
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
        [StringLength(7,ErrorMessage ="7 reqem olmalidi")]
        public string FINNumber { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        [StringLength(12,ErrorMessage = "7 reqem olmalidi")]
        public string IDCardNumber { get; set; }

        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bos Ola Bilmez")]
        public string HashPassword { get; set; }

        public decimal? Balance { get; set; }
       
        public decimal? BonusBalance { get; set; }

        public bool BlakcList { get; set; }
        public bool VIPClient { get; set; }

        public virtual IEnumerable<OrderDb> OrderDbs { get; set; }

        public virtual IEnumerable<BundelsDb> Bundels { get; set; }

        public virtual IEnumerable<DeclerationDb> DeclerationDbs { get; set; }

        public virtual IEnumerable<UserRole> UserRoles { get; set; }

        public UserDb()
        {
            BlakcList = false;
            Balance = 0;
            BonusBalance = 0;
        }
    }
}