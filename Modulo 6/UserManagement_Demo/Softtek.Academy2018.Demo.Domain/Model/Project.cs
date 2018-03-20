using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.Demo.Domain.Model
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
