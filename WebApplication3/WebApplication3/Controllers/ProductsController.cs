using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AdvancedProgramming.Data;
using Newtonsoft.Json;

namespace WebApplication3.Controllers
{
    public class ProductsController : Controller
    {
        private ProductDBEntities db = new ProductDBEntities();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Inventory).Include(p => p.Supplier);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
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

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            ViewBag.InventoryID = new SelectList(db.Inventories, "InventoryID", "ModifiedBy");
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,InventoryID,SupplierID,Description,Rating,CategoryID,LastModified,ModifiedBy")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.InventoryID = new SelectList(db.Inventories, "InventoryID", "ModifiedBy", product.InventoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", product.SupplierID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.InventoryID = new SelectList(db.Inventories, "InventoryID", "ModifiedBy", product.InventoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", product.SupplierID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,InventoryID,SupplierID,Description,Rating,CategoryID,LastModified,ModifiedBy")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", product.CategoryID);
            ViewBag.InventoryID = new SelectList(db.Inventories, "InventoryID", "ModifiedBy", product.InventoryID);
            ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierID", "SupplierName", product.SupplierID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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

        // GET: Products/FilterDescription/description
        public async Task<JsonResult> FilterDescription(string description)
        {          
            if (string.IsNullOrEmpty(description))
            {
                return Json(new List<Product>(), JsonRequestBehavior.AllowGet);
            }
            var products = await db.Products
                                   .Where(p => p.Description.Contains(description))
                                   .ToListAsync();
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditList(IEnumerable<Product> products)
        {
            if(products != null) 
            {
                foreach (var product in products)
                {
                    var existingProduct = db.Products.Where(e => e.ProductID == product.ProductID).FirstOrDefault();
                    if (existingProduct != null)
                    {
                        existingProduct.ProductName = product.ProductName;
                        existingProduct.Description = product.Description;
                        existingProduct.Rating = product.Rating;
                        existingProduct.CategoryID = product.CategoryID;
                        existingProduct.InventoryID = product.InventoryID;
                        existingProduct.SupplierID = product.SupplierID;
                        existingProduct.LastModified = DateTime.Now;
                        existingProduct.ModifiedBy = User.Identity.Name; 
                    }
                    db.Entry(existingProduct).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
