namespace PC_Servis.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Operatörler", "TeknisyenID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Operatörler", "TeknisyenID");
            AddForeignKey("dbo.Operatörler", "TeknisyenID", "dbo.Teknisyenler", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Operatörler", "TeknisyenID", "dbo.Teknisyenler");
            DropIndex("dbo.Operatörler", new[] { "TeknisyenID" });
            DropColumn("dbo.Operatörler", "TeknisyenID");
        }
    }
}
