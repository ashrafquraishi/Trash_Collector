namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        ZipCode = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeModels", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.EmployeeModels", new[] { "ApplicationUserId" });
            DropTable("dbo.EmployeeModels");
        }
    }
}
