namespace RedBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tuesam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Provider", "ServiceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Provider", "ServiceId");
            AddForeignKey("dbo.Provider", "ServiceId", "dbo.Service", "ServiceId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Provider", "ServiceId", "dbo.Service");
            DropIndex("dbo.Provider", new[] { "ServiceId" });
            DropColumn("dbo.Provider", "ServiceId");
        }
    }
}
