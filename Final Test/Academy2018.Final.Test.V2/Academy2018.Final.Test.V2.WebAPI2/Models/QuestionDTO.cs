using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Academy2018.Final.Test.V2.WebAPI2.Models
{
    public class QuestionDTO
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int QuestionTypeId { get; set; }
    }
}