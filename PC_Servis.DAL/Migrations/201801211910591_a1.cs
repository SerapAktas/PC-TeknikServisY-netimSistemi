namespace PC_Servis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArizaDurumlar",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        ArizaID = c.Int(nullable: false),
                        TeknisyenID = c.String(maxLength: 128),
                        GarantiKapsamindaMi = c.Boolean(nullable: false),
                        ArizaGiderildiMi = c.Boolean(nullable: false),
                        TamamlanmaZamani = c.DateTime(nullable: false),
                        Aciklama = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Arizalar", t => t.ArizaID, cascadeDelete: true)
                .ForeignKey("dbo.Teknisyenler", t => t.TeknisyenID)
                .Index(t => t.ArizaID)
                .Index(t => t.TeknisyenID);
            
            CreateTable(
                "dbo.Arizalar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        Aciklama = c.String(nullable: false),
                        Konum = c.String(nullable: false),
                        OlusturulmaTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.Fotograflar",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DosyaYol = c.String(nullable: false),
                        ArizaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Arizalar", t => t.ArizaID, cascadeDelete: true)
                .Index(t => t.ArizaID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(maxLength: 25),
                        Surname = c.String(maxLength: 25),
                        RegisterDate = c.DateTime(nullable: false),
                        ActivationCode = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MessageDate = c.DateTime(nullable: false),
                        Content = c.String(nullable: false),
                        SendBy = c.String(nullable: false, maxLength: 128),
                        SentTo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.SendBy, cascadeDelete: true)
                .Index(t => t.SendBy);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Teknisyenler",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        UserID = c.String(maxLength: 128),
                        BostaMi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID);
            
            CreateTable(
                "dbo.ArizaRaporlar",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        ArizaDurumID = c.String(maxLength: 128),
                        Rapor = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ArizaDurumlar", t => t.ArizaDurumID)
                .Index(t => t.ArizaDurumID);
            
            CreateTable(
                "dbo.Operatörler",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        UserID = c.String(maxLength: 128),
                        ArizaID = c.Int(nullable: false),
                        OnayladiMi = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Arizalar", t => t.ArizaID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.ArizaID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(maxLength: 200),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Operatörler", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Operatörler", "ArizaID", "dbo.Arizalar");
            DropForeignKey("dbo.ArizaRaporlar", "ArizaDurumID", "dbo.ArizaDurumlar");
            DropForeignKey("dbo.Teknisyenler", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.ArizaDurumlar", "TeknisyenID", "dbo.Teknisyenler");
            DropForeignKey("dbo.Arizalar", "UserID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "SendBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Fotograflar", "ArizaID", "dbo.Arizalar");
            DropForeignKey("dbo.ArizaDurumlar", "ArizaID", "dbo.Arizalar");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Operatörler", new[] { "ArizaID" });
            DropIndex("dbo.Operatörler", new[] { "UserID" });
            DropIndex("dbo.ArizaRaporlar", new[] { "ArizaDurumID" });
            DropIndex("dbo.Teknisyenler", new[] { "UserID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "SendBy" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Fotograflar", new[] { "ArizaID" });
            DropIndex("dbo.Arizalar", new[] { "UserID" });
            DropIndex("dbo.ArizaDurumlar", new[] { "TeknisyenID" });
            DropIndex("dbo.ArizaDurumlar", new[] { "ArizaID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Operatörler");
            DropTable("dbo.ArizaRaporlar");
            DropTable("dbo.Teknisyenler");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Messages");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Fotograflar");
            DropTable("dbo.Arizalar");
            DropTable("dbo.ArizaDurumlar");
        }
    }
}
