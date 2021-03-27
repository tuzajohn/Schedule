namespace ApiScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _healthFacility : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HealthCenter",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Address = c.String(),
                        Director = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HealthCenter");
        }
    }
}
