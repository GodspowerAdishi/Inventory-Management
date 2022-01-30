using InventoryManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Products { get; set; }
        
        public int Pieces { get; set; }
        public int Cartons { get; set; }

        public int? PurchaseInvoiceId { get; set; }
        [ForeignKey("PurchaseInvoiceId")]
        public virtual PurchaseInvoice PurchaseInvoices { get; set; }

    }
}