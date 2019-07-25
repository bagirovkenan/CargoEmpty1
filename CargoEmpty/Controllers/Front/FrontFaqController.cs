using CargoEmpty.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.Front
{
    public class FrontFaqController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        // GET: Faq
        public ActionResult Index()
        {
            var Faqs = db.Faqs.Where(w => w.IsActive == true).ToList();
            return View(Faqs);
        }
    }
}