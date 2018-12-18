namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecialPickups", "Address", c => c.Int(nullable: false));
            AddColumn("dbo.SpecialPickups", "ZipCode", c => c.Int(nullable: false));
            AddColumn("dbo.SpecialPickups", "ItemDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SpecialPickups", "ItemDescription");
            DropColumn("dbo.SpecialPickups", "ZipCode");
            DropColumn("dbo.SpecialPickups", "Address");
        }
    }
}
