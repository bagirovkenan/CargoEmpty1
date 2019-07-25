using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Order
{
    public class AdminCustumerOrdersStatusView
    {
        public int UserId { get; set; }
        public int DeclerationCount { get; set; }
        public int NotDeclerationCount { get; set; }
        public int IsNotPaid { get; set; }      
        public int IsUrgentOrdersCount { get; set; }
        public int IsNormalOrderCount { get; set; }
        public int ExcuteCount { get; set; }
        public int IsnotExcuteCount { get; set; }
    }
}