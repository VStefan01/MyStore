namespace MyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartProducts", "ProductId", "dbo.Products");
            DropIndex("dbo.CartProducts", new[] { "ProductId" });
            DropTable("dbo.CartProducts");
        }
    }
}
