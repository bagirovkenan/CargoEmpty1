using CargoEmpty.Controllers.Main;
using CargoEmpty.Models.General.User;
using CargoEmpty.Models.Helper;
using CargoEmpty.Models.Pages.MyAcount;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.Front
{
    public class MyAccountController : MainController
    {
        // GET: MyAccount
        public async  Task<ActionResult> Index()
        {
            var Account = new MyAccountHome();
            UserDb UserSession = (UserDb)Session["User"];

            if (Session["isLogin"] != null)
            {
                var Addresses = await db.MyAddresses.ToListAsync();
                var User = await db.Users.FirstOrDefaultAsync(f => f.Id == UserSession.Id);
              
                User.ViewFromDb(Account.User);
                foreach(var i in Addresses)
                {
                    if (i.Country.IsActive==true)
                    {
                        Account.MyAdress.Add(i);
                    }                
                }
                
                ViewBag.Country = await db.Countries.Where(w => w.IsActive == true).ToListAsync();
                ViewBag.Category = await db.Categories.ToListAsync();
                return View(Account);
            }
           
            return RedirectToAction("Index","Home");
        }


        public ActionResult MyAccountActions()
        {
            return PartialView();
        }


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