using CargoEmpty.Context;
using CargoEmpty.Models.General.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.General
{
    public class UserController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        public ActionResult UsersIndex()
        {
            ViewBag.UserRole = db.UserRoles.ToList();
            ViewBag.Role = db.UserRoles.OrderByDescending(o => o.Id).ToList();
            return View(db.Users.ToList());
        }
        ///////// UserEdit GEt/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public ActionResult EditUser(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var editUser = db.Users.Find(Id);
                if (editUser == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ViewBag.UserRole = db.UserRoles.ToList();
                    ViewBag.Rols = db.Roles.ToList();
                    return View(editUser);
                }
            }
        }
        ////////////////////////////////////////////////////////////user edit post
        [HttpPost]
        public ActionResult EditUser(AdminEditUser user)
        {

            if (ModelState.IsValid)
            {
                string id;
                string IsActiv;
                if (user.UserRoles != null && user.UserRoles.Length > 0)
                {
                    foreach (var i in user.UserRoles)
                    {

                        id = i.Substring(i.IndexOf("-") + 1);
                        IsActiv = i.Substring(0, i.Length - id.Length - 1);

                        if (IsActiv == "Activ")
                        {
                            var item = db.UserRoles.FirstOrDefault(f => f.UserDbId == user.Id && f.RoleId.ToString() == id);
                            if (item == null)
                            {
                                db.UserRoles.Add(new UserRole() { UserDbId = user.Id, RoleId = int.Parse(id) });
                            }
                        }
                        else
                        {
                            var item = db.UserRoles.FirstOrDefault(f => f.Id.ToString() == id);
                            if (item != null)
                            {
                                db.UserRoles.Remove(item);
                            }
                        }


                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction("UsersIndex");
        }
        // delete get
        public ActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            else
            {
                UserDb delete = db.Users.Find(Id);
                if (delete == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ViewBag.UserRole = db.UserRoles.ToList();
                    return View(delete);
                }
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeletePost(int Id)
        {
            UserDb delete = db.Users.Find(Id);
            db.Users.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("UsersIndex");
        }
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //ET: Custumers
        public ActionResult IndexCustumers()
        {

            return View(db.Users.ToList());
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Custumers Details Admin Panel
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> CustumerDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var details = await db.Users.FirstOrDefaultAsync(f => f.Id == id);
                if (details == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View(details);
                }
            }

        }




        ////Custumers index Edit Delete Heleki Istifade elemirem 
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ////////////////////////custuemr edit get heleki lazim deyil  ///////////////////////////////////////////////////////////////////////////////////////////////
        //public ActionResult EditCustumers(int? Id)
        //{
        //    if (Id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    else
        //    {
        //        var editUser = db.Users.Find(Id);
        //        if (editUser == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        else
        //        {

        //            ViewBag.UserRrols = db.UserRoles.ToList();
        //            return View(editUser);
        //        }
        //    }
        //}
        //////////////////////////custumer edit post heleki lazim deyil
        //[HttpPost]
        //public ActionResult EditCustumers(AdminEditUser user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var EditUser = db.Users.FirstOrDefault(f => f.Id == user.Id);
        //        EditUser.BlakcList = Convert.ToBoolean(user.BlackList);
        //        EditUser.VIPClient = Convert.ToBoolean(user.VIPClient);
        //        if (user.UserRoles != null && user.UserRoles.Length > 0)
        //        {
        //            foreach (var i in user.UserRoles)
        //            {
        //                db.UserRoles.Add(new UserRole() { UserDbId = user.Id, RoleId = i });
        //            }
        //        }
        //    }
        //    db.SaveChanges();
        //    return RedirectToAction("IndexCustumers");
        //}
        ////////////////////////custuemr delete get///////////////////////////////////////////////////////////////////////////////////////////////
        //public ActionResult Delete(int? Id)
        //{
        //    if (Id == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    else
        //    {
        //        UserDb delete = db.Users.Find(Id);
        //        if (delete == null)
        //        {
        //            return HttpNotFound();
        //        }
        //        else
        //        {
        //            return View(delete);
        //        }
        //    }
        //}

        //[HttpPost]
        //[DisplayName("Delete")]
        //public ActionResult DeletePost(int Id)
        //{
        //    UserDb delete = db.Users.Find(Id);
        //    db.Users.Remove(delete);
        //    db.SaveChanges();
        //    return RedirectToAction("UsersIndex");
        //}



        /////////////////////////////////////////////////////////////////////////////////
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