using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School;
using System.Data.Entity;
using School.Entities;
using School.DTO;
using School.Implementation;
using School.Interfaces;
using static School.Helper.StructHelper;

namespace School.Helper
{
    public class DemoInitializer : DropCreateDatabaseAlways<DemoContext>
    {
        public void Filler()
        {
            using (var context =  new DemoContext())
            {
                List<Subject> _subjectList = new List<Subject>();
                
                Student student1 = new Student
                {
                    FirstNames = "Zelda",
                    LastName = "Zelda",
                    Email = "NotANinja@Hyrule.com",
                    IsActive = true,
                    BirthDay = new DateTime(1994, 05, 27),
                    RegistrationDate = DateTime.Now,
                    DropOut = new DateTime(2008, 5, 1),
                };

                context.Students.Add(new Student
                {
                    FirstNames = "Zelda",
                    LastName = "Zelda",
                    Email = "NotANinja@Hyrule.com",
                    IsActive = true,
                    BirthDay = new DateTime(1994, 05, 27),
                    RegistrationDate = DateTime.Now,
                    DropOut = new DateTime(2008, 5, 1),
                });

                Student men = new Student
                {
                    FirstNames = "Mario",
                    LastName = "Mario",
                    Email = "PlumbingRed@Hyrule.com",
                    IsActive = true,
                    BirthDay = new DateTime(1987, 04, 21),
                    RegistrationDate = DateTime.Now,
                    DropOut = new DateTime(1998, 5, 1),
                    Courses = context.Courses.Where(x => x.CourseId == 1).ToList()
                };

                context.Teachers.Add(new Teacher
                {
                    Names = "Ivan",
                    SecondLastName = "Tapia",
                    //Subjects = context.Subjects.Where(x => x.SubjectId == 1).ToList()
                });

                context.Subjects.Add(new Subject
                {
                    Name = "Ping-Pong",
                    Credits = 3,
                    //SubjectTeachers = context.Teachers.Where(x => x.TeacherId == 1).ToList()
                });

                context.Subjects.Add(new Subject
                {
                    Name = "Math",
                    Credits = 6,
                    //SubjectTeachers = context.Teachers.Where(x => x.TeacherId == 1).ToList()
                });

                context.Subjects.Add(new Subject
                {
                    Name = "Science",
                    Credits = 6,
                    //SubjectTeachers = context.Teachers.Where(x => x.TeacherId == 1).ToList()
                });

                context.Teachers.Add(new Teacher
                {
                    Names = "Tavo",
                    SecondLastName = "Tavo",
                    Subjects = context.Subjects.Where(x => x.SubjectId == 1).ToList()
                });

                context.Courses.Add(new Course
                {
                    CourseDescription = "Por la realización plena del hombre",
                    CourseName = "UABC Induction",
                    CourseStudents = context.Students.Where(x => x.StudentId == 1).ToList(),
                    CourseTeacher = context.Teachers.Where(x => x.TeacherId == 1).FirstOrDefault(),
                });

                context.Students.Add(men);
                context.Students.Add(student1);

                context.SaveChanges();
            } 
        }

        protected override void Seed(DemoContext context)
        {
            IRepository<StudentDTO> studentRepository = new StudentEF();
        }

    }
}
