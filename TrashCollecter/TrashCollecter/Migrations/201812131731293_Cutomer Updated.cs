namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CutomerUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "Address", c => c.String());
            AddColumn("dbo.CustomerModels", "Zipcode", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerModels", "Zipcode");
            DropColumn("dbo.CustomerModels", "Address");
        }
    }
}
