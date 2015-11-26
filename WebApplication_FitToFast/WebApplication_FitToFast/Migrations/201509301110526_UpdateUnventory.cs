namespace WebApplication_FitToFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUnventory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        TblId = c.Int(nullable: false, identity: true),
                        Id = c.Int(nullable: false),
                        ClothTypeId = c.Int(nullable: false),
                        ProductName = c.String(),
                        ProductDetail = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size = c.String(),
                        Quantity = c.Int(nullable: false),
                        SouldOuteDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TblId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Inventories");
        }
    }
}
