using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DATN_2022.Models;

namespace DATN_2022.Areas.Admin.Controllers
{
    public class ShopHistoriesController : Controller
    {
        private GreatTechDB db = new GreatTechDB();

        // GET: Admin/ShopHistories
        public ActionResult Index()
        {
            var shopHistories = db.ShopHistories.Include(s => s.EndUser).Include(s => s.Product);
            return View(shopHistories.ToList());
        }

        // GET: Admin/ShopHistories/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopHistory shopHistory = db.ShopHistories.Find(id);
            if (shopHistory == null)
            {
                return HttpNotFound();
            }
            return View(shopHistory);
        }

        // GET: Admin/ShopHistories/Create
        public ActionResult Create()
        {
            ViewBag.EndUserId = new SelectList(db.EndUsers, "Id", "Name");
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name");
            return View();
        }

        // POST: Admin/ShopHistories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EndUserId,ProductId,CreatedAt,Amount")] ShopHistory shopHistory)
        {
            if (ModelState.IsValid)
            {
                db.ShopHistories.Add(shopHistory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EndUserId = new SelectList(db.EndUsers, "Id", "Name", shopHistory.EndUserId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", shopHistory.ProductId);
            return View(shopHistory);
        }

        // GET: Admin/ShopHistories/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopHistory shopHistory = db.ShopHistories.Find(id);
            if (shopHistory == null)
            {
                return HttpNotFound();
            }
            ViewBag.EndUserId = new SelectList(db.EndUsers, "Id", "Name", shopHistory.EndUserId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", shopHistory.ProductId);
            return View(shopHistory);
        }

        // POST: Admin/ShopHistories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EndUserId,ProductId,CreatedAt,Amount")] ShopHistory shopHistory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shopHistory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EndUserId = new SelectList(db.EndUsers, "Id", "Name", shopHistory.EndUserId);
            ViewBag.ProductId = new SelectList(db.Products, "Id", "Name", shopHistory.ProductId);
            return View(shopHistory);
        }

        // GET: Admin/ShopHistories/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShopHistory shopHistory = db.ShopHistories.Find(id);
            if (shopHistory == null)
            {
                return HttpNotFound();
            }
            return View(shopHistory);
        }

        // POST: Admin/ShopHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ShopHistory shopHistory = db.ShopHistories.Find(id);
            db.ShopHistories.Remove(shopHistory);
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
