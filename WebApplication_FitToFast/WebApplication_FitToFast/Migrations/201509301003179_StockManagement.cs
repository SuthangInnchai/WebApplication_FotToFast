namespace WebApplication_FitToFast.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StockManagement : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        pId = c.Int(nullable: false, identity: true),
                        typeId = c.Int(nullable: false),
                        pName = c.String(),
                        pDetail = c.String(),
                        pPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        pImage = c.String(),
                        pTexture = c.String(),
                        XS = c.Int(nullable: false),
                        S = c.Int(nullable: false),
                        M = c.Int(nullable: false),
                        L = c.Int(nullable: false),
                        XL = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.pId);
            
            CreateTable(
                "dbo.ProductStores",
                c => new
                    {
                        pId = c.Int(nullable: false, identity: true),
                        typeId = c.Int(nullable: false),
                        pName = c.String(),
                        pDetail = c.String(),
                        pPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        pImage = c.String(),
                        pTexture = c.String(),
                        XS = c.Int(nullable: false),
                        S = c.Int(nullable: false),
                        M = c.Int(nullable: false),
                        L = c.Int(nullable: false),
                        XL = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.pId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductStores");
            DropTable("dbo.Products");
        }
    }
}
