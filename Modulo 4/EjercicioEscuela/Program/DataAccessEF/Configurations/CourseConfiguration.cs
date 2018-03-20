using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessEF.Entities;

namespace DataAccessEF.Configurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            this.ToTable("Course");
            this.HasKey(c => c.CourseId);

            this.Property(c => c.Credits).IsRequired();
            this.Property(c => c.CourseName).IsRequired();
            this.Property(c => c.CourseName).HasMaxLength(150);


        }
    }
}
