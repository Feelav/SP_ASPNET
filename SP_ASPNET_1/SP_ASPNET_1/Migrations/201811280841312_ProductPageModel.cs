namespace SP_ASPNET_1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductPageModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductItems",
                c => new
                    {
                        ProductItemID = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(),
                        ImageAlt = c.String(),
                        Title = c.String(),
                        ProductLine_ProductLineID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductItemID)
                .ForeignKey("dbo.ProductLines", t => t.ProductLine_ProductLineID)
                .Index(t => t.ProductLine_ProductLineID);
            
            CreateTable(
                "dbo.ProductLines",
                c => new
                    {
                        ProductLineID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ProductLineID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductItems", "ProductLine_ProductLineID", "dbo.ProductLines");
            DropIndex("dbo.ProductItems", new[] { "ProductLine_ProductLineID" });
            DropTable("dbo.ProductLines");
            DropTable("dbo.ProductItems");
        }
    }
}
