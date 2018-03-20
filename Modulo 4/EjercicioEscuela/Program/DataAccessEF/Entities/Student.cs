using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.Entities
{
    public class StudentDTO
    {
        public int StudentId { get; set; }

        public string Names { get; set; }

        public string LastName { get; set; }

        public string SecondLastName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Class> Workload { get; set; }

        public virtual ICollection<Asignation> Tasks { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsActive { get; set; }

        public DateTime LeavingDate { get; set; }

        public DateTime AdmissionDate { get; set; }
    }
}
