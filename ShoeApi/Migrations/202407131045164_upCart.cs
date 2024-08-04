namespace ShoeApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class upCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblCarts", "Cart_CreatedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblCarts", "Cart_CreatedDate");
        }
    }
}
