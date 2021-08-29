namespace RedBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Thurs330 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Provider", name: "ServiceName", newName: "ServiceId");
            RenameIndex(table: "dbo.Provider", name: "IX_ServiceName", newName: "IX_ServiceId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Provider", name: "IX_ServiceId", newName: "IX_ServiceName");
            RenameColumn(table: "dbo.Provider", name: "ServiceId", newName: "ServiceName");
        }
    }
}
