using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BOFOY.Models;
using Microsoft.AspNet.Identity;

namespace BOFOY.Controllers
{
    public class BookingsController : Controller
    {
        private Entities db = new Entities();

        // GET: Bookings
        [Authorize]
        public ActionResult Index()
        {
            var customerId = User.Identity.GetUserId();
            var bookings = db.Bookings.Include(b => b.CafeShop).Include(b => b.Menu).Where(b => b.CustomerId == customerId);
            return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.bookCafe = new SelectList(db.CafeShops, "Id", "CafeName");
            ViewBag.bookFood = new SelectList(db.Menus, "Id", "MenuName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,bookTime,bookFood,bookCafe,bookDetail")] Booking booking)
        {
            booking.CustomerId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(booking);
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bookCafe = new SelectList(db.CafeShops, "Id", "CafeName", booking.bookCafe);
            ViewBag.bookFood = new SelectList(db.Menus, "Id", "MenuName", booking.bookFood);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.bookCafe = new SelectList(db.CafeShops, "Id", "CafeName", booking.bookCafe);
            ViewBag.bookFood = new SelectList(db.Menus, "Id", "MenuName", booking.bookFood);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,bookTime,bookFood,bookCafe,bookDetail,CustomerId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bookCafe = new SelectList(db.CafeShops, "Id", "CafeName", booking.bookCafe);
            ViewBag.bookFood = new SelectList(db.Menus, "Id", "MenuName", booking.bookFood);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
