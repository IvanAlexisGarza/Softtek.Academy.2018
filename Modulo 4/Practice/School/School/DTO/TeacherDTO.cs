using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DTO
{
    public class TeacherDTO
    {
        public int TeacherId { get; set; }

        public string Names { get; set; }

        public string LastName { get; set; }

        public string SecondLastName { get; set; }

        public string PhoneNumber { get; set; }

        public string  Email { get; set; }

        public bool IsActive { get; set; }

        public TeacherDTO() //Inicializa la colleccion porque si no se crea un objeto nulo
        {
            Subjects = new HashSet<SubjectDTO>();
            Courses = new HashSet<CourseDTO>();
        }

        public ICollection<SubjectDTO> Subjects { get; set; }

        public ICollection<CourseDTO> Courses { get; set; }
    }
}
