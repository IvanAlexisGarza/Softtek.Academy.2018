using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessEF.Helper;
using static DataAccessEF.Helper.StructHelper;

namespace DataAccessEF.Entities
{
    public class Class
    {
        public int ClassId { get; set; }

        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public ClassDay[] Schedule { get; set; }

        public virtual Teacher Teacher { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<Asignation> Asignations { get; set; }

        public Class()
        {
            //Days of the week
            Schedule = new ClassDay[5];
        }
    }
}
