namespace DiagnosticCenterManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newmig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 45),
                    })
                .PrimaryKey(t => t.UserId);
            
            AddForeignKey("dbo.Doctors", "UserId", "dbo.Admins", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
        }
    }
}
