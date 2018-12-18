namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ddn : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Daymodels", "PickupDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Daymodels", "PickupDay", c => c.Int(nullable: false));
        }
    }
}
