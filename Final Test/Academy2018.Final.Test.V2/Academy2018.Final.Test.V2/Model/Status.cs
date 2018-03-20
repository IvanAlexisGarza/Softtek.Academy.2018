using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy2018.Final.Test.V2.Domain.Model
{
    public class Status : Entity
    {
        public string Description { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }

        public Status()
        {
            Surveys = new HashSet<Survey>();
        }
    }
}