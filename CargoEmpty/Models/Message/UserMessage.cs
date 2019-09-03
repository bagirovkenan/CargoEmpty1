using CargoEmpty.Context;
using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Helper
{
    public class UserMessage
    {

        public string FullName { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message { get; set; }
    }


    public class SmsCount
    {
        public static int UserMsgCount(int? id)
        {
            using (CargoDbContext db = new CargoDbContext())
            {
                int unread = db.Messages.Count(f => f.ToMesssageUserDbId == UserSession.SessionId && f.Read == false);
                return unread;
            }
        }

        /// /////////////////////////////////////////////////////////////

        public static int AdminMsgCount()
        {
            int unread = 0;

            using (CargoDbContext db = new CargoDbContext())
            {
                unread = db.Messages.Count(f => f.ToMesssageUserDbId == null && f.UserDbId != null && f.Read == false);
                return unread;
            }

        }
    }
}