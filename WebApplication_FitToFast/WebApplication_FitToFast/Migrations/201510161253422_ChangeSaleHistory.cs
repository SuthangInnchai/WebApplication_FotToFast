namespace WebApplication_FitToFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSaleHistory : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Inventories", newName: "SalesHistories");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SalesHistories", newName: "Inventories");
        }
    }
}
