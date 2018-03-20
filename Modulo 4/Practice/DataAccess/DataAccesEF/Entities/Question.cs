using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesEF.Entities
{
    public class Question
    {
        public int QuestionId { get; set; }

        public string Text { get; set; }

        public bool IsActive { get; set; }

        public bool IsRequired { get; set; }

        [ForeignKey("QuestionType")]
        public int QuestionTypeId { get; set; }

        //Basicly the table link 1 to 1
        public virtual QuestionType QuestionType { get; set; }

        public virtual ICollection<Option> Options { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }

    }
}
