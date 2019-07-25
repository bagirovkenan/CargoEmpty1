using CargoEmpty.Context;
using CargoEmpty.Models.Helper;
using CargoEmpty.Models.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.Front
{
    public class FrontContactController : Controller
    {
        private CargoDbContext db = new CargoDbContext();
        // GET: FrontContact
        public ActionResult Index()
        {
            var ContactDb = db.Settings.FirstOrDefault();
            //FrontContact fc = new FrontContact(ContactDb.Adress, ContactDb.PhoneNumber, ContactDb.MobileNumber, ContactDb.Mail, ContactDb.FaceBookAdress, ContactDb.InstagramAdress, ContactDb.YoutubeAdress);
            FrontContact fc = new FrontContact();
            ContactDb.ViewFromDb(fc);
            return View(fc);
        }
    }
}