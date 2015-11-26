namespace WebApplication_FitToFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatemigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventories", "pName", c => c.String(nullable: false));
            AlterColumn("dbo.Inventories", "pImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventories", "pImage", c => c.String());
            AlterColumn("dbo.Inventories", "pName", c => c.String());
        }
    }
}
