using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Message
{
    public class MessageDb
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string FullName { get; set; }
        public string Company { get; set; }     
        public string Phone { get; set; }
        public bool Read { get; set; }
        public DateTime? CreateDate { get; set; }

        public string ToMail { get; set; }
        public string FromMail { get; set; }

        [DisplayName("Email Gonderilen")]
        public int? ToMesssageUserDbId { get; set; }

        [DisplayName("Email Gonderen")]
        public int? UserDbId { get; set; }
        public virtual UserDb User { get; set; }
    }
}