namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adding : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SpecialPickups", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.SpecialPickups", new[] { "ApplicationUserId" });
            DropTable("dbo.SpecialPickups");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SpecialPickups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpecialPickup1 = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        Address = c.String(),
                        ZipCode = c.Int(nullable: false),
                        ItemDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.SpecialPickups", "ApplicationUserId");
            AddForeignKey("dbo.SpecialPickups", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
