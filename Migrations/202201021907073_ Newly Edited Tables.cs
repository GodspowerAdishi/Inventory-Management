namespace InventoryManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewlyEditedTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InventoryViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        SupplierId = c.Int(),
                        ProductName = c.String(),
                        Barcode = c.String(),
                        ExpiryDate = c.DateTime(nullable: false),
                        Pieces = c.Int(nullable: false),
                        Cartons = c.Int(nullable: false),
                        CostPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Suppliers", t => t.SupplierId)
                .Index(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryViewModels", "SupplierId", "dbo.Suppliers");
            DropIndex("dbo.InventoryViewModels", new[] { "SupplierId" });
            DropTable("dbo.InventoryViewModels");
        }
    }
}
