using CargoEmpty.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.Front
{
    public class FrontNewsController : Controller
    {
        private CargoDbContext db = new CargoDbContext(); 
        // GET: FrontNews
        public ActionResult Index()
        {
            
            return View(db.News.Where(w=>w.IsActive==true).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            else
            {
                var News = db.News.FirstOrDefault(f => f.Id == id);
                if (News==null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ViewBag.News = db.News.ToList();
                    return View(News);
                }
            }
        }
    }
}