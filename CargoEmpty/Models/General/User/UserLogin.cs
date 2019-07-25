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
    public static class UserSession
    {
        public static string SessionIsLogin { get; set; }
        public static int?   SessionId { get; set; }
        public static string SessionUserCode { get; set; }
        public static string SessionUserName  { get; set; }
        public static string SessionMail{ get; set; }
        public static string SessionFirstName { get; set; }
        public static string SessionLastName { get; set; }

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