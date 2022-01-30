using InventoryManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class Supplier
    {
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string OpeningBalance { get; set; }
        public List<PurchaseInvoice> PurchaseInvoices { get; set; }
        public List<InventoryViewModel> InventoriesviewModel { get; set; }
    }
}