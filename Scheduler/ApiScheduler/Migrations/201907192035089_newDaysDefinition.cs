namespace ApiScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDaysDefinition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HistoryShifts", "StartDay", c => c.Int(nullable: false));
            AddColumn("dbo.HistoryShifts", "EndDay", c => c.Int(nullable: false));
            AddColumn("dbo.Shifts", "StartDay", c => c.Int(nullable: false));
            AddColumn("dbo.Shifts", "EndDay", c => c.Int(nullable: false));
            DropColumn("dbo.HistoryShifts", "Day");
            DropColumn("dbo.Shifts", "Day");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Shifts", "Day", c => c.Int(nullable: false));
            AddColumn("dbo.HistoryShifts", "Day", c => c.Int(nullable: false));
            DropColumn("dbo.Shifts", "EndDay");
            DropColumn("dbo.Shifts", "StartDay");
            DropColumn("dbo.HistoryShifts", "EndDay");
            DropColumn("dbo.HistoryShifts", "StartDay");
        }
    }
}
