using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.Entities
{
    public class Asignation
    {
        public int AsignationId { get; set; }

        [ForeignKey("Class")]
        public int ClassId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public int Grade { get; set; }

        public virtual Class Class { get; set; }

        public virtual StudentDTO Student { get; set; }
    }
}
