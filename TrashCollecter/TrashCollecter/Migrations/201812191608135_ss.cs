namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Street = c.String(),
                        ZipCode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        DayID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        SpecialPickupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CustomerModels", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Daymodels", t => t.DayID, cascadeDelete: true)
                .ForeignKey("dbo.SpecialPickups", t => t.SpecialPickupID, cascadeDelete: true)
                .Index(t => t.DayID)
                .Index(t => t.CustomerID)
                .Index(t => t.SpecialPickupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeModels", "SpecialPickupID", "dbo.SpecialPickups");
            DropForeignKey("dbo.EmployeeModels", "DayID", "dbo.Daymodels");
            DropForeignKey("dbo.EmployeeModels", "CustomerID", "dbo.CustomerModels");
            DropIndex("dbo.EmployeeModels", new[] { "SpecialPickupID" });
            DropIndex("dbo.EmployeeModels", new[] { "CustomerID" });
            DropIndex("dbo.EmployeeModels", new[] { "DayID" });
            DropTable("dbo.EmployeeModels");
        }
    }
}
