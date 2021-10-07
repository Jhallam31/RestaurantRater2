using RestaurantRater2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ReviewRater2.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        private RestaurantDbContext _db = new RestaurantDbContext();
        // GET: Review
        public ActionResult Index()
        {
            return View(_db.Reviews.ToList());
        }

        //GET: Review/Create
        public ActionResult Create()
        {
            ViewBag.Restaurants = _db.Restaurants
                .Select(
                x=> new SelectListItem 
                { 
                    Text = x.Name,
                    Value = x.RestaurantId.ToString()
                });
            return View();
        }

        //POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Review review)
        {
            if (ModelState.IsValid)
            {
                _db.Reviews.Add(review);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(review);
        }

        //GET: Review/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Review review = _db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        //POST: Review/Delete/{id}
        public ActionResult Delete(int id)
        {
            Review review = _db.Reviews.Find(id);
            _db.Reviews.Remove(review);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Review/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = _db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }

            ViewBag.Restaurants = _db.Restaurants
                .Select(
                x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.RestaurantId.ToString()
                });
            return View(review);
        }

        //GET: Review/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Review review = _db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }


            return View(review);
        }

        //POST: Review/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Review Review)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(Review).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(Review);
        }
    }
}