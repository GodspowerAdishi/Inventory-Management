using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class PurchaseInvoicesController : Controller
    {
        private InventoryDBContext db = new InventoryDBContext();

        // GET: PurchaseInvoices
        [Authorize]
        public ActionResult Index()
        {
            var purchaseInvoices = db.PurchaseInvoices.Include(p => p.Suppliers);
            return View(purchaseInvoices.ToList());
        }

        // GET: PurchaseInvoices/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoice purchaseInvoice = db.PurchaseInvoices.Find(id);
            if (purchaseInvoice == null)
            {
                return HttpNotFound();
            }
            return View(purchaseInvoice);
        }

        // GET: PurchaseInvoices/Create
        public ActionResult Create()
        {
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName");
            return View();
        }

        // POST: PurchaseInvoices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PurchaseInvoiceId,PurchaseDate,SupplierId")] PurchaseInvoice purchaseInvoice)
        {
            if (ModelState.IsValid)
            {
                db.PurchaseInvoices.Add(purchaseInvoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", purchaseInvoice.SupplierId);
            return View(purchaseInvoice);
        }

        // GET: PurchaseInvoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoice purchaseInvoice = db.PurchaseInvoices.Find(id);
            if (purchaseInvoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", purchaseInvoice.SupplierId);
            return View(purchaseInvoice);
        }

        // POST: PurchaseInvoices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PurchaseInvoiceId,PurchaseDate,SupplierId")] PurchaseInvoice purchaseInvoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchaseInvoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName", purchaseInvoice.SupplierId);
            return View(purchaseInvoice);
        }

        // GET: PurchaseInvoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseInvoice purchaseInvoice = db.PurchaseInvoices.Find(id);
            if (purchaseInvoice == null)
            {
                return HttpNotFound();
            }
            return View(purchaseInvoice);
        }

        // POST: PurchaseInvoices/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PurchaseInvoice purchaseInvoice = db.PurchaseInvoices.Find(id);
            db.PurchaseInvoices.Remove(purchaseInvoice);
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
