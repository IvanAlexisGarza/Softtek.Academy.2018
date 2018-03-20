using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesEF.Entities
{
    public class Option
    {
        public int OptionId { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
