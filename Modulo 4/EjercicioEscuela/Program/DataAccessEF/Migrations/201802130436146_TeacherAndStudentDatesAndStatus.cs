namespace DataAccessEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherAndStudentDatesAndStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teacher", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.Teacher", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Teacher", "LeavingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Teacher", "HireDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Student", "Birthday", c => c.DateTime(nullable: false));
            AddColumn("dbo.Student", "IsActive", c => c.Boolean(nullable: false));
            AddColumn("dbo.Student", "LeavingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Student", "AdmissionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "AdmissionDate");
            DropColumn("dbo.Student", "LeavingDate");
            DropColumn("dbo.Student", "IsActive");
            DropColumn("dbo.Student", "Birthday");
            DropColumn("dbo.Teacher", "HireDate");
            DropColumn("dbo.Teacher", "LeavingDate");
            DropColumn("dbo.Teacher", "IsActive");
            DropColumn("dbo.Teacher", "Birthday");
        }
    }
}
