namespace ShoeApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblProducts", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblProducts", "Quantity");
        }
    }
}
