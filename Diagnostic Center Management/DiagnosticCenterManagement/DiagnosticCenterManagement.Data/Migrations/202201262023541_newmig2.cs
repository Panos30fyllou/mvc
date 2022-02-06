namespace DiagnosticCenterManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmig2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Doctors", "UserId", "dbo.Adminbs");
            DropTable("dbo.Adminbs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Adminbs",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 45),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddForeignKey("dbo.Doctors", "UserId", "dbo.Adminbs", "UserId", cascadeDelete: true);
        }
    }
}
