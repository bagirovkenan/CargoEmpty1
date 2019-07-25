using CargoEmpty.Context;
using CargoEmpty.Models.Helper;
using CargoEmpty.Models.Pages.Menyu;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.Pages
{
    public class MenyuController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        // GET: Menyu
        public ActionResult Index()
        {
            return View(db.Menyus.ToList());
        }

        [HttpPost]
        public async Task<ActionResult> Create(Menyu create)
        {
            if (ModelState.IsValid)
            {
                db.Menyus.Add(create);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var EditDb = await db.Menyus.FindAsync(id);
                if (EditDb == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return PartialView(EditDb);
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Menyu edit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(edit).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return PartialView(edit);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var EditDb = await db.Menyus.FindAsync(id);
                if (EditDb == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return PartialView(EditDb);
                }
            }
        }

        [HttpPost, ActionName("Delete")]
       
        public ActionResult DeleteConfirmed(int id)
        {
            Menyu menyu = db.Menyus.Find(id);
            db.Menyus.Remove(menyu);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


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
                    var ActivMenyu = db.Menyus.FirstOrDefault(f => f.Id == i.id);
                    if (ActivMenyu == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        ActivMenyu.IsActive = ChangeIsActivFromIndex.ChangeStatus(i.status);
                    }
                }
                db.SaveChanges();
                return Json(new { success = true, responseText = "Emeliyyat Ugurlu Oldu !" });

            }
        }

        ////////////////////////////////////////////////////////////////////////
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