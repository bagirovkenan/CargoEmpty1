using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.User
{
    public class UserLogin
    {
        public string UerNameOrMail { get; set; }
        public string Password { get; set; }
    }
/// <summary>
/// ///////////////////////////////////////////////////
/// </summary>
    public static class NewUserSession
    {
       public static UserDb SessionUser()
        {
            if (HttpContext.Current.Session["isLogin"]!=null)
            {
                UserDb user = (UserDb)HttpContext.Current.Session["User"];
                return user;
            }
            else
            {
                UserDb us = new UserDb();
                return us;
            }

        }

    }

    /// <summary>
    /// ///////////////////////////////////////////////////
    /// </summary>
    /// 
    public class ForgetThePassword
    {
        
        [Required (ErrorMessage ="Bos Ola Bilmez Ve Qeydiyyatdan Kecdiyiniz Emaili Yazin")]
        public string Mail { get; set; }
        [Required (ErrorMessage ="Bos Ola Bilmez Ve Qeydiyyatdan Kecdiyiniz Adinizi Yazin")]
        public string FirstName { get; set; } 
        [Required (ErrorMessage ="Bos Ola Bilmez Ve Qeydiyyatdan Kecdiyiniz Soyadinizi Yazin")]
        public string LastName { get; set; }
    }

    /// <summary>
    /// ///////////////////////////////////////////////////
    /// </summary>
    /// 
}