using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public string Name { get; set; }

        public int Credits { get; set; }

        public Subject()
        {
            SubjectTeachers = new HashSet<Teacher>();
        }

        public ICollection<Teacher> SubjectTeachers { get; set; }
    }
}
