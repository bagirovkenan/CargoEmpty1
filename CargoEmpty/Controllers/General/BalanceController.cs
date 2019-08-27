using CargoEmpty.Controllers.Main;
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
    }
}