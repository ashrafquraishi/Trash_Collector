namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedspecialpickupincustomermodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "SpecialPickupDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerModels", "SpecialPickupDate");
        }
    }
}
