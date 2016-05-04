namespace MyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartProductDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartProducts", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartProducts", "DateCreated");
        }
    }
}
