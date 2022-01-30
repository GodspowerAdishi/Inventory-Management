using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class InventoryRepository
    {
        public List<User> GetUsers()
        {
            InventoryDBContext inventoryDBContext = new InventoryDBContext();
            return inventoryDBContext.Users.Include("Roles").ToList();
        }

        public List<Role> GetRoles()
        {
            InventoryDBContext inventoryDBContext = new InventoryDBContext();
            return inventoryDBContext.Roles.ToList();
        }

        public List<Category> GetCategory()
        {
            InventoryDBContext inventoryDBContext = new InventoryDBContext();
            return inventoryDBContext.Categories.ToList();
        }

        public List<Product> GetProduct()
        {
            InventoryDBContext inventoryDBContext = new InventoryDBContext();
            return inventoryDBContext.Products.ToList();
        }

        public List<Supplier> GetSupplier()
        {
            InventoryDBContext inventoryDBContext = new InventoryDBContext();
            return inventoryDBContext.Suppliers.ToList();
        }

        public List<PurchaseInvoice> GetPurchaseInvoice()
        {
            InventoryDBContext inventoryDBContext = new InventoryDBContext();
            return inventoryDBContext.PurchaseInvoices.ToList();
        }

        public List<InvoiceDetail> GetInvoiceDetail()
        {
            InventoryDBContext inventoryDBContext = new InventoryDBContext();
            return inventoryDBContext.InvoiceDetails.ToList();
        }
        public List<Stock> GetStock()
        {
            InventoryDBContext inventoryDBContext = new InventoryDBContext();
            return inventoryDBContext.Stocks.ToList();
        }


    }
}