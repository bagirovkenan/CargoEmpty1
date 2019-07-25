using CargoEmpty.Controllers.Main;
using CargoEmpty.Models.General.Order;
using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.General
{
    public class JsonResultController : MainController
    {
        // GET: JsonResult
        [HttpPost]
        public ActionResult CustumerInfo(int id)
        {
            var Custumer = db.Users.FirstOrDefault(f => f.Id == id);            
            return PartialView(Custumer);
        }

        [HttpPost]
        public ActionResult CustumerOrders(int id)
        {
 
            var Orders = db.Orders.Where(f => f.UserDbId == id).ToList();          
            var Counts = new AdminCustumerOrdersStatusView();
            Counts.UserId = id;
            Counts.IsnotExcuteCount = db.Orders.Count(f => f.UserDbId == id && f.Executed == false);
            Counts.ExcuteCount = db.Orders.Count(f => f.UserDbId == id && f.Executed == true);
            Counts.DeclerationCount = db.Orders.Count(f => f.UserDbId == id && f.Ordered == true);
            Counts.NotDeclerationCount = db.Orders.Count(f => f.UserDbId == id && f.Ordered == false);
            Counts.IsNotPaid = db.Orders.Count(f => f.UserDbId == id && f.isPaid == false);        
            Counts.IsUrgentOrdersCount = db.Orders.Count(f => f.UserDbId == id && f.isUrgent == true);
            Counts.IsNormalOrderCount = db.Orders.Count(f => f.UserDbId == id && f.isUrgent == false);
          
            ViewBag.Const = Counts;
            return PartialView(Orders);
        }

        [HttpPost]
        public async Task<ActionResult> CountryAllOrders(int? id)
        {
            if (id==null)
            {
                var Orders = await db.Orders.ToListAsync();
                return PartialView(Orders);
            }
            else
            {
                var Orders = await db.Orders.Where(w => w.CountryId == id).ToListAsync();
                return PartialView(Orders);
            }
           
        }

        [HttpPost]
        public async Task<ActionResult> ExecutedOrdered(int id)
        {
            var Orders = await db.Orders.Where(f => f.UserDbId == id && f.Executed == true).ToListAsync();
            return PartialView(Orders);
        }
        [HttpPost]
        public async Task<ActionResult> AllExecutedOrdered()
        {
            var Orders = await db.Orders.Where(f => f.Executed == true).ToListAsync();
            return PartialView(Orders);
        }

        [HttpPost]
        public async Task<ActionResult> isNotExecutedOrdered(int id)
        {
            var Orders = await db.Orders.Where(f => f.UserDbId == id && f.Executed == false).ToListAsync();
            return PartialView(Orders);
        }
        [HttpPost]
        public async Task<ActionResult> IsNotAllExecutedOrdered()
        {
            var Orders = await db.Orders.Where(f => f.Executed == false).ToListAsync();
            return PartialView(Orders);
        }

        [HttpPost]
        public async Task<ActionResult> OrdersNotDecleration(int id)
        {
            var Orders = await db.Orders.Where(f => f.UserDbId == id && f.Ordered == false).ToListAsync();
            return PartialView(Orders);
        }
        [HttpPost]
        public async Task<ActionResult> AllOrdersNotDecleration()
        {
            var Orders = await db.Orders.Where(f => f.Ordered == false).ToListAsync();
            return PartialView(Orders);
        }


        [HttpPost]
        public async Task<ActionResult> OrdersOrdered(int id)
        {
            var Orders = await db.Orders.Where(f => f.UserDbId == id && f.Ordered == true).ToListAsync();
            return PartialView(Orders);
        }

        [HttpPost]
        public async Task<ActionResult> AllOrdersOrdered()
        {
            var Orders = await db.Orders.Where(f => f.Ordered == true).ToListAsync();
            return PartialView(Orders);
        }

        [HttpPost]
        public async Task<ActionResult> OrdersPait(int id)
        {
            var Orders = await db.Orders.Where(f => f.UserDbId == id && f.isPaid == true).ToListAsync();
            return PartialView(Orders);

        }
        [HttpPost]
        public async Task<ActionResult> AllOrdersPait()
        {
            var Orders = await db.Orders.Where(f =>f.isPaid == true).ToListAsync();
            return PartialView(Orders);

        }
        [HttpPost]
        public async Task<ActionResult> OrdersNotPait(int id)
        {
            var Orders = await db.Orders.Where(f => f.UserDbId == id && f.isPaid == false).ToListAsync();
            return PartialView(Orders);

        }
        [HttpPost]
        public async Task<ActionResult> AllOrdersNotPait()
        {
            var Orders = await db.Orders.Where(f =>f.isPaid == false).ToListAsync();
            return PartialView(Orders);

        }

        [HttpPost]
        public async Task<ActionResult> OrdersUrgent(int id)
        {
            var Orders = await db.Orders.Where(f => f.UserDbId == id && f.isUrgent == true).ToListAsync();
            return PartialView(Orders);
        }
        [HttpPost]
        public async Task<ActionResult> AllOrdersUrgent()
        {
            var Orders = await db.Orders.Where(f =>f.isUrgent == true).ToListAsync();
            return PartialView(Orders);
        }

        [HttpPost]
        public async Task<ActionResult> OrdersNormal(int id)
        {
            var Orders = await db.Orders.Where(f => f.UserDbId == id && f.isUrgent == false).ToListAsync();
            return PartialView(Orders);
        }
        [HttpPost]
        public async Task<ActionResult> AllOrdersNormal()
        {
            var Orders = await db.Orders.Where(f =>f.isUrgent == false).ToListAsync();
            return PartialView(Orders);
        }

        //[HttpPost]//deyisecey baglama olacaq
        //public ActionResult OrdersOutsideWarehouse(int id)
        //{
        //    var Orders = db.Orders.Where(f => f.UserDbId == id && f.OrderStatusId == 2).ToList();
        //    return PartialView(Orders);
        //}

        //[HttpPost] //deyisecey baglama olacaq
        //public ActionResult OrdersBakuWarehouse(int id)
        //{
        //    var Orders = db.Orders.Where(f => f.UserDbId == id && f.OrderStatusId == 3).ToList();
        //    return PartialView(Orders);
        //}



    }
}