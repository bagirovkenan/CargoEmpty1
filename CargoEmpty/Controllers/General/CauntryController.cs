using CargoEmpty.Context;
using CargoEmpty.Models.General;
using CargoEmpty.Models.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.General
{
    public class CauntryController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        // GET: Cauntry
        public ActionResult Index()
        {
            ViewBag.Currency = db.Currencies.ToList();
            return View(db.Countries.ToList());

       
        }
        [HttpPost]
        public async Task<ActionResult> Create(Country create)
        {
            if (ModelState.IsValid)
            {
                if (create.CountryFlag != null && create.CountryFlag.ContentLength > 0)
                {
                    create.SaveImageFile(create.CountryFlag, "/Image/Country");
                }
                else
                {
                    create.ImagePath = null;
                }
                create.IsActive = Convert.ToBoolean(create.Activ);
                db.Countries.Add(create);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return PartialView(create);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var CountryEdit = await db.Countries.FindAsync(id);
                ViewBag.Currency = db.Currencies.ToList();
                return PartialView(CountryEdit);
            }
        }

        [HttpPost]
        public ActionResult Edit(Country EditCountry)
        {
            if (ModelState.IsValid)
            {
                var editDbCountry = db.Countries.FirstOrDefault(f => f.Id == EditCountry.Id);
                if (editDbCountry == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    if (EditCountry.CountryFlag != null && EditCountry.CountryFlag.ContentLength > 0)
                    {
                        editDbCountry.SaveImageFile(EditCountry.CountryFlag, "/Image/Country");
                    }
                    editDbCountry.IsActive = Convert.ToBoolean(EditCountry.Activ);
                    editDbCountry.CauntryName = EditCountry.CauntryName;
                    editDbCountry.CurrencyId = EditCountry.CurrencyId;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return HttpNotFound();
            }
        }

        public async Task<ActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    var deletCountry = await db.Countries.FirstOrDefaultAsync(f => f.Id == id);
                    if (deletCountry == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        return PartialView(deletCountry);
                    }
                }
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            try
            {
                var deletCountry = db.Countries.FirstOrDefault(f => f.Id == id);
                var imgName = Path.GetFileName(deletCountry.ImagePath);
                var imgPath = ProsesImageFile.ImagePath(imgName, "/Image/Country");
                if (System.IO.File.Exists(imgPath))
                {
                    ProsesImageFile.DeleteImageFile(imgPath);
                }
                db.Countries.Remove(deletCountry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return HttpNotFound();

            }
        }
        ///////////////////////////////////////
        ///
        [HttpPost]
        public ActionResult IsActiv(ChangeActivStatus[] id)
        {
            if (id == null)
            {
                return Json(new { success = true, responseText = "Hec Bir Deyisiklik Olmadi!" });

            }
            else
            {
                foreach (var i in id)
                {
                    var ActivCountry = db.Countries.FirstOrDefault(f => f.Id == i.id);
                    if (ActivCountry == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        ActivCountry.IsActive = ChangeIsActivFromIndex.ChangeStatus(i.status);
                    }
                }
                db.SaveChanges();
                return Json(new { success = true, responseText = "Emeliyyat Ugurlu Oldu !" });

            }
        }

        ////////////////////////////////////
        ///
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