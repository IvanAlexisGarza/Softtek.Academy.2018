using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Question
    {
        public int id { get; set; };
        public string name { get; set; };
        public char idTQuestionType { get; set; };
        public string description { get; set; };
        public string comments { get; set; };
        public bool isActive { get; set; };
        public bool isRequiered { get; set; };
    }
}
