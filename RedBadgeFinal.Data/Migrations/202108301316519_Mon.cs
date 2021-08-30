namespace RedBadgeFinal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mon : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        ClientName = c.String(),
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
                "dbo.Note",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Content = c.String(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                        Service_ServiceId = c.Int(),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("dbo.Service", t => t.Service_ServiceId)
                .Index(t => t.Service_ServiceId);
            
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
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(precision: 7),
                    })
                .PrimaryKey(t => t.ServiceId);
            
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
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.ServiceNote", "ServiceId", "dbo.Service");
            DropForeignKey("dbo.Note", "Service_ServiceId", "dbo.Service");
            DropForeignKey("dbo.Provider", "LocationId", "dbo.Location");
            DropForeignKey("dbo.ProviderService", "Service_ServiceId", "dbo.Service");
            DropForeignKey("dbo.ProviderService", "Provider_ProvId", "dbo.Provider");
            DropForeignKey("dbo.ServiceNote", "NoteId", "dbo.Note");
            DropForeignKey("dbo.Client", "LocationId", "dbo.Location");
            DropIndex("dbo.ProviderService", new[] { "Service_ServiceId" });
            DropIndex("dbo.ProviderService", new[] { "Provider_ProvId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Provider", new[] { "LocationId" });
            DropIndex("dbo.ServiceNote", new[] { "NoteId" });
            DropIndex("dbo.ServiceNote", new[] { "ServiceId" });
            DropIndex("dbo.Note", new[] { "Service_ServiceId" });
            DropIndex("dbo.Client", new[] { "LocationId" });
            DropTable("dbo.ProviderService");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Provider");
            DropTable("dbo.Service");
            DropTable("dbo.ServiceNote");
            DropTable("dbo.Note");
            DropTable("dbo.Location");
            DropTable("dbo.Client");
        }
    }
}
