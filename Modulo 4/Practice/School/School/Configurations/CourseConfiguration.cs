using School.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Configurations
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            this.HasKey(x => x.CourseId);
            this.Property(x => x.CourseName);
            this.Property(x => x.CourseDescription);

            this.HasOptional<Teacher>(x => x.CourseTeacher);

            this.ToTable("Courses");
            //Relationship is already in students so it will not be needed
            //this.HasMany<Student>(x => x.Students);

        }
    }
}
