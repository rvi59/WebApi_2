namespace ShoeApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtblyear : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblYears",
                c => new
                    {
                        YearId = c.Int(nullable: false, identity: true),
                        YearText = c.String(maxLength: 20, unicode: false),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.YearId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblYears");
        }
    }
}
