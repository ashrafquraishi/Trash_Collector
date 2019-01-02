namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeModels", "CustomerID", "dbo.CustomerModels");
            DropForeignKey("dbo.EmployeeModels", "DayID", "dbo.Daymodels");
            DropForeignKey("dbo.EmployeeModels", "SpecialPickupID", "dbo.SpecialPickups");
            DropIndex("dbo.EmployeeModels", new[] { "DayID" });
            DropIndex("dbo.EmployeeModels", new[] { "CustomerID" });
            DropIndex("dbo.EmployeeModels", new[] { "SpecialPickupID" });
            AlterColumn("dbo.EmployeeModels", "DayID", c => c.Int());
            AlterColumn("dbo.EmployeeModels", "CustomerID", c => c.Int());
            AlterColumn("dbo.EmployeeModels", "SpecialPickupID", c => c.Int());
            CreateIndex("dbo.EmployeeModels", "DayID");
            CreateIndex("dbo.EmployeeModels", "CustomerID");
            CreateIndex("dbo.EmployeeModels", "SpecialPickupID");
            AddForeignKey("dbo.EmployeeModels", "CustomerID", "dbo.CustomerModels", "Id");
            AddForeignKey("dbo.EmployeeModels", "DayID", "dbo.Daymodels", "Id");
            AddForeignKey("dbo.EmployeeModels", "SpecialPickupID", "dbo.SpecialPickups", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeModels", "SpecialPickupID", "dbo.SpecialPickups");
            DropForeignKey("dbo.EmployeeModels", "DayID", "dbo.Daymodels");
            DropForeignKey("dbo.EmployeeModels", "CustomerID", "dbo.CustomerModels");
            DropIndex("dbo.EmployeeModels", new[] { "SpecialPickupID" });
            DropIndex("dbo.EmployeeModels", new[] { "CustomerID" });
            DropIndex("dbo.EmployeeModels", new[] { "DayID" });
            AlterColumn("dbo.EmployeeModels", "SpecialPickupID", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeModels", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeModels", "DayID", c => c.Int(nullable: false));
            CreateIndex("dbo.EmployeeModels", "SpecialPickupID");
            CreateIndex("dbo.EmployeeModels", "CustomerID");
            CreateIndex("dbo.EmployeeModels", "DayID");
            AddForeignKey("dbo.EmployeeModels", "SpecialPickupID", "dbo.SpecialPickups", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeModels", "DayID", "dbo.Daymodels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeModels", "CustomerID", "dbo.CustomerModels", "Id", cascadeDelete: true);
        }
    }
}
