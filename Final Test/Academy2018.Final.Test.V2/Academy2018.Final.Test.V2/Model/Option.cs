using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy2018.Final.Test.V2.Domain.Model
{
    public class Option : Entity
    {
        public string Text { get; set; }

        public int ScoreValue { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public Option()
        {
            Questions = new HashSet<Question>();
        }
    }
}
