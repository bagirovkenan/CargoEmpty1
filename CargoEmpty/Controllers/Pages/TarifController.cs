using CargoEmpty.Context;
using CargoEmpty.Models.Helper;
using CargoEmpty.Models.Pages.Tarif;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.Pages
{
    public class TarifController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        // GET: Tarif
        public ActionResult Index()
        {
            ViewBag.Country = db.Countries.ToList();
            ViewBag.Currebcy = db.Currencies.ToList();
            return View(db.Tarifs.ToList());
        }
        [HttpPost]
        public ActionResult Create(Tarif create)
        {
            if (ModelState.IsValid)
            {
                create.IsActive = Convert.ToBoolean(create.Activ);
                db.Tarifs.Add(create);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            else
            {
                var editdb = db.Tarifs.Find(id);
                if (editdb==null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ViewBag.Country = db.Countries.ToList();
                    return PartialView(editdb);
                }
            }
        }
        [HttpPost]
        public ActionResult Edit(Tarif edit)
        {
            
            if (ModelState.IsValid) 
            {
             
                    edit.IsActive = Convert.ToBoolean(edit.Activ);
                    db.Entry(edit).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                
                
            }
            return PartialView(edit);
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarif tarifDb = db.Tarifs.Find(id);
            if (tarifDb == null)
            {
                return HttpNotFound();
            }
            return PartialView(tarifDb);
        }

        // POST: AboutDbs/Delete/5
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            Tarif tarifDb = db.Tarifs.Find(id);
            db.Tarifs.Remove(tarifDb);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        ////////////////////////////////////////////////////////////////////////////////
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
                    var ActivTr = db.Tarifs.FirstOrDefault(f => f.Id == i.id);
                    if (ActivTr == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        ActivTr.IsActive = ChangeIsActivFromIndex.ChangeStatus(i.status);
                    }
                }
                db.SaveChanges();
                return Json(new { success = true, responseText = "Emeliyyat Ugurlu Oldu !" });

            }
        }
        /// ////////////////////////////////////////////////////////////////////////////

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