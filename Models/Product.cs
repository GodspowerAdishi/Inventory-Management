using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string Barcode { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        public List<InvoiceDetail> InvoiceDetails { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}