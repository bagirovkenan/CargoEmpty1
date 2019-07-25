using CargoEmpty.Context;
using CargoEmpty.Models.Helper;
using CargoEmpty.Models.Pages.Calculate;
using CargoEmpty.Models.Pages.Menyu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.Front
{
    public class HomeController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        // GET: Home
        public ActionResult Index()
        {
            var Carusels = db.Carusels.Where(w => w.IsActive == true).ToList();
            ViewBag.News = db.News.Where(w=>w.IsActive==true).OrderByDescending(o => o.NewsCreateDate).Take(6).ToList().ToList();
            ViewBag.Country = db.Countries.Where(w => w.IsActive == true).ToList();
            //ViewBag.Menyu = db.Menyus.ToList();
            return View(Carusels);
        }

        [HttpPost]
        public JsonResult Calculate(FrontCalculateBundle model)
        {
            decimal totalUSD;
            decimal totalAZN;
            if (model.BundleLenght>=100)
            {
                totalUSD = SelectTarif.CalculateVolume(model);
            }
            else
            {
                totalUSD = SelectTarif.CalculateWeight(model);
            }
            totalAZN = totalUSD * db.Settings.FirstOrDefault().USD;

            return Json(new { success = true, responseUSD = totalUSD, responseAZN = totalAZN });
        }


        public ActionResult Header()
        {
            var setting = db.Settings.FirstOrDefault();
            var menyuItems = db.Menyus.Where(w => w.IsActive == true).ToList();

            HeaderFooter HF = new HeaderFooter();
            setting.ViewFromDb(HF);
            foreach (var i in menyuItems)
            {
                HF.NavItems.Add(i);
            }           
            return PartialView(HF);
        }

        public ActionResult Footer()
        {
            var setting = db.Settings.FirstOrDefault();
          
            HeaderFooter HF = new HeaderFooter();
            setting.ViewFromDb(HF);

            return PartialView(HF);
        }
    }
}