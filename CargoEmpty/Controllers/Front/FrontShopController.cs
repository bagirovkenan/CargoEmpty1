using CargoEmpty.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.Front
{
    public class FrontShopController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        // GET: FrontShop
        public ActionResult Index()
        {
            var Shops = db.Shops.Where(w => w.IsActive == true).ToList();
            ViewBag.Category = db.Categories.ToList();
            return View(Shops);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var Categoryshops = db.Shops.Where(w =>w.CategoryId==id && w.IsActive == true).ToList();
                ViewBag.Category = db.Categories.ToList();
                return View(Categoryshops);
            }
           

        }
    }
}