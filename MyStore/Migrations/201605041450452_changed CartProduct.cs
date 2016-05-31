namespace MyStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedCartProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartProducts", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.CartProducts", "Count");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CartProducts", "Count", c => c.Int(nullable: false));
            DropColumn("dbo.CartProducts", "Quantity");
        }
    }
}
