using CargoEmpty.Controllers.Main;
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
    public class BalanceController : MainController
    {
        // GET: Balance
        public async Task<ActionResult> Details(int id)
        {
            var UserBalance = await db.Users.FirstOrDefaultAsync(f => f.Id == id);
            return View(UserBalance);
        }

        public async Task<ActionResult> UserBalance(int? id)
        {
            UserDb UserSession = (UserDb)Session["User"];

            if (id!=null && UserSession.Id == id )
            {
                return View(await db.BalanceOperators.Where(w => w.UserDbId == id).ToListAsync());
            }
            else
            {
                return RedirectToAction("Index", "MyAccount");
            }
        }

        public async Task<ActionResult> Paid(int? id)
        {
            var order = await db.Orders.FirstOrDefaultAsync(f => f.Id == id);
            return View(order);
        }

        [HttpPost]
        public async Task<ActionResult> Paid()
        {
            var order = await db.Orders.FirstOrDefaultAsync();
            return View(order);
        }
    }
}