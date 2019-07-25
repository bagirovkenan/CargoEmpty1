using CargoEmpty.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace CargoEmpty.Models.General.Order
{
    public class OrderActions
    {
        //IsOrdered 
        public static async Task<List<OrderDb>> Ordered  (int? Userid)
        {
            using(CargoDbContext db = new CargoDbContext())
            {                               
                var OrderListist = await db.Orders.Where(w=>w.Ordered==true && w.UserDbId== Userid).ToListAsync();

                return OrderListist;
            }
        }
        
        public static async Task<List<OrderDb>> Ordered()
        {
            using (CargoDbContext db = new CargoDbContext())
            {
                var OrderListist = await db.Orders.Where(w => w.Ordered == true).ToListAsync();

                return OrderListist;
            }
        }

        //==============================================================================
        //is not decleration
        public static async Task<List<OrderDb>> IsNotDecleration(int? Userid, CargoDbContext db)
        {
         
                var OrderListist = await db.Orders.Where(w => w.Ordered == false && w.UserDbId == Userid).ToListAsync();

                return OrderListist;
            
        }

        public static async Task<List<OrderDb>> IsNotDecleration()
        {
            using (CargoDbContext db = new CargoDbContext())
            {
                var OrderListist = await db.Orders.Where(w => w.Ordered == false).ToListAsync();

                return OrderListist;
            }
        }
        //==================================================================
        ///IsPaid
        
        public static async Task<List<OrderDb>> IsPaid(int? Userid)
        {
            using (CargoDbContext db = new CargoDbContext())
            {
                var OrderListist = await db.Orders.Where(w => w.isPaid == true && w.UserDbId == Userid).ToListAsync();

                return OrderListist;
            }
        }

        public static async Task<List<OrderDb>> IsPaid()
        {
            using (CargoDbContext db = new CargoDbContext())
            {
                var OrderListist = await db.Orders.Where(w => w.isPaid == true).ToListAsync();

                return OrderListist;
            }
        }

        //==================================================================
        ///IsNotPaid

        public static async Task<List<OrderDb>> IsNotPaid(int? Userid)
        {
            using (CargoDbContext db = new CargoDbContext())
            {
                var OrderListist = await db.Orders.Where(w => w.isPaid == false && w.UserDbId == Userid).ToListAsync();

                return OrderListist;
            }
        }

        public static async Task<List<OrderDb>> IsNotPaid()
        {
            using (CargoDbContext db = new CargoDbContext())
            {
                var OrderListist = await db.Orders.Where(w => w.isPaid == false).ToListAsync();

                return OrderListist;
            }
        }

        //==================================================================
        ///Normal

        public static async Task<List<OrderDb>> Normal(int? Userid)
        {
            using (CargoDbContext db = new CargoDbContext())
            {
                var OrderListist = await db.Orders.Where(w => w.isUrgent == false && w.UserDbId == Userid).ToListAsync();

                return OrderListist;
            }
        }

        public static async Task<List<OrderDb>> Normal()
        {
            using (CargoDbContext db = new CargoDbContext())
            {
                var OrderListist = await db.Orders.Where(w => w.isUrgent == false).ToListAsync();
                return OrderListist;
            }
        }
        //==================================================================
        //Urgent
        public static async Task<List<OrderDb>> Urgent(int? Userid)
        {
            using (CargoDbContext db = new CargoDbContext())
            {
                var OrderListist = await db.Orders.Where(w => w.isUrgent == true && w.UserDbId == Userid).ToListAsync();

                return OrderListist;
            }
        }

        public static async Task<List<OrderDb>> Urgent()
        {
            using (CargoDbContext db = new CargoDbContext())
            {
                var OrderListist = await db.Orders.Where(w => w.isUrgent == true).ToListAsync();
                return OrderListist;
            }
        }

    }
}