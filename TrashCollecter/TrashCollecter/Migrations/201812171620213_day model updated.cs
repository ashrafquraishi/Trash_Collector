namespace TrashCollecter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class daymodelupdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Daymodels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VacationStart = c.DateTime(nullable: false),
                        VacationEnd = c.DateTime(nullable: false),
                        PickupDay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CustomerModels", "PickUpDay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerModels", "PickUpDay");
            DropTable("dbo.Daymodels");
        }
    }
}
