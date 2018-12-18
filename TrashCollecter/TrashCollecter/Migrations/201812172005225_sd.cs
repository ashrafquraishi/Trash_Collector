namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpecialPickups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpecialPickup1 = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SpecialPickups");
        }
    }
}
