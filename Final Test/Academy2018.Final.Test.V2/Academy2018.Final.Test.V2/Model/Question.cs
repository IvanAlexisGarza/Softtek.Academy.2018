using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy2018.Final.Test.V2.Domain.Model
{
    public class Question : Entity
    {
        public string Text { get; set; }

        public int QuestionTypeId { get; set; }

        public virtual QuestionType QuestionType { get; set; }


        public virtual ICollection<Survey> Surveys { get; set; }

        public List<int> OptionId { get; set; }
        public virtual ICollection<Option> Options { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        public Question()
        {
            OptionId = new List<int>();
            Surveys = new HashSet<Survey>();
            Options = new HashSet<Option>();
        }
    }
}
