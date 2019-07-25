using CargoEmpty.Context;
using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;

namespace CargoEmpty.Models.General.Order
{
    public class DeleteOrder
    {
        public int UserId { get; set; }
        public int OrderId { get; set; }

        public static async Task<bool> Delete(DeleteOrder delete, CargoDbContext db)
        {
          
                var del = await db.Orders.FirstOrDefaultAsync(f => f.Id == delete.OrderId && f.UserDbId == delete.UserId);
                if (del!=null)
                {
                    db.Orders.Remove(del);                  
                    return true;
                }
                else
                {
                    return false;
                }
            
        }

        public static async Task<bool> Delete(int id, CargoDbContext db)
        {
           
                var del = await db.Orders.FirstOrDefaultAsync(f => f.Id ==id && f.UserDbId == UserSession.SessionId);
                if (del != null)
                {
                    db.Orders.Remove(del);
                    return true;
                }
                else
                {
                    return false;
                }
            
        }
    }
}