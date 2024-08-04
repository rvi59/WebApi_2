namespace ShoeApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class img : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblProducts", "Prod_Image_Path", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.tblProducts", "Prod_Image_Path");
        }
    }
}
