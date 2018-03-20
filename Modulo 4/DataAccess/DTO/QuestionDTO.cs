using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class QuestionDTO
    {
        [Key]
        public int QuestionId { get; set; }

        public string Description { get; set; }
    }
}
