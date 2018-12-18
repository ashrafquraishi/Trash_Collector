namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madeindexview : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerModels", "Address", c => c.String());
            AddColumn("dbo.CustomerModels", "City", c => c.String());
            AddColumn("dbo.CustomerModels", "State", c => c.String());
            DropColumn("dbo.CustomerModels", "Street");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerModels", "Street", c => c.String());
            DropColumn("dbo.CustomerModels", "State");
            DropColumn("dbo.CustomerModels", "City");
            DropColumn("dbo.CustomerModels", "Address");
        }
    }
}
