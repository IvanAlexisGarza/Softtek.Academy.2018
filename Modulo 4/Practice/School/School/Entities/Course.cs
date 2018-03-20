using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static School.Helper.StructHelper;

namespace School.Entities
{
    public class Course
    {
        public int CourseId { get; set; }

        public Teacher CourseTeacher { get; set; }

        public string CourseName { get; set; }

        public string CourseDescription { get; set; }

        public CourseDay[] Schedule { get; set; }

        public Course() //Inicializa la colleccion porque si no se crea un objeto nulo
        {
            CourseStudents = new HashSet<Student>();
            CourseTeacher = new Teacher();
        }

        public ICollection<Student> CourseStudents { get; set; }
    }
}
