namespace RedBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wedam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location", "ServiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Location", "ServiceId");
            AddForeignKey("dbo.Location", "ServiceId", "dbo.Service", "ServiceId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Location", "ServiceId", "dbo.Service");
            DropIndex("dbo.Location", new[] { "ServiceId" });
            DropColumn("dbo.Location", "ServiceId");
        }
    }
}
