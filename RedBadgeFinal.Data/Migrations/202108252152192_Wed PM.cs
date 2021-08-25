namespace RedBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WedPM : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Location", "ServiceId", "dbo.Service");
            DropIndex("dbo.Location", new[] { "ServiceId" });
            DropColumn("dbo.Location", "ServiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Location", "ServiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Location", "ServiceId");
            AddForeignKey("dbo.Location", "ServiceId", "dbo.Service", "ServiceId", cascadeDelete: true);
        }
    }
}
