using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstNames { get; set; }

        public string LastName { get; set; }

        public string SecondLastName { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public DateTime BirthDay { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime DropOut { get; set; }

        public int Age
        { get { var age = DateTime.Today.Year - BirthDay.Year; return age; } set { Age = Age; } }

        public Student() //Inicializa la colleccion porque si no se crea un objeto nulo
        {
            Courses = new HashSet<Course>();
        }

        public ICollection<Course> Courses { get; set; }
    }
}
