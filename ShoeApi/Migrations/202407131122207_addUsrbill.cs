namespace ShoeApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUsrbill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblUserBills",
                c => new
                    {
                        BillId = c.Int(nullable: false, identity: true),
                        user_Id = c.Int(),
                        TotalProd_Price = c.Decimal(precision: 18, scale: 2),
                        Address = c.String(maxLength: 1000, unicode: false),
                        Mobile = c.String(maxLength: 20, unicode: false),
                        OrderId = c.String(maxLength: 100, unicode: false),
                        Pid = c.Int(),
                        TotalBillPrice = c.Decimal(precision: 18, scale: 2),
                        Created_Date = c.DateTime(),
                        Cart_Id = c.Int(),
                        Prod_Qty = c.Int(),
                        PaymentId = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.BillId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tblUserBills");
        }
    }
}
