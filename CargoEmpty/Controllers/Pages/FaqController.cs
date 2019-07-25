using CargoEmpty.Context;
using CargoEmpty.Models.Helper;
using CargoEmpty.Models.Pages.Faq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.Pages
{
    public class FaqController : Controller
    {
        private CargoDbContext db = new CargoDbContext();

        // GET: Faq
        public async Task<ActionResult> Index()
        {
            var Faqs = await db.Faqs.OrderByDescending(o => o.FaqCreateDate).ToListAsync();
            return View(Faqs);
        }

        public async Task<ActionResult> FrontIndex()
        {
            var Faqs = await db.Faqs.Where(w => w.IsActive == true).OrderByDescending(o => o.FaqCreateDate).ToListAsync();
            return View(Faqs);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public async Task<ActionResult> Create(FaqDb createFaq)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    createFaq.IsActive = Convert.ToBoolean(createFaq.Activ);
                    createFaq.FaqCreateDate = DateTime.Now;
                    db.Faqs.Add(createFaq);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(createFaq);
                }
            }
            catch
            {
                return HttpNotFound();
            }

        }
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var EditFaq = await db.Faqs.FirstOrDefaultAsync(f => f.Id == id);
                if (EditFaq == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(EditFaq);
                }
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(FaqDb EditFaq)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EditFaq.FaqCreateDate = DateTime.Now;
                    EditFaq.IsActive = Convert.ToBoolean(EditFaq.Activ);
                    db.Entry(EditFaq).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(EditFaq);
                }
            }
            catch (Exception)
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
                    var deletFaq = await db.Faqs.FirstOrDefaultAsync(f => f.Id == id);
                    if (deletFaq == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        return PartialView(deletFaq);
                    }
                }
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public async Task<ActionResult> DeletePost(int? id)
        {
            try
            {
               
                    var deletFaq = await db.Faqs.FirstOrDefaultAsync(f => f.Id == id);
                    db.Faqs.Remove(deletFaq);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
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
                foreach(var i in id)
                {
                    var ActivFaq = db.Faqs.FirstOrDefault(f => f.Id == i.id);
                    if (ActivFaq==null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        ActivFaq.IsActive = ChangeIsActivFromIndex.ChangeStatus(i.status);                     
                    }
                }
                db.SaveChanges();
                return Json(new { success = true, responseText = "Emeliyyat Ugurlu Oldu !" });

            }
        }




        /// ///////////////////////////////////

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
