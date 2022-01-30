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
    [Authorize]
    public class InvoiceDetailsController : Controller
    {
        private InventoryDBContext db = new InventoryDBContext();

        // GET: InvoiceDetails
        public ActionResult Index()
        {
            var invoiceDetails = db.InvoiceDetails.Include(i => i.Products).Include(i => i.PurchaseInvoices);
            return View(invoiceDetails.ToList());
        }

        // GET: InvoiceDetails/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetail invoiceDetail = db.InvoiceDetails.Find(id);
            if (invoiceDetail == null)
            {
                return HttpNotFound();
            }
            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Create
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName");
            ViewBag.PurchaseInvoiceId = new SelectList(db.PurchaseInvoices, "PurchaseInvoiceId", "PurchaseInvoiceId");
            return View();
        }


        // POST: InvoiceDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceDetailId,PurchaseInvoiceId,ProductId")] InvoiceDetail invoiceDetail)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceDetails.Add(invoiceDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", invoiceDetail.ProductId);
            ViewBag.PurchaseInvoiceId = new SelectList(db.PurchaseInvoices, "PurchaseInvoiceId", "PurchaseInvoiceId", invoiceDetail.PurchaseInvoiceId);
            return View(invoiceDetail);
        }


        // GET: InvoiceDetails/Edit/5
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetail invoiceDetail = db.InvoiceDetails.Find(id);
            if (invoiceDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", invoiceDetail.ProductId);
            ViewBag.PurchaseInvoiceId = new SelectList(db.PurchaseInvoices, "PurchaseInvoiceId", "PurchaseInvoiceId", invoiceDetail.PurchaseInvoiceId);
            return View(invoiceDetail);
        }

        // POST: InvoiceDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceDetailId,PurchaseInvoiceId,ProductId")] InvoiceDetail invoiceDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.Products, "ProductId", "ProductName", invoiceDetail.ProductId);
            ViewBag.PurchaseInvoiceId = new SelectList(db.PurchaseInvoices, "PurchaseInvoiceId", "PurchaseInvoiceId", invoiceDetail.PurchaseInvoiceId);
            return View(invoiceDetail);
        }

        // GET: InvoiceDetails/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceDetail invoiceDetail = db.InvoiceDetails.Find(id);
            if (invoiceDetail == null)
            {
                return HttpNotFound();
            }
            return View(invoiceDetail);
        }

        // POST: InvoiceDetails/Delete/5
        [Authorize(Roles = "SuperAdmin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceDetail invoiceDetail = db.InvoiceDetails.Find(id);
            db.InvoiceDetails.Remove(invoiceDetail);
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