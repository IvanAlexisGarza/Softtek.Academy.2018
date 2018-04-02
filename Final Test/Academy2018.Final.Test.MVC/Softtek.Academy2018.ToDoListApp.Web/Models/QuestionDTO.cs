using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softtek.Academy2018.ToDoListApp.Web.Models
{
    public class QuestionDTO
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int QuestionTypeId { get; set; }

        public int SurveyId { get; set; }

        public ICollection<OptionDTO> Options { get; set; }

        public QuestionDTO()
        {
            Options = new HashSet<OptionDTO>();
        }
    }
}