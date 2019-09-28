using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOFOY.Models;

namespace BOFOY.Controllers
{
    public class CafeShopsController : Controller
    {
        private Entities db = new Entities();

        // GET: CafeShops
        public ActionResult Index()
        {
            return View(db.CafeShops.ToList());
        }

        // GET: CafeShops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CafeShop cafeShop = db.CafeShops.Find(id);
            if (cafeShop == null)
            {
                return HttpNotFound();
            }
            return View(cafeShop);
        }

        // GET: CafeShops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CafeShops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OwnerName,OpenDate,OpenTime,Latitude,Longitude,Name,Description")] CafeShop cafeShop)
        {
            if (ModelState.IsValid)
            {
                db.CafeShops.Add(cafeShop);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cafeShop);
        }

        // GET: CafeShops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CafeShop cafeShop = db.CafeShops.Find(id);
            if (cafeShop == null)
            {
                return HttpNotFound();
            }
            return View(cafeShop);
        }

        // POST: CafeShops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OwnerName,OpenDate,OpenTime,Latitude,Longitude,Name,Description")] CafeShop cafeShop)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cafeShop).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cafeShop);
        }

        // GET: CafeShops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CafeShop cafeShop = db.CafeShops.Find(id);
            if (cafeShop == null)
            {
                return HttpNotFound();
            }
            return View(cafeShop);
        }

        // POST: CafeShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CafeShop cafeShop = db.CafeShops.Find(id);
            db.CafeShops.Remove(cafeShop);
            db.SaveChanges();
            return RedirectToAction("Index");
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
