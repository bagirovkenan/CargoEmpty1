using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CargoEmpty.Context;
using CargoEmpty.Models.Helper;
using CargoEmpty.Models.Pages.About;

namespace CargoEmpty.Controllers.Pages
{
    public class AboutController : Controller
    {
        private CargoDbContext db = new CargoDbContext();

        // GET: AboutDbs
        public ActionResult Index()
        {
            return View(db.Abouts.ToList());
        }

        // GET: AboutDbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AboutDbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,ContentText,Activ")] AboutDb aboutDb)
        {
            if (ModelState.IsValid)
            {
                aboutDb.IsActive = Convert.ToBoolean(aboutDb.Activ);
                aboutDb.CreateDate = DateTime.Now;
                db.Abouts.Add(aboutDb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aboutDb);
        }

        // GET: AboutDbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutDb aboutDb = db.Abouts.Find(id);
            if (aboutDb == null)
            {
                return HttpNotFound();
            }
            return View(aboutDb);
        }

        // POST: AboutDbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,ContentText,Activ")] AboutDb aboutDb)
        {
            if (ModelState.IsValid)
            {
                aboutDb.IsActive = Convert.ToBoolean(aboutDb.Activ);
                aboutDb.CreateDate = DateTime.Now;
                db.Entry(aboutDb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutDb);
        }

        // GET: AboutDbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutDb aboutDb = db.Abouts.Find(id);
            if (aboutDb == null)
            {
                return HttpNotFound();
            }
            return PartialView(aboutDb);
        }

        // POST: AboutDbs/Delete/5
        [HttpPost, ActionName("Delete")]
      
        public ActionResult DeleteConfirmed(int id)
        {
            AboutDb aboutDb = db.Abouts.Find(id);
            db.Abouts.Remove(aboutDb);
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
                    var ActivAb = db.Abouts.FirstOrDefault(f => f.Id == i.id);
                    if (ActivAb == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        ActivAb.IsActive = ChangeIsActivFromIndex.ChangeStatus(i.status);
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
