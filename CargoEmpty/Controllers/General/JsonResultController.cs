using CargoEmpty.Controllers.Main;
using CargoEmpty.Models.General.Decleration;
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
        //custumer details customers info
       
        [HttpPost]
        public async Task<ActionResult> CustumerInfo(int id)
        {
            var Custumer =await db.Users.FirstOrDefaultAsync(f => f.Id == id);            
            return PartialView(Custumer);
        }

//customers details orders
        [HttpPost]
        public async Task<ActionResult> CustumerOrders(int id)
        {
 
            var Orders = await db.Orders.Where(f => f.UserDbId == id).ToListAsync();          
            var Counts = new AdminCustumerOrdersStatusView();
            Counts.UserId = id;
            Counts.IsnotExcuteCount = await db.Orders.CountAsync(f => f.UserDbId == id && f.Executed == false);
            Counts.ExcuteCount =await db.Orders.CountAsync(f => f.UserDbId == id && f.Executed == true);
            Counts.DeclerationCount =await db.Orders.CountAsync(f => f.UserDbId == id && f.Ordered == true);
            Counts.NotDeclerationCount =await db.Orders.CountAsync(f => f.UserDbId == id && f.Ordered == false);
            Counts.IsNotPaid =await db.Orders.CountAsync(f => f.UserDbId == id && f.isPaid == false);        
            Counts.IsUrgentOrdersCount =await db.Orders.CountAsync(f => f.UserDbId == id && f.isUrgent == true);
            Counts.IsNormalOrderCount =await db.Orders.CountAsync(f => f.UserDbId == id && f.isUrgent == false);
          
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
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// Custumers Details Declerations
        /// 
        [HttpPost]
        public async Task<ActionResult> CustumerDecleration(int id)
        {

            var Decs = await db.Declerations.Where(w => w.UserDbId == id && w.CreatAdmin==false).ToListAsync();
            ViewBag.Statuse = await db.OrderStatuses.ToListAsync();
            ViewBag.Country = await db.Countries.ToListAsync();
            return PartialView(Decs);
        }

        [HttpPost]
        public async Task<ActionResult> SelectCountryDec(UserBundelStatusAndCountry id)
        {
            List<DeclerationDb> Decs = new List<DeclerationDb>();

            if (id.StatusId==null && id.CountryId==null)
            {
                Decs = await db.Declerations.Where(w => w.UserDbId == id.UserId && w.CreatAdmin == false).ToListAsync();
            }
            else if (id.StatusId == null && id.CountryId != null)
            {
                Decs = await db.Declerations.Where(w => w.UserDbId == id.UserId && w.CountryId==id.CountryId && w.CreatAdmin == false).ToListAsync();
            }
            else if (id.StatusId != null && id.CountryId == null)
            {
                Decs = await db.Declerations.Where(w => w.UserDbId == id.UserId && w.OrderStatusId == id.StatusId && w.CreatAdmin == false).ToListAsync();
            }
            else if (id.StatusId != null && id.CountryId != null)
            {
                Decs = await db.Declerations.Where(w => w.UserDbId == id.UserId &&  w.CountryId == id.CountryId && w.OrderStatusId == id.StatusId && w.CreatAdmin == false).ToListAsync();
            }

            ViewBag.Statuse = await db.OrderStatuses.ToListAsync();
            ViewBag.Country = await db.Countries.ToListAsync();
            
            return PartialView(Decs);
        }
        //edit decs
        [HttpPost]
        public async Task<ActionResult> Edite(EditeDec dec)
        {
            int UserId = 0;
            if (ModelState.IsValid)
            {
                var decDb = await db.Declerations.FirstOrDefaultAsync(f => f.Id == dec.Id);
                if (decDb != null)
                {
                    decDb.IsForeignWarehouse = true;
                    decDb.Weight = dec.Weight;
                    decDb.Length = dec.Length;
                    decDb.Width = dec.Width;
                    decDb.Height = dec.Height;
                    decDb.OrderStatusId = dec.OrderStatusId;
                    UserId = decDb.UserDbId;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("CustumerDetails", "User", new { id = UserId });
        }
    }
}