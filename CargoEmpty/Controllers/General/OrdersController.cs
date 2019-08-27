using CargoEmpty.Controllers.Main;
using CargoEmpty.Models.General.Order;
using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.General
{
    public class OrdersController : MainController
    {
        // GET: Orders
        public ActionResult IndexUser()//bu action duzelt bundelleri duzeldennen sora sefdi cunki
        {
            var MyOrders = db.Orders.Where(w => w.UserDbId == UserSession.SessionId).ToList();
            var MyDecs = db.Declerations.Where(w => w.UserDbId == UserSession.SessionId && w.CreatAdmin==false).ToList();
            OrderIndexView OrderIndex = new OrderIndexView();
            foreach (OrderDb i in MyOrders)
            {
                OrderIndex.myOrders.Add(i);
            }
            //
            OrderIndex.AllOrdersCount = MyOrders.Count();
            OrderIndex.OrderedCount = MyOrders.Count(w => w.Ordered == true);
            OrderIndex.isNotOrdered = MyOrders.Count(w => w.Ordered == false);
            OrderIndex.isPaidCount = MyOrders.Count(w => w.isPaid == true);
            OrderIndex.isNotPaidCount = MyOrders.Count(w => w.isPaid == false);
            OrderIndex.isUrgentOrderCount = MyOrders.Count(w => w.isUrgent == true);
            OrderIndex.isNormalOrderCount = MyOrders.Count(w => w.isUrgent == false);

            ViewBag.orders = MyOrders;
            ViewBag.decs= MyDecs;
            ViewBag.Statuse = db.OrderStatuses.ToList();
            return View(OrderIndex);
        }


        //change statuse  my orders index

        public async Task<ActionResult> StatuseOrder(int id)
        {
            var orders = await db.Orders.Where(w => w.UserDbId == UserSession.SessionId && w.OrderStatusId == id).ToListAsync();
            ViewBag.Statuse = db.OrderStatuses.ToList();
            return PartialView(orders);
        }

        public ActionResult Create()
        {
            ViewBag.Country = db.Countries.Where(w => w.IsActive == true).ToList();
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateOrderView createOrder)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var country = db.Countries.FirstOrDefault(f => f.Id == createOrder.CountryId);
                    var user = db.Users.FirstOrDefault(f => f.Id == UserSession.SessionId);
                    if (country != null && user != null)
                    {
                        OrderDb order = new OrderDb();
                        order.CountryId = createOrder.CountryId;
                        order.UserDbId = user.Id;
                        for (var i = 0; i < createOrder.Link.Length; i++)
                        {

                            if (String.IsNullOrWhiteSpace(createOrder.Link[i]) ||
                            String.IsNullOrWhiteSpace(createOrder.Coment[i]) ||
                             createOrder.Price[i] <= 0 || createOrder.Quantity[i] < 1)
                            {
                                ViewBag.Categories = db.Categories.ToList();
                                ViewBag.Country = db.Countries.Where(w => w.IsActive == true).ToList();
                                return View();
                            }
                            else
                            {

                                order.OrderName = createOrder.OrderName[i];
                                order.Link = createOrder.Link[i];
                                order.Price = createOrder.Price[i]*createOrder.Quantity[i];
                                order.Quantity = createOrder.Quantity[i];
                                order.Coment = createOrder.Coment[i];
                                order.isUrgent = createOrder.isUrgent[i];
                                order.CategoryId = createOrder.CategoryId[i];
                                order.CreatedDate = DateTime.Now;
                                order.isPaid = false;

                                db.Orders.Add(order);
                                db.SaveChanges();
                            }

                        }
                    }
                    ViewBag.Categories = db.Categories.ToList();
                    ViewBag.Country = db.Countries.Where(w => w.IsActive == true).ToList();
                    return RedirectToAction("IndexUser");
                }
                ViewBag.Categories = db.Categories.ToList();
                ViewBag.Country = db.Countries.Where(w => w.IsActive == true).ToList();
                return View();
            }
            catch (Exception)
            {

                ViewBag.Country = db.Countries.Where(w => w.IsActive == true).ToList();
                ViewBag.Categories = db.Categories.ToList();
                return View();
            }
        }
        /// <summary>
        /// //////////////////////////////////////////////
        /// </summary>
        /// sifarisleri statuslarina gore sec ve gorsed
        [HttpPost]
        public ActionResult MyOrdersActions(int? id)//?????????
        {

            if (UserSession.SessionIsLogin == "true")
            {
            var MyOrders = db.Orders.Where(w => w.UserDbId == UserSession.SessionId);


                if (id == 100)
                {
                    var MyDecs = db.Declerations.Where(w => w.UserDbId == UserSession.SessionId && w.CreatAdmin == false).ToList();
                    ViewBag.decs = MyDecs;
                    ViewBag.Statuse = db.OrderStatuses.ToList();
                    return PartialView(MyOrders.ToList());
                }
                else if (id == 99)
                {
                    var MyDecs = db.Declerations.Where(w => w.UserDbId == UserSession.SessionId && w.CreatAdmin == false).ToList();
                    ViewBag.decs = MyDecs;
                    var IsPaid = MyOrders.Where(w => w.isPaid == true).ToList();
                    ViewBag.Statuse = db.OrderStatuses.ToList();
                    return PartialView(IsPaid);
                }
                else if (id == 98)
                {
                    var MyDecs = db.Declerations.Where(w => w.UserDbId == UserSession.SessionId && w.CreatAdmin == false).ToList();
                    ViewBag.decs = MyDecs;
                    var isNotPaid = MyOrders.Where(w => w.isPaid == false).ToList();
                    ViewBag.Statuse = db.OrderStatuses.ToList();
                    return PartialView(isNotPaid);

                }
                else if (id == 97)
                {
                    var MyDecs = db.Declerations.Where(w => w.UserDbId == UserSession.SessionId && w.CreatAdmin == false).ToList();
                    ViewBag.decs = MyDecs;
                    var isUrgentOrder = MyOrders.Where(w => w.isUrgent == true).ToList();
                    ViewBag.Statuse = db.OrderStatuses.ToList();
                    return PartialView(isUrgentOrder);
                }
                else if (id == 96)
                {
                    var MyDecs = db.Declerations.Where(w => w.UserDbId == UserSession.SessionId && w.CreatAdmin == false).ToList();
                    ViewBag.decs = MyDecs;
                    var isNormalOrder = MyOrders.Where(w => w.isUrgent == false).ToList();
                    ViewBag.Statuse = db.OrderStatuses.ToList();
                    return PartialView(isNormalOrder);
                }
                else if (id == 95)
                {
                    var MyDecs = db.Declerations.Where(w => w.UserDbId == UserSession.SessionId && w.CreatAdmin == false).ToList();
                    ViewBag.decs = MyDecs;
                    var isNormalOrder = MyOrders.Where(w => w.Ordered == false).ToList();
                    ViewBag.Statuse = db.OrderStatuses.ToList();
                    return PartialView(isNormalOrder);
                }

                else if (id == 94)
                {
                    var MyDecs = db.Declerations.Where(w => w.UserDbId == UserSession.SessionId && w.CreatAdmin == false).ToList();
                    ViewBag.decs = MyDecs;
                    var isNormalOrder = MyOrders.Where(w => w.Ordered == true).ToList();
                    ViewBag.Statuse = db.OrderStatuses.ToList();
                    return PartialView(isNormalOrder);
                }


                //}

            }
            return RedirectToAction("Index", "Home");
        }


        //////////////////////////
        ///edit Order

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var editdbOrder = await db.Orders.FirstOrDefaultAsync(f => f.Id == id && f.UserDbId == UserSession.SessionId);
                if (editdbOrder == null)
                {
                    return HttpNotFound();

                }
                else
                {
                    ViewBag.Category = await db.Categories.ToListAsync();
                    return PartialView(editdbOrder);

                }

            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditOder edit)
        {
            if (ModelState.IsValid)
            {
                OrderDb editOrder = await db.Orders.FirstOrDefaultAsync(f => f.Id == edit.Id && f.UserDbId == UserSession.SessionId);
                if (editOrder != null)
                {
                    editOrder.Link = edit.Link;
                    editOrder.OrderName = edit.OrderName;
                    editOrder.Price = edit.Price;
                    editOrder.Coment = edit.Coment;
                    editOrder.CategoryId = edit.CategoryId;

                    await db.SaveChangesAsync();
                    return RedirectToAction("IndexUser");
                }
                else
                {
                    return RedirectToAction("IndexUser");
                }
            }
            return RedirectToAction("IndexUser");
        }
        /// <summary>
        /// //////////////////////////////////////////////
        /// </summary>delete order in user account
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var delete = db.Orders.Find(id);
                if (delete != null)
                {
                    return PartialView(delete);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }
        ///delete order in user account
        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeletPost(int id)
        {
            var result = await DeleteOrder.Delete(id, db);
            if (result == true)
            {
                await db.SaveChangesAsync();
                return RedirectToAction("IndexUser");
            }
            else
            {
                return HttpNotFound();
            }
        }
        /// <summary>
        /// //////////////////////////////////////////////
        /// </summary> selected orders delete in user account
        [HttpPost]
        public async Task<ActionResult> SelectedDelete(int[] id)
        {
            foreach (var i in id)
            {
                var order = await db.Orders.FirstOrDefaultAsync(f => f.Id == i && f.UserDbId == UserSession.SessionId);
                if (order != null)
                {
                    db.Orders.Remove(order);
                }
            }
            await db.SaveChangesAsync();
            return RedirectToAction("IndexUser");

        }

        /// <summary>
        /// //////////////////////////////////////////////
        /// </summary> calculate orders price in create order in user account

        [HttpPost]
        public JsonResult CalculateOrderPrice(decimal price, int CurrencyId, int count)
        {
            var currency = db.Currencies.FirstOrDefault(f => f.Id == CurrencyId && f.IsActive == true);
            var bankSpending = db.Settings.FirstOrDefault().BankSpending;

            var TotalPrice = (price + (price * bankSpending / 100)) * count;
            var AZNPrice = TotalPrice * currency.Value;

            return Json(new { success = true, total = TotalPrice, AZN = AZNPrice });

        }
        //========================================================================================================================================================
        //////////orders  admin panel
        ///
        /// orders index in admin panel
        /// 
        public ActionResult IndexAdmin()
        {
            var Orders = db.Orders.OrderByDescending(o=>o.CreatedDate).ToList();
            OrderIndexView OrderIndex = new OrderIndexView();
            
            OrderIndex.AllOrdersCount = Orders.Count();
            OrderIndex.isExcuteOrder = Orders.Count(w => w.Executed == true);
            OrderIndex.isNotExcuteOrder = Orders.Count(w => w.Executed == false);
            OrderIndex.OrderedCount = Orders.Count(w => w.Ordered == true);
            OrderIndex.isNotOrdered = Orders.Count(w => w.Ordered == false);
            OrderIndex.isPaidCount = Orders.Count(w => w.isPaid == true);
            OrderIndex.isNotPaidCount = Orders.Count(w => w.isPaid == false);
            OrderIndex.isUrgentOrderCount = Orders.Count(w => w.isUrgent == true);
            OrderIndex.isNormalOrderCount = Orders.Count(w => w.isUrgent == false);

            ViewBag.orders = OrderIndex;
            ViewBag.Country = db.Countries.ToList();
            return View(Orders);
        }
        ///Delete order in admin panel order index
        ///
        public async Task<ActionResult> DeleteOrderInIndex(int id)
        {
            db.Orders.Remove(await db.Orders.FirstOrDefaultAsync(f => f.Id == id));
            await db.SaveChangesAsync();
            return RedirectToAction("IndexAdmin");
        }
        ///delete  order in custumer details
        public async Task<ActionResult> AdminDeleteOrder(DeleteOrder del)
        {
            var result = await DeleteOrder.Delete(del, db);
            if (result == true)
            {
                await db.SaveChangesAsync();
                return RedirectToAction("CustumerDetails", "User", new { id = del.UserId });
            }
            else
            {

                return HttpNotFound();
            }
        }
        ///delete  orders in custumer details
        public async Task<ActionResult> AdminAllDeleteOrder(int[] id, int UserId)
        {
            foreach (var i in id)
            {
                var del = new DeleteOrder() { OrderId = i, UserId = UserId };
                await DeleteOrder.Delete(del, db);
            }
            await db.SaveChangesAsync();
            return RedirectToAction("CustumerDetails", "User", new { id = UserId });
        }

        ///Admin Order Details
        ///there is not need for post method of this action only to see order
        public async Task<ActionResult> AdminDetailsOrder(int id)
        { 
            var order =  await db.Orders.FirstOrDefaultAsync(f => f.Id == id);
            return PartialView(order);
        }


      


        /// <summary>
        /// //////////////////////////////////////////////
        /// </summary> 
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