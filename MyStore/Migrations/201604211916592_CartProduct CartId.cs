namespace MyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartProductCartId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartProducts", "CartId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartProducts", "CartId");
        }
    }
}
