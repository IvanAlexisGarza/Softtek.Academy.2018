using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesEF.Entities
{
    [Table("QuestionType")]
    public class QuestionType
    {
        [Key]
        [Column("ID", Order = 1)]
        public int QuestionTypeId { get; set; }

        [Column("Description", Order =2, TypeName = "nVarchar")]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
