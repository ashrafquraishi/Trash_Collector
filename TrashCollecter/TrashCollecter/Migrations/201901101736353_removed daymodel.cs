namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeddaymodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeModels", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EmployeeModels", "CustomerID", "dbo.CustomerModels");
            DropForeignKey("dbo.EmployeeModels", "DayID", "dbo.Daymodels");
            DropForeignKey("dbo.EmployeeModels", "SpecialPickupID", "dbo.SpecialPickups");
            DropIndex("dbo.EmployeeModels", new[] { "DayID" });
            DropIndex("dbo.EmployeeModels", new[] { "CustomerID" });
            DropIndex("dbo.EmployeeModels", new[] { "SpecialPickupID" });
            DropIndex("dbo.EmployeeModels", new[] { "ApplicationId" });
            AddColumn("dbo.CustomerModels", "VacationStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.CustomerModels", "VacationEnd", c => c.DateTime(nullable: false));
            DropTable("dbo.EmployeeModels");
            DropTable("dbo.Daymodels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Daymodels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VacationStart = c.DateTime(nullable: false),
                        VacationEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        DayID = c.Int(),
                        CustomerID = c.Int(),
                        SpecialPickupID = c.Int(),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.CustomerModels", "VacationEnd");
            DropColumn("dbo.CustomerModels", "VacationStart");
            CreateIndex("dbo.EmployeeModels", "ApplicationId");
            CreateIndex("dbo.EmployeeModels", "SpecialPickupID");
            CreateIndex("dbo.EmployeeModels", "CustomerID");
            CreateIndex("dbo.EmployeeModels", "DayID");
            AddForeignKey("dbo.EmployeeModels", "SpecialPickupID", "dbo.SpecialPickups", "Id");
            AddForeignKey("dbo.EmployeeModels", "DayID", "dbo.Daymodels", "Id");
            AddForeignKey("dbo.EmployeeModels", "CustomerID", "dbo.CustomerModels", "Id");
            AddForeignKey("dbo.EmployeeModels", "ApplicationId", "dbo.AspNetUsers", "Id");
        }
    }
}
