using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class OptionDTO
    {
        public string Text { get; set; }
        public int OptionId { get; set; }
        public ICollection<QuestionDTO> QuestionId { get; set; }
        public string Value { get; set; }
    }
}
