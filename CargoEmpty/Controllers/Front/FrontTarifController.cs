using CargoEmpty.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.Front
{
    public class FrontTarifController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        // GET: FrontTarif
        public ActionResult Index()
        {
            ViewBag.Tarif = db.Tarifs.ToList();
            return View(db.Countries.Where(w=>w.IsActive==true).ToList());
        }
    }
}