namespace ApiScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ex : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        Password = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Division",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HistoryShifts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ShiftId = c.String(),
                        UserId = c.String(),
                        WardId = c.String(),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        Day = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NextOfKins",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserID = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Relationship = c.String(),
                        Contact = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        WardId = c.String(),
                        StartTime = c.Time(nullable: false, precision: 7),
                        EndTime = c.Time(nullable: false, precision: 7),
                        Day = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        AccountId = c.String(),
                        WardId = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Contact = c.String(),
                        Gender = c.String(),
                        MedicalIssues = c.String(),
                        MaritalStatus = c.String(),
                        Profession = c.String(),
                        Address = c.String(),
                        DoB = c.DateTime(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                        Password = c.String(),
                        IsAdmin = c.Boolean(),
                        Date = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Wards",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DivisionId = c.String(),
                        InchargeId = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        NumberOfWorkers = c.Int(nullable: false),
                        MinimunHoursAday = c.Int(nullable: false),
                        MaximumHoursAday = c.Int(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "User_Id", "dbo.User");
            DropIndex("dbo.User", new[] { "User_Id" });
            DropTable("dbo.Wards");
            DropTable("dbo.User");
            DropTable("dbo.Shifts");
            DropTable("dbo.NextOfKins");
            DropTable("dbo.HistoryShifts");
            DropTable("dbo.Division");
            DropTable("dbo.Accounts");
        }
    }
}
