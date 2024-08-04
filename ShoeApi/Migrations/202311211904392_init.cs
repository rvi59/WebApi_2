namespace ShoeApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblBrands",
                c => new
                    {
                        Brand_Id = c.Int(nullable: false, identity: true),
                        Brand_Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Brand_CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Brand_Id);
            
            CreateTable(
                "dbo.tblProducts",
                c => new
                    {
                        Prod_Id = c.Int(nullable: false, identity: true),
                        Prod_Name = c.String(nullable: false, maxLength: 800, unicode: false),
                        Prod_ShortName = c.String(nullable: false, maxLength: 100, unicode: false),
                        Prod_Price = c.Double(nullable: false),
                        Prod_Selling = c.Double(nullable: false),
                        Prod_Description = c.String(nullable: false),
                        BrandId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        SizeId = c.Int(nullable: false),
                        Prod_CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Prod_Id)
                .ForeignKey("dbo.tblBrands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.tblCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.tblSizes", t => t.SizeId, cascadeDelete: true)
                .Index(t => t.BrandId)
                .Index(t => t.CategoryId)
                .Index(t => t.SizeId);
            
            CreateTable(
                "dbo.tblCategories",
                c => new
                    {
                        Category_Id = c.Int(nullable: false, identity: true),
                        Category_Name = c.String(nullable: false, maxLength: 50, unicode: false),
                        Category_CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Category_Id);
            
            CreateTable(
                "dbo.tblSizes",
                c => new
                    {
                        Size_Id = c.Int(nullable: false, identity: true),
                        Size_Number = c.Int(nullable: false),
                        Size_CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Size_Id);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        User_Id = c.Int(nullable: false, identity: true),
                        U_UserName = c.String(nullable: false, maxLength: 50, unicode: false),
                        U_Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        U_Email = c.String(nullable: false, unicode: false),
                        U_FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        U_LastName = c.String(maxLength: 50, unicode: false),
                        U_CreatedDate = c.DateTime(nullable: false),
                        U_LastUpdatedDate = c.DateTime(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        UserType = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblProducts", "SizeId", "dbo.tblSizes");
            DropForeignKey("dbo.tblProducts", "CategoryId", "dbo.tblCategories");
            DropForeignKey("dbo.tblProducts", "BrandId", "dbo.tblBrands");
            DropIndex("dbo.tblProducts", new[] { "SizeId" });
            DropIndex("dbo.tblProducts", new[] { "CategoryId" });
            DropIndex("dbo.tblProducts", new[] { "BrandId" });
            DropTable("dbo.tblUsers");
            DropTable("dbo.tblSizes");
            DropTable("dbo.tblCategories");
            DropTable("dbo.tblProducts");
            DropTable("dbo.tblBrands");
        }
    }
}
