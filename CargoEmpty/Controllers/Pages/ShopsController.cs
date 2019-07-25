using CargoEmpty.Context;
using CargoEmpty.Models.Helper;
using CargoEmpty.Models.Pages.Shop;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.Pages
{
    public class ShopsController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        // GET: Shops
        public ActionResult Index()
        {
            var Shopslist = db.Shops.ToList();
            return View(Shopslist);
        }


        public ActionResult Create()
        {
            ViewBag.Category = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(ShopView shopView)
        {
            if (ModelState.IsValid)
            {
                ShopDb shopDb = new ShopDb();
                shopView.ViewFromDb(shopDb);
                if (shopView.ShopImage != null && shopView.ShopImage.ContentLength > 0)
                {
                    shopDb.SaveImageFile(shopView.ShopImage, "/Image/Shops");
                }
                else
                {
                    shopDb.ImagePath = null;
                }
                shopDb.IsActive = Convert.ToBoolean(shopView.Activ);
                db.Shops.Add(shopDb);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(shopView);
        }


        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var EditShop = await db.Shops.FindAsync(id);
                ViewBag.Category = await db.Categories.ToListAsync();
                return View(EditShop);
            }
        }


        [HttpPost]

        public  ActionResult Edit(ShopView editShop)
        {
            if (ModelState.IsValid)
            {
                var editDbShop =  db.Shops.FirstOrDefault(f => f.Id == editShop.Id);
                if (editDbShop == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    if (editShop.ShopImage != null && editShop.ShopImage.ContentLength > 0)
                    {
                        editDbShop.SaveImageFile(editShop.ShopImage, "/Image/Shops");
                    }
                    editShop.ViewFromDb(editDbShop);
                    editDbShop.IsActive = Convert.ToBoolean(editShop.Activ);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return HttpNotFound();
            }
        }
        ///////////////////////////////////////
        ///

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
                    var deletShop = await db.Shops.FirstOrDefaultAsync(f => f.Id == id);
                    if (deletShop == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        return PartialView(deletShop);
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
                var deletShop = db.Shops.FirstOrDefault(f => f.Id == id);
                var imgName = Path.GetFileName(deletShop.ImagePath);
                var imgPath = ProsesImageFile.ImagePath(imgName, "/Image/Shops");
                ProsesImageFile.DeleteImageFile(imgPath);
                db.Shops.Remove(deletShop);
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
                    var ActivShop = db.Shops.FirstOrDefault(f => f.Id == i.id);
                    if (ActivShop == null)
                    {
                        return HttpNotFound();
                    }
                    else
                    {
                        ActivShop.IsActive = ChangeIsActivFromIndex.ChangeStatus(i.status);
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