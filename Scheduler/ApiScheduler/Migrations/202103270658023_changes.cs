namespace ApiScheduler.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "HeighestLvlEducaTION", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "HeighestLvlEducaTION");
        }
    }
}
