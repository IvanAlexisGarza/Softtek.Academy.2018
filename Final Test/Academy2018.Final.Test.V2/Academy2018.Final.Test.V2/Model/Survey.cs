using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy2018.Final.Test.V2.Domain.Model
{
    public class Survey : Entity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public Survey()
        {
            Questions = new HashSet<Question>();
        }
    }
}
