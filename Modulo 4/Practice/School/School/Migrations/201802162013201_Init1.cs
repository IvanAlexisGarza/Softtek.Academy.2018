namespace School.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        FirstNames = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        SecondLastName = c.String(maxLength: 50),
                        Email = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        BirthDay = c.DateTime(nullable: false),
                        RegistrationDate = c.DateTime(nullable: false),
                        DropOut = c.DateTime(),
                        Age = c.Int(),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        CourseDescription = c.String(),
                        CourseTeacher_TeacherId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Teachers", t => t.CourseTeacher_TeacherId)
                .Index(t => t.CourseTeacher_TeacherId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        Names = c.String(),
                        LastName = c.String(),
                        SecondLastName = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.SubjectTeachers",
                c => new
                    {
                        Teacher = c.Int(nullable: false),
                        Subject_SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher, t.Subject_SubjectId })
                .ForeignKey("dbo.Teachers", t => t.Teacher, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.Subject_SubjectId, cascadeDelete: true)
                .Index(t => t.Teacher)
                .Index(t => t.Subject_SubjectId);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        Course = c.Int(nullable: false),
                        Student = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Course, t.Student })
                .ForeignKey("dbo.Student", t => t.Course, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.Student, cascadeDelete: true)
                .Index(t => t.Course)
                .Index(t => t.Student);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "Student", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "Course", "dbo.Student");
            DropForeignKey("dbo.SubjectTeachers", "Subject_SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.SubjectTeachers", "Teacher", "dbo.Teachers");
            DropForeignKey("dbo.Courses", "CourseTeacher_TeacherId", "dbo.Teachers");
            DropIndex("dbo.StudentCourses", new[] { "Student" });
            DropIndex("dbo.StudentCourses", new[] { "Course" });
            DropIndex("dbo.SubjectTeachers", new[] { "Subject_SubjectId" });
            DropIndex("dbo.SubjectTeachers", new[] { "Teacher" });
            DropIndex("dbo.Courses", new[] { "CourseTeacher_TeacherId" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.SubjectTeachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Teachers");
            DropTable("dbo.Courses");
            DropTable("dbo.Student");
        }
    }
}
