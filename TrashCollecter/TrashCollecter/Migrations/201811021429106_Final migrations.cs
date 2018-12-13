namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Finalmigrations : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerModels", "Balance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerModels", "Balance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
