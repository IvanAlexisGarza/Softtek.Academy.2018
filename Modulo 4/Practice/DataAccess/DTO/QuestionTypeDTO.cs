using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class QuestionTypeDTO
    {
        public int QestuionTypeId { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
