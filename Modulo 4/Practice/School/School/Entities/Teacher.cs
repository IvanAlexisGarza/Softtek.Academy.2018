using School.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string Names { get; set; }

        public string LastName { get; set; }

        public string SecondLastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public  Teacher() //Inicializa la colleccion porque si no se crea un objeto nulo
        {
            Subjects = new HashSet<Subject>();
            Courses = new HashSet<Course>();
        }

        public ICollection<Subject> Subjects { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
