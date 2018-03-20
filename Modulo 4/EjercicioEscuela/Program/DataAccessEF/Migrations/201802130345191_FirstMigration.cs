namespace DataAccessEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asignation",
                c => new
                    {
                        AsignationId = c.Int(nullable: false, identity: true),
                        ClassId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Grade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AsignationId)
                .ForeignKey("dbo.Class", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.ClassId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Student_StudentId = c.Int(),
                    })
                .PrimaryKey(t => t.ClassId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Teacher", t => t.TeacherId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.Student_StudentId)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId)
                .Index(t => t.Student_StudentId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(nullable: false, maxLength: 150),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Teacher",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Names = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        SecondLastName = c.String(maxLength: 60),
                        PhoneNumber = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        Names = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        SecondLastName = c.String(maxLength: 60),
                        Age = c.Int(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Asignation", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Class", "Student_StudentId", "dbo.Student");
            DropForeignKey("dbo.Asignation", "ClassId", "dbo.Class");
            DropForeignKey("dbo.Class", "TeacherId", "dbo.Teacher");
            DropForeignKey("dbo.Class", "CourseId", "dbo.Course");
            DropIndex("dbo.Class", new[] { "Student_StudentId" });
            DropIndex("dbo.Class", new[] { "CourseId" });
            DropIndex("dbo.Class", new[] { "TeacherId" });
            DropIndex("dbo.Asignation", new[] { "StudentId" });
            DropIndex("dbo.Asignation", new[] { "ClassId" });
            DropTable("dbo.Student");
            DropTable("dbo.Teacher");
            DropTable("dbo.Course");
            DropTable("dbo.Class");
            DropTable("dbo.Asignation");
        }
    }
}
