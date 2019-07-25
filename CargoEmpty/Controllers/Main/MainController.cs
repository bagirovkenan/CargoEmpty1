using CargoEmpty.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.Main
{
    public class MainController : Controller
    {
        protected CargoDbContext db = new CargoDbContext();
        // GET: Main
        public ActionResult MainIndex()
        {
            return View();
        }

        ////////////////////////////////////////  
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