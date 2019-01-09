namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class thing2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerModels",
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
                        PickUpDay = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.EmployeeModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Street = c.String(),
                        ZipCode = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        DayID = c.Int(),
                        CustomerID = c.Int(),
                        SpecialPickupID = c.Int(),
                        ApplicationId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationId)
                .ForeignKey("dbo.CustomerModels", t => t.CustomerID)
                .ForeignKey("dbo.Daymodels", t => t.DayID)
                .ForeignKey("dbo.SpecialPickups", t => t.SpecialPickupID)
                .Index(t => t.DayID)
                .Index(t => t.CustomerID)
                .Index(t => t.SpecialPickupID)
                .Index(t => t.ApplicationId);
            
            CreateTable(
                "dbo.Daymodels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VacationStart = c.DateTime(nullable: false),
                        VacationEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.EmployeeModels", "SpecialPickupID", "dbo.SpecialPickups");
            DropForeignKey("dbo.SpecialPickups", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EmployeeModels", "DayID", "dbo.Daymodels");
            DropForeignKey("dbo.EmployeeModels", "CustomerID", "dbo.CustomerModels");
            DropForeignKey("dbo.EmployeeModels", "ApplicationId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CustomerModels", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SpecialPickups", new[] { "ApplicationUserId" });
            DropIndex("dbo.EmployeeModels", new[] { "ApplicationId" });
            DropIndex("dbo.EmployeeModels", new[] { "SpecialPickupID" });
            DropIndex("dbo.EmployeeModels", new[] { "CustomerID" });
            DropIndex("dbo.EmployeeModels", new[] { "DayID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.CustomerModels", new[] { "ApplicationUserId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SpecialPickups");
            DropTable("dbo.Daymodels");
            DropTable("dbo.EmployeeModels");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.CustomerModels");
        }
    }
}
