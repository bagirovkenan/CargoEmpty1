using CargoEmpty.Context;
using CargoEmpty.Models.General.User;
using CargoEmpty.Models.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.General
{
    public class UserLoginController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult Login(UserLogin login)
        {
           
            var ViewHashPassword = SHA.CustumSHA(login.Password);
            var user = db.Users.SingleOrDefault(f => (f.UserName == login.UerNameOrMail || f.Mail == login.UerNameOrMail) && f.HashPassword == ViewHashPassword);

            if (user == null)
            {
                Session["isLogin"] = null;
                return View(login);
            }
            else
            {
                
                Session["isLogin"] = "true";
                Session["User"] = user;
                Session["userId"] = user.Id;
                Session["UserCode"] = user.UserCod;
                Session["username"] = user.UserName;
                Session["mail"] = user.Mail;
                Session["FirstName"] = user.FirstName;
                Session["LastName"] = user.LastName;

                return RedirectToAction("Index","MyAccount");
            }
        }

        public ActionResult ExitAccount()
        {
           
            Session.Clear();         
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
     
        public async Task<ActionResult> ForgetPassword(ForgetThePassword forgetPsw)
        {
            if (ModelState.IsValid)
            {
                var user = await db.Users.FirstOrDefaultAsync(s => s.Mail == forgetPsw.Mail && s.FirstName == forgetPsw.FirstName && s.LastName == forgetPsw.LastName);
                if (user == null)
                {
                    return View();
                }
                else
                {
                    string newPsw = GenerateNewCod.NewPassword();
                    var newHash = SHA.CustumSHA(newPsw);
                    user.HashPassword = newHash;
                    string mesg = newPsw + "-bu sizin yeni parolunuzdur.Hesabinizin Tehlukesizliyi ucun tez bir zamanda deyisdirin";
                    SendEmail.SendNewMail(user.Mail, mesg, "Parol deyisikliyi");
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
               
            }
            return View();
        }
        ////////////////////////////////////////
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