using CargoEmpty.Controllers.Main;
using CargoEmpty.Models.Balance;
using CargoEmpty.Models.General;
using CargoEmpty.Models.General.Bundel;
using CargoEmpty.Models.Helper;
using CargoEmpty.Models.Pages.Calculate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.General
{
    public class BundelController : MainController
    {
        // GET: Default
        public async Task<ActionResult> Index()
        {
            var bundellist = await db.Bundels.ToListAsync();
            List<GetIndexBundel> GetIndex = new List<GetIndexBundel>();

            foreach (var j in bundellist)
            {
                GetIndex.Add(GetIndexBundel.Create(j));
            }

            ViewBag.status = await db.OrderStatuses.ToListAsync();
            ViewBag.counry = await db.Countries.ToListAsync();
            return View(GetIndex);
        }

        // Changing the Bundel country or status also changes the bundel table
        [HttpPost]
        public async Task<ActionResult> ChangeCountryInIndexBundel(BundelStatusAndCountry id)
        {
            List<GetIndexBundel> GetIndex = new List<GetIndexBundel>();
            if (id.StatusId == null && id.CountryId != null)
            {
                var bundellist = await db.Bundels.Where(w => w.CountryId == id.CountryId).ToListAsync();
                foreach (var j in bundellist)
                {
                    GetIndex.Add(GetIndexBundel.Create(j));
                }
            }
            else if (id.CountryId == null && id.StatusId != null)
            {
                var bundellist = await db.Bundels.Where(w => w.OrderStatusId == id.StatusId).ToListAsync();
                foreach (var j in bundellist)
                {
                    GetIndex.Add(GetIndexBundel.Create(j));
                }
            }
            else if (id.CountryId != null && id.StatusId != null)
            {
                var bundellist = await db.Bundels.Where(w => w.OrderStatusId == id.StatusId && w.CountryId == id.CountryId).ToListAsync();
                foreach (var j in bundellist)
                {
                    GetIndex.Add(GetIndexBundel.Create(j));
                }
            }
            else
            {
                var bundellist = await db.Bundels.ToListAsync();
                foreach (var j in bundellist)
                {
                    GetIndex.Add(GetIndexBundel.Create(j));
                }
            }
            ViewBag.status = await db.OrderStatuses.ToListAsync();
            ViewBag.counry = await db.Countries.ToListAsync();
            return PartialView(GetIndex);
        }

        public async Task<ActionResult> CreateIndex()
        {
            var Custumer = await db.Users.ToListAsync();
            return View(Custumer);
        }

        public async Task<ActionResult> Create(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var Custumer = await db.Users.FirstOrDefaultAsync(f => f.Id == id);
                if (Custumer != null)
                {
                    var Countries = await db.Countries.Where(w => w.IsActive == true).ToListAsync();
                    var CountryId = Countries[0].Id;
                    var Decleration = await db.Declerations.Where(w => w.UserDbId == id && w.CountryId == CountryId && w.Executed == false && w.CreatAdmin == false && w.IsForeignWarehouse == true).ToListAsync();
                    var Orders = await db.Orders.Where(w => w.UserDbId == id && w.CountryId == CountryId && w.Executed == false && w.isPaid == true && w.Ordered == true).ToListAsync();
                    GetCreateBundel list = new GetCreateBundel();
                    list.Id = Custumer.Id;
                    list.FirstName = Custumer.FirstName;
                    list.LastName = Custumer.LastName;
                    list.UserCod = Custumer.UserCod;
                    list.Balance = Custumer.Balance;
                    list.BonuceBalance = Custumer.BonusBalance;

                    Task task1 = Task.Run(() =>
                    {
                        foreach (var i in Orders)
                        {
                            list.Orders.Add(i);
                        }
                    });

                    Task task2 = Task.Run(() =>
                    {
                        foreach (var l in Decleration)
                        {
                            list.Declerations.Add(l);
                        }
                    });
                    Task task3 = Task.Run(() =>
                    {
                        foreach (var j in Countries)
                        {
                            list.Countries.Add(j);
                        }
                    });
                    Task.WaitAll(task1, task2, task3);
                    return View(list);
                }
                else
                {
                    return HttpNotFound();
                }
            }

        }
        [HttpPost]
        public ActionResult Create(PostCreateBundel bundel)//balans emeliyyati da yazilmalidi
        {
            if (ModelState.IsValid)
            {


                BundelsDb bundelDb = new BundelsDb();
                bundel.ViewFromDb(bundelDb);
                bundelDb.OrderStatusId = 2;
                db.Bundels.Add(bundelDb);
                db.SaveChanges();
                if (bundel.orderId != null && bundel.orderId.Length > 0)
                {
                    foreach (var i in bundel.orderId)
                    {
                        BundelAddOrder.AddOrder(i, bundelDb.Id, db);
                    }
                }
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }

        //Change bundel Statuse Modal
        [HttpPost]
        public ActionResult ChangeStatusModal(int id)
        {
            var status = db.OrderStatuses.ToList();
            ViewBag.bundelId = db.Bundels.FirstOrDefault(f => f.Id == id).Id;
            return PartialView(status);
        }

        //Change bundel Statuse//?????duzgun deyil mellimnen sorusuh
        [HttpPost]
        public ActionResult ChangeStatus(int OrderStatusId, int Id)
        {

            var bundel = db.Bundels.FirstOrDefault(b => b.Id == Id);

            if (bundel != null)
            {
                {
                    bundel.OrderStatusId = OrderStatusId;
                  
                        foreach (var i in bundel.User.OrderDbs)
                        {
                            if (i.BundelsDbId == bundel.Id)
                            {
                                i.OrderStatusId = OrderStatusId;
                            }
                        }
                 
                    
                        foreach (var i in bundel.User.DeclerationDbs)
                        {
                            if (i.BundelsDbId == bundel.Id)
                            {
                                i.OrderStatusId = OrderStatusId;
                            }
                        }
                   

                    if (OrderStatusId == 2)
                    {
                        bundel.CreateDate = DateTime.Now;
                    }
                    else if (OrderStatusId == 3)
                    {
                        bundel.OnWay = DateTime.Now;
                    }
                    else if (OrderStatusId == 5)
                    {
                        bundel.InBaku = DateTime.Now;
                    }
                    else if (OrderStatusId == 8)
                    {
                        bundel.DeliveryTime = DateTime.Now;
                    }
                   
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //bundel status  Foreign Warehouse get
        public ActionResult ForeignWarehouse(int id)
        {
            var bundel = db.Bundels.FirstOrDefault(f => f.Id == id);
            return PartialView(bundel);
        }
        //edit the bundel BundelEdit
        public ActionResult BundelEdit(int id)
        {
            var bundel = db.Bundels.FirstOrDefault(f => f.Id == id);
            return PartialView(bundel);
        }

        //bundel status  Foreign Warehouse   post
        [HttpPost]
        public ActionResult ForeignWarehouse(foreignWarehouse bundel)
        {
            if (ModelState.IsValid)
            {
                var Bundel = db.Bundels.FirstOrDefault(f => f.Id == bundel.Id);
                if (Bundel != null)
                {
                    for (var i = 0; i < bundel.ProductName.Length; i++)
                    {
                        int? prId = bundel.ProductId[i];
                        var PR = db.BundelProducts.FirstOrDefault(f => f.Id == prId);

                        if (PR == null)
                        {
                            BundelProducts Bp = new BundelProducts()
                            {
                                BundelsDbId = bundel.Id,
                                ProductName = bundel.ProductName[i],
                                CountryName = bundel.CountryName[i],
                                HarmonicCode = bundel.HarmonicCode[i],
                                CustomsValue = bundel.CustomsValue[i]
                            };
                            db.BundelProducts.Add(Bp);
                        }
                        else
                        {
                            PR.ProductName = bundel.ProductName[i];
                            PR.CountryName = bundel.CountryName[i];
                            PR.HarmonicCode = bundel.HarmonicCode[i];
                            PR.CustomsValue = bundel.CustomsValue[i];
                        }
                    }
                    bundel.ViewFromDb(Bundel);
                    bundel.DeliveryPrice = AddBalance.outPrice(bundel.DeliveryPrice);
                    AddBalance.ChangeBalance(Bundel.User, bundel.DeliveryPrice, db);
                    Bundel.User.BonusBalance += AddBalance.AddBonus(bundel.DeliveryPrice);
                    if (bundel.InvoiceFile != null && bundel.InvoiceFile.ContentLength > 0)
                    {
                        Bundel.InvoicePath = bundel.SaveImageFileGeneral(bundel.InvoiceFile, "/File/BundelInvoice");
                    }
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return HttpNotFound();

                }
            }
            else
            {
                return RedirectToAction("Index");
            }


        }
        //Change the status of the bundle on the external storage

        public ActionResult EditForeignWarehouseBundelStatuse(int id)
        {
            var bundel = db.Bundels.FirstOrDefault(f => f.Id == id);
            ViewBag.BundelStatuse = db.OrderStatuses.ToList();
            return PartialView(bundel);
        }

        // bill btn click info bundel
        public async Task<ActionResult> BundelBill(int id)
        {
            BundelsDb bundel = await db.Bundels.FirstOrDefaultAsync(f => f.Id == id);
            if (bundel != null)
            {
                return PartialView(bundel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //bundel label
        // bill btn click info bundel
        public async Task<ActionResult> BundelLabel(int id)
        {
            BundelsDb bundel = await db.Bundels.Include(l => l.BundelProducts).FirstOrDefaultAsync(f => f.Id == id);
            if (bundel != null)
            {
                ViewBag.set = db.Settings.FirstOrDefault();
                return PartialView(bundel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        //Calculate Delivare Priec
        public JsonResult CalculatePrice(FrontCalculateBundle model)
        {
            decimal totalAZN = 0;
            decimal totalUSD = 0;
            if (model.BundleLenght >= 100)
            {
                totalUSD = SelectTarif.CalculateVolume(model);
            }
            else
            {
                totalUSD = SelectTarif.CalculateWeight(model);
            }
            totalAZN = totalUSD * db.Settings.FirstOrDefault().USD;

            return Json(new { success = "true", responseUSD = totalUSD, responseAZN = totalAZN });
        }


        //Delete Bundel
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var bundel = db.Bundels.FirstOrDefault(f => f.Id == id);
            if (bundel == null)
            {
                return Json(new { success = "false" });
            }
            else
            {
                db.Bundels.Remove(bundel);
                db.SaveChanges();
                return Json(new { success = "true" });
            }
        }

        //delete bundelproduct
        public async Task<JsonResult> DeleteProduct(int id)
        {
            var pr = await db.BundelProducts.FirstOrDefaultAsync(f => f.Id == id);
            if (pr != null)
            {
                db.BundelProducts.Remove(pr);
                await db.SaveChangesAsync();
                return Json(new { success = "true" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = "false" }, JsonRequestBehavior.AllowGet);
            }
        }

        //When  changed the country on the bundel creation page,  changed the order and decleration tables
        [HttpPost]
        public async Task<ActionResult> ChangeCountryOrder(ChangeCountry id)
        {

            var Orders = await db.Orders.Where(w => w.UserDbId == id.userId && w.CountryId == id.CountryId && w.Executed == false && w.isPaid == true && w.Ordered == true).ToListAsync();
            return PartialView(Orders);
        }

        [HttpPost]
        public async Task<ActionResult> ChangeCountryDecleration(ChangeCountry id)
        {
            var Decleration = await db.Declerations.Where(w => w.UserDbId == id.userId && w.CountryId == id.CountryId && w.Executed == false && w.CreatAdmin == false && w.IsForeignWarehouse == true).ToListAsync();
            return PartialView(Decleration);
        }

        //check the price on the create bundel modal 
        //ShopInfo
        public JsonResult CheckThePrice(long price, int UserId)
        {
            var Balance = db.Users.FirstOrDefault(f => f.Id == UserId).Balance;
            if (price <= Balance)
            {
                return Json(new { success = "true" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = "false" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Show Shop
        public async Task<JsonResult> ShowShop(string ShopName)
        {
            var shop = await db.Shops.FirstOrDefaultAsync(f => f.ShopName.ToUpper() == ShopName.ToUpper());
            if (shop != null)
            {
                return Json(new { success = "true", id = shop.Id, shopName = shop.ShopName, companyName = shop.CompanyName }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = "false" }, JsonRequestBehavior.AllowGet);
            }
        }

        //Shop Info

        public async Task<JsonResult> ShopInfo(int id)
        {
            var shop = await db.Shops.FirstOrDefaultAsync(f => f.Id == id);
            ShopInfo info = new ShopInfo();
            if (shop != null)
            {
                shop.ViewFromDb(info);
                info.Success = true;
                return Json(info, JsonRequestBehavior.AllowGet);
            }
            else
            {
                info.Success = false;
                return Json(info, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> DeclerationInfo(int id)
        {
            var dec = await db.Declerations.FirstOrDefaultAsync(f => f.Id == id);
            return PartialView(dec);
        }
    }
}