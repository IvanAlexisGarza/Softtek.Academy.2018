using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Softtek.Academy2018.ToDoListApp.Web.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int QuestionTypeId { get; set; }
    }
}