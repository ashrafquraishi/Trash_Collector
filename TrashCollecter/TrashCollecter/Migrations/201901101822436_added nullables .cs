namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednullables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "Confirm", c => c.Boolean());
            AlterColumn("dbo.CustomerModels", "VacationStart", c => c.DateTime());
            AlterColumn("dbo.CustomerModels", "VacationEnd", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CustomerModels", "VacationEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CustomerModels", "VacationStart", c => c.DateTime(nullable: false));
            DropColumn("dbo.CustomerModels", "Confirm");
        }
    }
}
