namespace RedBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _200 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Provider", "ServiceId", "dbo.Service");
            DropIndex("dbo.Provider", new[] { "ServiceId" });
            CreateTable(
                "dbo.ProviderService",
                c => new
                    {
                        Provider_ProvId = c.Int(nullable: false),
                        Service_ServiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Provider_ProvId, t.Service_ServiceId })
                .ForeignKey("dbo.Provider", t => t.Provider_ProvId, cascadeDelete: true)
                .ForeignKey("dbo.Service", t => t.Service_ServiceId, cascadeDelete: true)
                .Index(t => t.Provider_ProvId)
                .Index(t => t.Service_ServiceId);
            
            DropColumn("dbo.Provider", "ServiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Provider", "ServiceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProviderService", "Service_ServiceId", "dbo.Service");
            DropForeignKey("dbo.ProviderService", "Provider_ProvId", "dbo.Provider");
            DropIndex("dbo.ProviderService", new[] { "Service_ServiceId" });
            DropIndex("dbo.ProviderService", new[] { "Provider_ProvId" });
            DropTable("dbo.ProviderService");
            CreateIndex("dbo.Provider", "ServiceId");
            AddForeignKey("dbo.Provider", "ServiceId", "dbo.Service", "ServiceId", cascadeDelete: true);
        }
    }
}
