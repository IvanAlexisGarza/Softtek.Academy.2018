using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static School.Helper.StructHelper;

namespace School.DTO
{
    public class CourseDTO
    {
        public int ClassId { get; set; }

        public int TeacherId { get; set; }

        public int CourseId { get; set; }

        public CourseDay[] Schedule { get; set; }
    }
}
