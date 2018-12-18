namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SpecialPickups", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.SpecialPickups", "ApplicationUserId");
            AddForeignKey("dbo.SpecialPickups", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecialPickups", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.SpecialPickups", new[] { "ApplicationUserId" });
            DropColumn("dbo.SpecialPickups", "ApplicationUserId");
        }
    }
}
