using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Domain.Model
{
    public class User
    {
        public int Id { get; set; }

        public string IS { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModDate { get; set; }

        public int Salary { get; set; }

        public bool IsActive { get; set; }

        public int Role { get; set; }

        public ICollection<Project> Projects { get; set; }

        public User()
        {
            Projects = new HashSet<Project>();
        }
    }
}
