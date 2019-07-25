using CargoEmpty.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CargoEmpty.Models.General.Bundel
{
    public static class BundelAddOrder
    {
        public static void AddOrder(string OrderName, int BundelId, CargoDbContext db)
        {
            int id = int.Parse(OrderName.Substring(0, OrderName.IndexOf("-")));
            string order = OrderName.Substring(OrderName.IndexOf("-") + 1);
            if (order.ToUpper() == "order".ToUpper())
            {
                var orderDb = db.Orders.FirstOrDefault(f => f.Id == id && f.BundelsDbId == 0 && f.Executed == false && f.Ordered==true && f.isPaid==true);
                if (orderDb != null)
                {
                    orderDb.Executed = true;
                    orderDb.BundelsDbId = BundelId;
                }
            }
            else
            {
                var DecDb = db.Declerations.FirstOrDefault(f =>f.Id==id && f.BundelsDbId==0 && f.Executed == false && f.CreatAdmin == false && f.IsForeignWarehouse == true);
                if (DecDb!=null)
                {
                    DecDb.Executed = true;
                    DecDb.BundelsDbId = BundelId;
                }
            }
        }
    }
}
