namespace ShoeApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblCarts",
                c => new
                    {
                        Cartid = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                        Prod_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Cartid)
                .ForeignKey("dbo.tblProducts", t => t.Prod_Id, cascadeDelete: true)
                .ForeignKey("dbo.tblUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Prod_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblCarts", "User_Id", "dbo.tblUsers");
            DropForeignKey("dbo.tblCarts", "Prod_Id", "dbo.tblProducts");
            DropIndex("dbo.tblCarts", new[] { "Prod_Id" });
            DropIndex("dbo.tblCarts", new[] { "User_Id" });
            DropTable("dbo.tblCarts");
        }
    }
}
