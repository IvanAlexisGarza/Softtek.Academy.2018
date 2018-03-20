using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataAccessEF.Helper.StructHelper;

namespace DataAccessEF.Entities
{
    public class ClassDTO
    {
        public int ClassId { get; set; }

        public int TeacherId { get; set; }

        public int CourseId { get; set; }

        public ClassDay[] Schedule { get; set; }
    }
}
