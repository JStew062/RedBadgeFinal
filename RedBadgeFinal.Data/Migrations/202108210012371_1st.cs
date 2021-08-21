namespace RedBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1st : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceNote",
                c => new
                    {
                        ServiceId = c.Int(nullable: false),
                        NoteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ServiceId, t.NoteId })
                .ForeignKey("dbo.Note", t => t.NoteId, cascadeDelete: true)
                .ForeignKey("dbo.Service", t => t.ServiceId, cascadeDelete: true)
                .Index(t => t.ServiceId)
                .Index(t => t.NoteId);
            
            CreateTable(
                "dbo.Service",
                c => new
                    {
                        ServiceId = c.Int(nullable: false, identity: true),
                        ServiceName = c.String(),
                    })
                .PrimaryKey(t => t.ServiceId);
            
            AddColumn("dbo.Note", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Note", "ServiceName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "ServiceName", c => c.String(nullable: false));
            DropForeignKey("dbo.ServiceNote", "ServiceId", "dbo.Service");
            DropForeignKey("dbo.ServiceNote", "NoteId", "dbo.Note");
            DropIndex("dbo.ServiceNote", new[] { "NoteId" });
            DropIndex("dbo.ServiceNote", new[] { "ServiceId" });
            DropColumn("dbo.Note", "OwnerId");
            DropTable("dbo.Service");
            DropTable("dbo.ServiceNote");
        }
    }
}
