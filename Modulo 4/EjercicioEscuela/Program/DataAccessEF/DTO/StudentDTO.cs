using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.Entities
{
    public class StudentDTO
    {
        public string Names { get; set; }

        public string LastName { get; set; }

        public string SecondLastName { get; set; }

        public int StudentId { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }
    }
}
