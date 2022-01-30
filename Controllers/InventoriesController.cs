using InventoryManagementSystem.Models;
using InventoryManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Authorize]
    public class InventoriesController : Controller
    {
        public ActionResult Index()
        {
            InventoryDBContext db = new InventoryDBContext();
            
            var InventoryList = (from p in db.Products
                                 join i in db.InvoiceDetails on p.ProductId equals i.InvoiceDetailId
                                 join s in db.Stocks on p.ProductId equals s.StockId
                                 join q in db.PurchaseInvoices on p.ProductId equals q.PurchaseInvoiceId into ThisList
                                 from q in ThisList.DefaultIfEmpty()

                                 select new
                                 {
                                     ProductId = p.ProductId,
                                     PurchaseDate = (DateTime?)q.PurchaseDate ?? DateTime.Now,
                                     SupplierId = q.SupplierId,
                                     ProductName = p.ProductName,
                                     Barcode = p.Barcode,
                                     ExpiryDate = (DateTime?)p.ExpiryDate ?? DateTime.Now,
                                     Pieces = s.Pieces,
                                     Cartons = s.Cartons,
                                     CostPrice = p.CostPrice
                                 }).ToList().Select(x => new InventoryViewModel()
                                 {
                                     Id = x.ProductId,
                                     PurchaseDate = (DateTime?)x.PurchaseDate ?? DateTime.Now,
                                     SupplierId = x.SupplierId,
                                     ProductName = x.ProductName,
                                     Barcode = x.Barcode,
                                     ExpiryDate = (DateTime?)x.ExpiryDate ?? DateTime.Now,
                                     Pieces = x.Pieces,
                                     Cartons = x.Cartons,
                                     CostPrice = x.CostPrice

                                 });
            return View(InventoryList);
        }

        [Authorize(Roles = "SuperAdmin")]
        [HttpGet]
        public ActionResult Create()
        {
            InventoryDBContext db = new InventoryDBContext();
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "SupplierName");

            return View();
        }


        [Authorize(Roles = "SuperAdmin")]
        [HttpPost, ActionName("Create")]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(InventoryViewModel obj)
        {
            InventoryDBContext db = new InventoryDBContext();
            Product p = new Product();
            p.ProductId = obj.Id;
            p.ProductName = obj.ProductName;
            p.CostPrice = obj.CostPrice;
            p.Barcode = obj.Barcode;
            p.ExpiryDate = (DateTime)obj.ExpiryDate;
            db.Products.Add(p);
            db.SaveChanges();

            PurchaseInvoice q = new PurchaseInvoice();
            q.PurchaseDate = (DateTime)obj.PurchaseDate;
            q.PurchaseInvoiceId = p.ProductId;
            q.SupplierId = obj.SupplierId;
            db.PurchaseInvoices.Add(q);
            db.SaveChanges();

            Stock s = new Stock();
            s.Pieces = obj.Pieces;
            s.Cartons = obj.Cartons;
            s.StockId = p.ProductId;
            s.ProductId = p.ProductId;
            s.PurchaseInvoiceId = q.PurchaseInvoiceId;
            db.Stocks.Add(s);
            db.SaveChanges();

            InvoiceDetail i = new InvoiceDetail();
            i.InvoiceDetailId = p.ProductId;
            i.ProductId = p.ProductId;
            i.PurchaseInvoiceId = q.PurchaseInvoiceId;
            db.InvoiceDetails.Add(i);
            db.SaveChanges();

            return RedirectToAction("Create");

        }


    }
}