namespace WebApplication_FitToFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecode3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventories", "pImage", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventories", "pImage", c => c.String());
        }
    }
}
