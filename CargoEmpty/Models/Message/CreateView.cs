using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.Message
{
    public class CreateView
    {
        public int   UserDbId { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Company { get; set; }
    }

    public class ReadMessage
    {
        public int? MessageId { get; set; }
        public int? UserId { get; set; }
    }
}