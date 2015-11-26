namespace WebApplication_FitToFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePurchaseHistory : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProductStores", newName: "PurchaseHistories");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.PurchaseHistories", newName: "ProductStores");
        }
    }
}
