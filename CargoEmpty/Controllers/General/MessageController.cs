using CargoEmpty.Controllers.Main;
using CargoEmpty.Models.General.User;
using CargoEmpty.Models.Helper;
using CargoEmpty.Models.Message;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.General
{
    public class MessageController : MainController
    {

        [HttpPost]
        public async Task<JsonResult> GuestMesage(UserMessage Message)
        {
            MessageDb NewMessage = new MessageDb();
            NewMessage.FullName = Message.FullName;
            NewMessage.Message = Message.Message;
            NewMessage.Phone = Message.Phone;
            NewMessage.Subject = Message.Subject;
            NewMessage.CreateDate = DateTime.Now;
            NewMessage.ToMail = "kenanbagiro14@gmail.com";
            NewMessage.FromMail = Message.Email;

            db.Messages.Add(NewMessage);
            await db.SaveChangesAsync();
            return Json(new { succses = true }, JsonRequestBehavior.AllowGet);
        }
        //////////////
        public async Task<ActionResult> UserIndexMsg(int id)
        {
            UserDb UserSession = (UserDb)Session["User"];
            if (id == UserSession.Id)
            {
                var msgs = await db.Messages.Where(f => f.UserDbId == UserSession.Id || f.ToMesssageUserDbId == UserSession.Id).OrderByDescending(o => o.CreateDate).ToListAsync();
                int inbox = SmsCount.UserMsgCount(id);
                ViewData["inbox"] = inbox;
                ViewData["Id"] = id;
                return View(msgs);
            }
            else
            {
                return RedirectToAction("Index", "MyAccount");

            }
        }

        public async Task<ActionResult> UserAllmsg(int id)
        {
            UserDb UserSession = (UserDb)Session["User"];

            if (id == UserSession.Id)
            {
                var msgs = await db.Messages.Where(f => f.UserDbId == UserSession.Id || f.ToMesssageUserDbId == UserSession.Id).OrderByDescending(o => o.CreateDate).ToListAsync();
                int inbox = SmsCount.UserMsgCount(id);
                return PartialView(msgs);
            }
            else
            {
                return RedirectToAction("Index", "MyAccount");
            }
        }

        public async Task<ActionResult> UserUnRead(int? id)
        {
            UserDb UserSession = (UserDb)Session["User"];

            if (id == UserSession.Id)
            {
                var msgs = await db.Messages.Where(f => f.ToMesssageUserDbId == UserSession.Id && f.Read == false).OrderByDescending(o => o.CreateDate).ToListAsync();
                return PartialView(msgs);
            }
            else
            {
                return RedirectToAction("Index", "MyAccount");
            }
        }

        public async Task<ActionResult> UserInbox(int id)
        {
            UserDb UserSession = (UserDb)Session["User"];

            if (id == UserSession.Id)
            {
                var msgs = await db.Messages.Where(f => f.ToMesssageUserDbId == UserSession.Id).OrderByDescending(o => o.CreateDate).ToListAsync();
                return PartialView(msgs);
            }
            return RedirectToAction("Index", "MyAccount");
        }

        public async Task<ActionResult> UserSend(int id)
        {
            UserDb UserSession = (UserDb)Session["User"];

            if (id == UserSession.Id)
            {
                var msgs = await db.Messages.Where(f => f.UserDbId == UserSession.Id).OrderByDescending(o => o.CreateDate).OrderByDescending(o => o.CreateDate).ToListAsync();
                return PartialView(msgs);
            }
            return RedirectToAction("Index", "MyAccount");
        }

        public async Task<ActionResult> UserCreate(int id)
        {
            UserDb UserSession = (UserDb)Session["User"];

            if (id == UserSession.Id)
            {
                var user = await db.Users.FirstOrDefaultAsync(f => f.Id == UserSession.Id);
                var userMsg = new UserViewMessage();
                userMsg.UserId = user.Id;
                userMsg.FullName = user.FirstName + user.LastName;
                userMsg.Email = user.Mail;
                userMsg.Phone = user.PhoneNumber;
                return PartialView(userMsg);
            }
            return RedirectToAction("Index", "MyAccount");
        }

        [HttpPost]
        public async Task<ActionResult> UserCreate(CreateView ViewMessage)
        {
            UserDb UserSession = (UserDb)Session["User"];

            if (ViewMessage.UserDbId == UserSession.Id)
            {
                var user = await db.Users.FirstOrDefaultAsync(f => f.Id == UserSession.Id);
                MessageDb Message = new MessageDb();

                Message.UserDbId = ViewMessage.UserDbId;
                Message.Company = ViewMessage.Company;
                Message.Subject = ViewMessage.Subject;
                Message.Message = ViewMessage.Message;
                Message.FullName = user.FirstName + " " + user.LastName;
                Message.Phone = user.PhoneNumber;
                Message.CreateDate = DateTime.Now;
                Message.FromMail = user.Mail;
                Message.ToMail = "kenanbagirov14gmail.com";
                Message.Read = true;
                db.Messages.Add(Message);
                await db.SaveChangesAsync();
                return RedirectToAction("UserIndexMsg", new { id = UserSession.Id });
            }
            else
            {
                return RedirectToAction("Index", "MyAccount");
            }
        }
        /// <summary>
        /// //////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public async Task<ActionResult> MessageUserRead(int id)
        {
            UserDb UserSession = (UserDb)Session["User"];

            var msg = await db.Messages.FirstOrDefaultAsync(f => f.Id == id && (f.UserDbId == UserSession.Id || f.ToMesssageUserDbId == UserSession.Id));
            if (msg != null)
            {
                msg.Read = true;
                await db.SaveChangesAsync();
                return PartialView(msg);
            }
            else
            {
                return RedirectToAction("UserIndexMsg", "User", new { id = UserSession.Id });
            }
        }
        [HttpPost]
        public JsonResult MessageUserDelete(int id)
        {
            UserDb UserSession = (UserDb)Session["User"];

            var msg = db.Messages.FirstOrDefault(f => f.Id == id && (f.UserDbId == UserSession.Id || f.ToMesssageUserDbId == UserSession.Id));
            if (msg != null)
            {
                db.Messages.Remove(msg);
                db.SaveChanges();
                return Json(new { success = "true" });
            }
            else
            {
                return Json(new { success = false });
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///Admin Messaje
        ///
        public async Task<ActionResult> Index()
        {


            int inbox = SmsCount.AdminMsgCount();
            ViewData["inbox"] = inbox;
            return View(await db.Messages.OrderByDescending(o => o.CreateDate).ToListAsync());
        }

        public async Task<ActionResult> Allmsg()
        {
            var msgs = await db.Messages.OrderByDescending(o => o.CreateDate).ToListAsync();
            return PartialView(msgs);
        }


        public ActionResult Create()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AdminCreate ViewMessage)
        {
            MessageDb Message = new MessageDb();    
            Message.CreateDate = DateTime.Now;
            Message.ToMesssageUserDbId = ViewMessage.ToMesssageUserDbId;
            Message.Subject = ViewMessage.Subject;
            Message.Message = ViewMessage.Message;
            Message.ToMail = (await db.Users.FirstOrDefaultAsync(f => f.Id == ViewMessage.ToMesssageUserDbId)).Mail;
            Message.FromMail = "kenanbagiro.14@gmail.com";
            db.Messages.Add(Message);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> UnRead()
        {


            var msgs = await db.Messages.Where(f => (f.ToMesssageUserDbId == null && f.UserDbId != null) && f.Read == false).OrderByDescending(o => o.CreateDate).ToListAsync();
            return PartialView(msgs);
        }

        public async Task<ActionResult> Inbox()
        {
            var msgs = await db.Messages.Where(f => f.ToMesssageUserDbId == null && f.UserDbId != null).OrderByDescending(o => o.CreateDate).ToListAsync();
            return PartialView(msgs);
        }

        public async Task<ActionResult> Send()
        {
            var msgs = await db.Messages.Where(f => f.ToMesssageUserDbId != null && f.UserDbId == null).OrderByDescending(o => o.CreateDate).ToListAsync();
            return PartialView(msgs);
        }

        /////////
        ///
        [HttpPost]
        public async Task<ActionResult> MessageAdminRead(int id)
        {
            UserDb UserSession = (UserDb)Session["User"];

            var msg = await db.Messages.FirstOrDefaultAsync(f => f.Id == id );
            if (msg != null)
            {
                msg.Read = true;
                await db.SaveChangesAsync();
                return PartialView(msg);
            }
            else
            {
                return RedirectToAction("UserIndexMsg", "User", new { id = UserSession.Id });
            }
        }
        [HttpPost]
        public JsonResult MessageAdminDelete(int id)
        {
            var msg = db.Messages.FirstOrDefault(f => f.Id == id );
            if (msg != null)
            {
                db.Messages.Remove(msg);
                db.SaveChanges();
                return Json(new { success = "true" });
            }
            else
            {
                return Json(new { success = false });
            }
        }

    }
}