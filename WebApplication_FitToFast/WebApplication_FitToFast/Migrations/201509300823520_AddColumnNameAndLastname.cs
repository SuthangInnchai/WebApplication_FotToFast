namespace WebApplication_FitToFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnNameAndLastname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "fname", c => c.String());
            AddColumn("dbo.AspNetUsers", "lname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "lname");
            DropColumn("dbo.AspNetUsers", "fname");
        }
    }
}
