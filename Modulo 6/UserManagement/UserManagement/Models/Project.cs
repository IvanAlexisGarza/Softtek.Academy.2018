using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserManagement.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Area { get; set; }

        public string TechnologyStack { get; set; }

        public virtual ICollection<User> Colaborators { get; set; }

        public Project()
        {
            Colaborators = new HashSet<User>();
        }
    }
}