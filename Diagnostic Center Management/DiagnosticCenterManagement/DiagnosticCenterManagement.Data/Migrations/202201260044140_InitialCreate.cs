namespace DiagnosticCenterManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 45),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorAMKA = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 45),
                        Name = c.String(maxLength: 45),
                        Surname = c.String(maxLength: 45),
                        Specialty = c.String(maxLength: 45),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DoctorAMKA)
                .ForeignKey("dbo.Admins", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Date = c.DateTime(nullable: false),
                        StartSlotTime = c.DateTime(nullable: false),
                        EndSlotTime = c.DateTime(nullable: false),
                        PatientAMKA = c.Int(nullable: false),
                        DoctorAMKA = c.Int(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Date)
                .ForeignKey("dbo.Doctors", t => t.DoctorAMKA, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.PatientAMKA, cascadeDelete: true)
                .Index(t => t.PatientAMKA)
                .Index(t => t.DoctorAMKA);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        PatientAMKA = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 45),
                        Name = c.String(nullable: false, maxLength: 45),
                        Surname = c.String(nullable: false, maxLength: 45),
                    })
                .PrimaryKey(t => t.PatientAMKA);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "PatientAMKA", "dbo.Patients");
            DropForeignKey("dbo.Appointments", "DoctorAMKA", "dbo.Doctors");
            DropForeignKey("dbo.Doctors", "UserId", "dbo.Admins");
            DropIndex("dbo.Appointments", new[] { "DoctorAMKA" });
            DropIndex("dbo.Appointments", new[] { "PatientAMKA" });
            DropIndex("dbo.Doctors", new[] { "UserId" });
            DropTable("dbo.Patients");
            DropTable("dbo.Appointments");
            DropTable("dbo.Doctors");
            DropTable("dbo.Admins");
        }
    }
}
