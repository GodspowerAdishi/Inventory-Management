namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSupplier : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InventoryViewModels", "SupplierId", "dbo.Stocks");
            AddForeignKey("dbo.InventoryViewModels", "SupplierId", "dbo.PurchaseInvoices", "PurchaseInvoiceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryViewModels", "SupplierId", "dbo.PurchaseInvoices");
            AddForeignKey("dbo.InventoryViewModels", "SupplierId", "dbo.Stocks", "StockId");
        }
    }
}
