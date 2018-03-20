using DataAccessEF.Entities;
using DataAccessEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessEF.Helper.StructHelper;

namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRepository<TeacherDTO> teacherRepository = new TeacherEF();
            IRepository<StudentDTO> studentRepository = new StudentEF();
            IRepository<CourseDTO> courseRepository = new CourseEF();
            IRepository<ClassDTO> classRepository = new ClassEF();

            courseRepository.Create(new CourseDTO { CourseName = "OOP", Credits = 6});

            ClassDay lunesOOP = new ClassDay();

            lunesOOP.StartTime = DateTime.Now;
            lunesOOP.EndTime = DateTime.Now.AddHours(2);

            classRepository.Create(new ClassDTO { CourseId = 1, TeacherId = 1});

            Console.Read();
        }
    }
}
