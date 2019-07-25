using CargoEmpty.Models.General.Decleration;
using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Order
{
    public class OrderIndexView
    {
        public List<OrderDb> myOrders { get; set; } = new List<OrderDb>();

        public int AllOrdersCount { get; set; }
        public int OrderedCount { get; set; }
        public int isNotOrdered { get; set; }
        public int isExcuteOrder { get; set; }
        public int isNotExcuteOrder { get; set; }
        public int inForeignWarehouseCount { get; set; }
        public int inStorehouseBaku { get; set; }
        public int DeliveredCount { get; set; }
        public int isPaidCount { get; set; }
        public int isNotPaidCount { get; set; }
        public int OnWay { get; set; }
        public int isUrgentOrderCount { get; set; }
        public int isNormalOrderCount { get; set; }
    }
}