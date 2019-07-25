using CargoEmpty.Context;
using CargoEmpty.Models.General.User;
using CargoEmpty.Models.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.General
{
    public class SignUpController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        // GET: SignUp
        public ActionResult Index()
        {
            ViewBag.faq = db.Faqs.FirstOrDefault(f => f.FaqTitle == "Sifaris Sertleri");
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserSignUp SignUp)
        {
            if (ModelState.IsValid && SignUp.Condition == "true")
            {
                var userdb = db.Users.FirstOrDefault(f => f.UserName.ToUpper() == SignUp.UserName.ToUpper() ||f.Mail==SignUp.Mail);
                if (userdb == null && SignUp.Password == SignUp.ConfirmPassword)
                {
                    UserDb user = new UserDb();

                    SignUp.ViewFromDb(user);

                    user.HashPassword = SHA.CustumSHA(SignUp.Password);
                    db.Users.Add(user);
                    db.SaveChanges();
                    var userCod = user.Id + 10000;
                    user.UserCod = user.Id.ToString() + userCod.ToString();
                    db.UserRoles.Add(new UserRole() { UserDbId = user.Id, RoleId = 1 });
                    db.SaveChanges();
                    return RedirectToAction("Login", "UserLogin");


                }
                else
                {
                    ViewBag.faq = db.Faqs.FirstOrDefault(f => f.FaqTitle == "Sifaris Sertleri");
                    return View(SignUp);
                }

            }
            ViewBag.faq = db.Faqs.FirstOrDefault(f => f.FaqTitle == "Sifaris Sertleri");
            return View(SignUp);
        }

        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var edit = db.Users.Find(Id);
                if (edit == null)
                {
                    return HttpNotFound();

                }
                else
                {
                    return View(edit);
                }

            }

        }
        [HttpPost]
        public ActionResult Edit(UserEdit edit)
        {

            if (edit.Id == UserSession.SessionId)
            {
                if (ModelState.IsValid)
                {
                    var editdb = db.Users.FirstOrDefault(f => f.Id == edit.Id);
                    string Hashpassword = editdb.HashPassword;
                    if (edit.LastPassword != null)
                    {
                        if (SHA.CustumSHA(edit.LastPassword) == Hashpassword && edit.NewPassword == edit.NewConfirmPassword)
                        {
                            Hashpassword = SHA.CustumSHA(edit.NewPassword);
                        }
                    }
                    edit.ViewFromDb(editdb);
                    editdb.HashPassword = Hashpassword;
                    db.SaveChanges();
                    return View();//helelik Accaunta return olacaq

                }
                return View(edit);
            }
            return View(edit);
        }

        /// /////////////////////////////////////////////////////////////////

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