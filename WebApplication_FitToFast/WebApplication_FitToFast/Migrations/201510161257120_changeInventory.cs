namespace WebApplication_FitToFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInventory : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Products", newName: "Inventories");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Inventories", newName: "Products");
        }
    }
}
