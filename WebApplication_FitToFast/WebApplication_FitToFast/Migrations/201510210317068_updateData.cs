namespace WebApplication_FitToFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventories", "pImage", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventories", "pImage", c => c.String(nullable: false));
        }
    }
}
