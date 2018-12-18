namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerModels", "Address");
            DropColumn("dbo.CustomerModels", "Zipcode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerModels", "Zipcode", c => c.Int(nullable: false));
            AddColumn("dbo.CustomerModels", "Address", c => c.String());
        }
    }
}
