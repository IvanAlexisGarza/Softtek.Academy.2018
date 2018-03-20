using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessEF.Entities;

namespace DataAccessEF.Configurations
{
    public class ClassConfiguration : EntityTypeConfiguration<Class>
    {
        public ClassConfiguration()
        {
            this.ToTable("Class");
            this.HasKey(s => s.ClassId);



        }
    }
}
