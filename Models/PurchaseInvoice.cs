using InventoryManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class PurchaseInvoice
    {
        public int PurchaseInvoiceId { get; set; }

        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual Supplier Suppliers { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
        public List<Stock> Stocks { get; set; }
        public List<InventoryViewModel> InventoryViewModel { get; set; }
    }
}