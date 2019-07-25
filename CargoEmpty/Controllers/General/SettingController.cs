using CargoEmpty.Context;
using CargoEmpty.Models.App;
using CargoEmpty.Models.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.General
{
    public class SettingController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        // GET: Setting
        public ActionResult Index()
        {

            return View(db.Settings.FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(Setting edit)
        {
            if (ModelState.IsValid)
            {
                if (edit.TitleImage != null && edit.TitleImage.ContentLength > 0)
                {
                    var imgName = ProsesImageFile.FileName(edit.TitleImage);
                    var ImagePath = ProsesImageFile.ImagePath(imgName, "/Image/Settings");
                    edit.TitleImage.SaveAs(ImagePath);
                    edit.TitleImagePath = "/Image/Settings/"+ imgName;
                }
                db.Entry(edit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Crete()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Setting create)
        {
            if (ModelState.IsValid)
            {
                if (create.TitleImage != null && create.TitleImage.ContentLength > 0)
                {
                    var imgName  = ProsesImageFile.FileName(create.TitleImage);
                    var ImagePath = ProsesImageFile.ImagePath(imgName, "/Image/Settings");
                    create.TitleImage.SaveAs(ImagePath);
                    create.TitleImagePath = "/Image/Settings/"+imgName;
                }
                else
                {
                    create.TitleImagePath = null;
                }
                db.Settings.Add(create);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }
    }
}