namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InventoryViewModels", "PurchaseDate", c => c.DateTime());
            AlterColumn("dbo.InventoryViewModels", "ExpiryDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InventoryViewModels", "ExpiryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.InventoryViewModels", "PurchaseDate", c => c.DateTime(nullable: false));
        }
    }
}
