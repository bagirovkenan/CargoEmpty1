using CargoEmpty.Context;
using CargoEmpty.Controllers.Main;
using CargoEmpty.Models.General;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CargoEmpty.Controllers.General
{
    public class MyAddressesController : MainController
    {
        // GET: MyAddresses
        public ActionResult Index()
        {
            
            return View(db.MyAddresses.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {

            ViewBag.country = db.Countries.Where(w=>w.IsActive==true).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(MyAddress adres)
        {
            if (ModelState.IsValid)
            {
                db.MyAddresses.Add(adres);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(adres);
            }
        }
/// <summary>
/// /////////////////////////////////////////////////////////////
/// </summary>
/// 
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyAddress myaddresd = db.MyAddresses.Find(id);
            if (myaddresd == null)
            {
                return HttpNotFound();
            }
            ViewBag.country = db.Countries.Where(w => w.IsActive == true).ToList();
            return View(myaddresd);
        }

       
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
     
        [HttpPost]
       
        public ActionResult Edit( MyAddress myAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myAddress);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyAddress myAddress = db.MyAddresses.Find(id);
            if (myAddress == null)
            {
                return HttpNotFound();
            }
            return View(myAddress);
        }

        // POST: MyAddress/Delete/5
        [HttpPost, ActionName("Delete")]

        public ActionResult DeleteConfirmed(int id)
        {
            MyAddress myAddress = db.MyAddresses.Find(id);
            db.MyAddresses.Remove(myAddress);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //
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