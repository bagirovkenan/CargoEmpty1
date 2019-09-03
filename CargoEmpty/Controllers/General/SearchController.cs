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
    public class SearchController : MainController
    {
        // GET: Search
        public async Task<ActionResult> UserSearch(string id)
        {
            string userCod = id.ToUpper();
            var users = await db.Users.Where(w => (w.UserCod.ToString().ToUpper().IndexOf(userCod)) >= 0 || (w.FirstName.ToUpper().IndexOf(userCod)) >= 0 || (w.LastName.ToUpper().IndexOf(userCod)) >= 0).ToListAsync();
            List<UserSearch> jsonUsers = new List<UserSearch>();
            if (users != null)
            {
               
                foreach (var i in users)
                {
                    jsonUsers.Add(new UserSearch()
                    {
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        Id = i.Id,
                        UserCode = i.UserCod
                    });
                }
            }
            return PartialView(jsonUsers);
        }


        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<JsonResult> JsonUserSearch(string id)
        {
            string userCod = id.ToUpper();
            var users = await db.Users.Where(w => (w.UserCod.ToString().ToUpper().IndexOf(userCod)) >= 0 || (w.FirstName.ToUpper().IndexOf(userCod)) >= 0 || (w.LastName.ToUpper().IndexOf(userCod)) >= 0).ToListAsync();
            List<UserSearch> jsonUsers = new List<UserSearch>();
            if (users != null)
            {

                foreach (var i in users)
                {
                    jsonUsers.Add(new UserSearch()
                    {
                        FirstName = i.FirstName,
                        LastName = i.LastName,
                        Id = i.Id,
                        UserCode = i.UserCod
                    });
                }
            }
            return Json(jsonUsers);
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> BundelSearch(string id)
        {
            var bundels = await db.Bundels.Where(w => (w.TrackingNumber.ToString().IndexOf(id)) >= 0).ToListAsync();
            return PartialView(bundels);
        }
    }
}