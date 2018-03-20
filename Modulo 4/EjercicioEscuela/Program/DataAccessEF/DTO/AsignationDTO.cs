using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.Entities
{
    public class AsignationDTO
    {
        public int AsignationId { get; set; }

        public int StudentId { get; set; }

        public int ClassId { get; set; }

        public int Grade { get; set; }
    }
}
