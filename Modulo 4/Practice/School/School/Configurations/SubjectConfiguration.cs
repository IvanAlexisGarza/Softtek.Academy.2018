using School.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Configurations
{
    public class SubjectConfiguration : EntityTypeConfiguration<Subject>
    {
        public SubjectConfiguration()
        {
            this.HasKey(x => x.SubjectId);

            this.Property(x => x.Name).IsRequired();
            this.Property(x => x.Credits).IsOptional();
            this.HasOptional(x => x.SubjectTeachers);


        }
    }
}
