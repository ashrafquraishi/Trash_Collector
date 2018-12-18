namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDayMoel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "Street", c => c.String());
            AddColumn("dbo.CustomerModels", "ZipCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerModels", "ZipCode");
            DropColumn("dbo.CustomerModels", "Street");
        }
    }
}
