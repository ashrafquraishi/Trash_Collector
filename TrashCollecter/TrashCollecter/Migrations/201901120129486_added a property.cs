namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedaproperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "bill", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerModels", "bill");
        }
    }
}
