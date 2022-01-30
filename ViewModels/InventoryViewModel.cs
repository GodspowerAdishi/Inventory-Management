using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.ViewModels
{
    public class InventoryViewModel
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? PurchaseDate { get; set; }

        public int? SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public virtual PurchaseInvoice PurchaseInvoices { get; set; }

        public string ProductName { get; set; }

        public string Barcode { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ExpiryDate { get; set; }

        public int Pieces { get; set; }
        public int Cartons { get; set; }

        public decimal CostPrice { get; set; }

    }
}