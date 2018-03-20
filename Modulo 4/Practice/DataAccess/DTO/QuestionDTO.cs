using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class QuestionDTO
    {
        public int QuestionId { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public QuestionTypeDTO QuestionTypeId { get; set; }

        public IEnumerable<OptionDTO> Options { get; set; }
    }
}
