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
    public class CurrencyController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        // GET: Currency
        public ActionResult Index()
        {
            return View(db.Currencies.ToList());
        }
        
        [HttpPost]
        public async Task<ActionResult> Create(Currency create)
        {
            if(create.CurrencyName!=null)
            {
                create.IsActive = Convert.ToBoolean(create.Activ);
                db.Currencies.Add(create);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            else
            {
               var editDb = await db.Currencies.FindAsync(id);
                if (editDb==null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return PartialView(editDb);                  
                }
            }
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Currency edit)
        {
            if (ModelState.IsValid)
            {
                edit.IsActive = Convert.ToBoolean(edit.Activ);
                db.Entry(edit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return PartialView();
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
                    var deletCurrency= await db.Currencies.FirstOrDefaultAsync(f => f.Id == id);
                    if (deletCurrency == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        return PartialView(deletCurrency);
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
                var deletCurrency = db.Currencies.FirstOrDefault(f => f.Id == id);
                db.Currencies.Remove(deletCurrency);
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
                    var ActivCurrency = db.Currencies.FirstOrDefault(f => f.Id == i.id);
                    if (ActivCurrency == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        ActivCurrency.IsActive = ChangeIsActivFromIndex.ChangeStatus(i.status);
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