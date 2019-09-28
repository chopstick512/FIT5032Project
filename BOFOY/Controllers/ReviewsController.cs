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
    public class ReviewsController : Controller
    {
        private Entities db = new Entities();

        // GET: Reviews
        [Authorize]
        public ActionResult Index()
        {
            var customerId = User.Identity.GetUserId();
            var reviews = db.Reviews.Include(r => r.CafeShop).Include(r => r.Menu).Where(r => r.CustomerId == customerId);
            return View(reviews.ToList());
        }

        // GET: Reviews/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // GET: Reviews/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ReviewCafe = new SelectList(db.CafeShops, "Id", "CafeName");
            ViewBag.ReviewMenu = new SelectList(db.Menus, "Id", "MenuName");
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "Id,ReviewDate,ReviewDetail,ReviewRate,ReviewMenu,ReviewCafe")] Review review)
        {
            review.CustomerId = User.Identity.GetUserId();
            ModelState.Clear();
            TryValidateModel(review);
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReviewCafe = new SelectList(db.CafeShops, "Id", "CafeName", review.ReviewCafe);
            ViewBag.ReviewMenu = new SelectList(db.Menus, "Id", "MenuName", review.ReviewMenu);
            return View(review);
        }

        // GET: Reviews/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReviewCafe = new SelectList(db.CafeShops, "Id", "CafeName", review.ReviewCafe);
            ViewBag.ReviewMenu = new SelectList(db.Menus, "Id", "MenuName", review.ReviewMenu);
            return View(review);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReviewDate,ReviewDetail,ReviewRate,CustomerId,ReviewMenu,ReviewCafe")] Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReviewCafe = new SelectList(db.CafeShops, "Id", "CafeName", review.ReviewCafe);
            ViewBag.ReviewMenu = new SelectList(db.Menus, "Id", "MenuName", review.ReviewMenu);
            return View(review);
        }

        // GET: Reviews/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
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
