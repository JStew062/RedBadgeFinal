namespace RedBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2nd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
                        MyProperty = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                        CaseMgr = c.String(),
                    })
                .PrimaryKey(t => t.ClientId)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        County = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateTable(
                "dbo.Provider",
                c => new
                    {
                        ProvId = c.Int(nullable: false, identity: true),
                        ProvName = c.String(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProvId)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            AddColumn("dbo.Service", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Service", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Provider", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Client", "LocationId", "dbo.Location");
            DropIndex("dbo.Provider", new[] { "LocationId" });
            DropIndex("dbo.Client", new[] { "LocationId" });
            DropColumn("dbo.Service", "ModifiedUtc");
            DropColumn("dbo.Service", "CreatedUtc");
            DropTable("dbo.Provider");
            DropTable("dbo.Location");
            DropTable("dbo.Client");
        }
    }
}
