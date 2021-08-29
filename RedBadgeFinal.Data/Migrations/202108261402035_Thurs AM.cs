namespace RedBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThursAM : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Provider", name: "ServiceId", newName: "ServiceName");
            RenameIndex(table: "dbo.Provider", name: "IX_ServiceId", newName: "IX_ServiceName");
            DropColumn("dbo.Client", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "MyProperty", c => c.Int(nullable: false));
            RenameIndex(table: "dbo.Provider", name: "IX_ServiceName", newName: "IX_ServiceId");
            RenameColumn(table: "dbo.Provider", name: "ServiceName", newName: "ServiceId");
        }
    }
}
