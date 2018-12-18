namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SpecialPickups", "Address", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SpecialPickups", "Address", c => c.Int(nullable: false));
        }
    }
}
