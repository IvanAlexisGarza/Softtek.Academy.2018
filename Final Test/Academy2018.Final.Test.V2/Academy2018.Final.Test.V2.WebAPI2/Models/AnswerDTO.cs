using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy2018.Final.Test.V2.WebAPI2.Models
{
    public class AnswerDTO
    {
        public int SurveyId { get; set; }

        public int QuestionId { get; set; }

        public int OptionId { get; set; }

        public string OpenText { get; set; }
    }
}