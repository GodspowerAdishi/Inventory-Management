namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedColumns : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.InventoryViewModels", "SupplierId", "dbo.Stocks", "StockId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryViewModels", "SupplierId", "dbo.Stocks");
        }
    }
}
