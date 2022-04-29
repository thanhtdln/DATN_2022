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
    public class ProductsController : Controller
    {
        private GreatTechDB db = new GreatTechDB();

        // GET: Admin/Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Producer);
            return View(products.ToList());
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CategoryId,ProducerId,CostPrice,SellPrice,Amount,Avatar,Description")] Product product)
        {
            try
            {
                product.Avatar = "";
                var f = Request.Files["ImgFile"];
                if (f != null && f.ContentLength > 0)
                {
                    string fileName=System.IO.Path.GetFileName(f.FileName);
                    string uploadPath = Server.MapPath("~/Areas/Admin/AdminRoot/Images/" + fileName);
                    f.SaveAs(uploadPath);
                    product.Avatar = fileName;
                }
                product.CreatedAt = DateTime.Now;
                product.UpdatedAt = DateTime.Now;
                if (ModelState.IsValid)
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
                ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
                ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", product.ProducerId);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Lỗi nhập liệu: " + ex.Message;
                return View(product);
            }
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", product.ProducerId);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedAt,UpdatedAt,CategoryId,ProducerId,CostPrice,SellPrice,Amount,Avatar,Description")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", product.CategoryId);
            ViewBag.ProducerId = new SelectList(db.Producers, "Id", "Name", product.ProducerId);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
