using CargoEmpty.Controllers.Main;
using CargoEmpty.Models.General.Decleration;
using CargoEmpty.Models.General.Order;
using CargoEmpty.Models.General.User;
using CargoEmpty.Models.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.General
{
    public class DeclerationsController : MainController
    {
        //create decleration from user account
        [HttpPost]
        public ActionResult Create(CreateDeclerationView create)
        {

            var user = db.Users.FirstOrDefault(f => f.Id == UserSession.SessionId);

            if (ModelState.IsValid && create.Invoice != null && create.Invoice.ContentLength > 0 && user != null)
            {
                var dec = CreateDeclerationView.Creaet(user.Id, create);
                dec.IsForeignWarehouse = false;
                dec.CreatAdmin = false;
                db.Declerations.Add(dec);
                db.SaveChanges();
                return RedirectToAction("Index", "MyAccount");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

/// <summary>//// /////////////////////////////////////////////////////////////////////////
// Decleration actions for admin
 

        // GET: Declerations
        //return decleration list 
        public ActionResult Index()
        {
            return View();
        }

        //For an Admin to create  a decleration for the custumer on the all pages

        public async Task<ActionResult> CreateOnLayoutPage()
        {
            var users = await db.Users.ToListAsync();
            ViewBag.Country = await db.Countries.ToListAsync();
            ViewBag.Category = await db.Categories.ToListAsync();
            ViewBag.Orders = await db.Orders.ToListAsync();
            return PartialView(users);
        }

        //For an Admin to create  a decleration for the custumer on the custumer details page 
        //public async Task<ActionResult> CreateOnDetailsPage(int id)
        //{
        //    var UserOrders = await db.Orders.Where(w => w.UserDbId == id && w.isPaid == true).ToListAsync();
        //    ViewBag.Country = await db.Countries.ToListAsync();
        //    ViewBag.Category = await db.Categories.ToListAsync();
        //    ViewBag.Custumer = await db.Users.FirstOrDefaultAsync(f => f.Id == id);
        //    return PartialView(UserOrders);
        //}

       


        [HttpPost]
       public ActionResult CreateOnDetailsPage(CreateDeclerationView create)
        {
            var order =   db.Orders.FirstOrDefault(f => f.Id == create.OrderDbId && f.UserDbId==create.UserDbId);

            if (ModelState.IsValid && create.Invoice != null && create.Invoice.ContentLength > 0 && order != null)
            {
                create.CreatAdmin = true;
                var dec = CreateDeclerationView.Creaet(order.UserDbId, create);
                dec.IsForeignWarehouse = false;
                dec.CreatAdmin = true;
                db.Declerations.Add(dec);
                db.SaveChanges();
                return RedirectToAction("CustumerDetails", "User", new { id = create.UserDbId });
            }
            else
            {
                return RedirectToAction("CustumerDetails", "User", new { id = create.UserDbId });
            }
        }



        //Returns order information  according to order ID  admin used  when  creating a decleration for users
        [HttpPost]
        public async Task<JsonResult> OrderInformation(int id,int UserId)
        {
            OrderDb order = await db.Orders.FirstOrDefaultAsync(f => f.Id == id && f.UserDbId == UserId && f.Ordered == false && f.isPaid == true);

            if (order != null)
            {
                return Json(new
                {
                    success = true,
                    OrderPrice = order.Price,
                    OrderCount = order.Quantity,
                    OrderComent = order.Coment,
                    OrderDate = order.CreatedDate.ToString(),

                    //OrderCategotyName = order.Category.CategoryName,
                    //OrderCategotyId = order.CategoryId
                    //OrderCountryName = order.Country.CauntryName,
                    //OrderCountryId = order.CountryId,
                    //OrderCurrency = order.Country.CountryCurrency.CurrencyName,
                });


            }
            return Json(new
            {
                success = true,
                alertMesage = "Gonderdiyiniz Sifaris Tapilmadi"
            });
        }


        //Returns list of orders according to custumeer  admin used  when  creating a decleration for users
        [HttpPost]
        public async Task<JsonResult> CustumersOrders(int UserId)
        {
            var orders = await db.Orders.Where(w =>w.UserDbId == UserId && w.Ordered == false && w.isPaid == true).ToListAsync();
            List<OrderCountryJson> Userorders = new List<OrderCountryJson>();
            if (orders != null && orders.Count > 0)
            {
                foreach (var i in orders)
                {
                    OrderCountryJson jsOrder = new OrderCountryJson();
                    jsOrder.Id = i.Id;
                    jsOrder.OrderName = i.OrderName;
                    Userorders.Add(jsOrder);
                }

                return Json(orders);
            }
            return Json(orders);
        }

        //Returns list of orders according to country  admin used  when  creating a decleration for users
        [HttpPost]
        public async Task<JsonResult> CountryOrders(int CountryId, int UserId)
        {
            var CountryOrders = await db.Orders.Where(w => w.CountryId == CountryId && w.UserDbId == UserId && w.Ordered == false && w.isPaid == true).ToListAsync();
            List<OrderCountryJson> orders = new List<OrderCountryJson>();

            if (CountryOrders != null && CountryOrders.Count > 0)
            {
                foreach (var i in CountryOrders)
                {
                    OrderCountryJson jsOrder = new OrderCountryJson();
                    jsOrder.Id = i.Id;
                    jsOrder.OrderName = i.OrderName;
                    orders.Add(jsOrder);
                }

                return Json(orders);
            }
            return Json(orders);
        }


        /// <summary>
        /// /////////////////////////////////////////////
        /// </summary>

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}