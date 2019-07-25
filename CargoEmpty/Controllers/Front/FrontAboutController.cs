using CargoEmpty.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.Front
{
    public class FrontAboutController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        // GET: About
        public ActionResult Index()
        {
            //ViewBag.Menyu = db.Menyus.ToList();
            return View(db.Abouts.FirstOrDefault(w=>w.IsActive==true));

        }
    }
}