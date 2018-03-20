using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using School.Entities;

namespace School.Configurations
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            this.ToTable("Student");

            this.HasKey(x => x.StudentId);

            this.Property(x => x.FirstNames).HasMaxLength(50).IsRequired();
            this.Property(x => x.LastName).HasMaxLength(50).IsRequired();
            this.Property(x => x.SecondLastName).HasMaxLength(50).IsOptional();
            this.Property(x => x.Email).IsOptional();
            this.Property(x => x.IsActive).IsRequired();
            this.Property(x => x.BirthDay).IsOptional();
            this.Property(x => x.RegistrationDate).IsOptional();
            this.Property(x => x.DropOut).IsOptional();
            this.Property(x => x.Age).IsOptional();

            this.HasMany<Course>(x => x.Courses).WithMany(x => x.CourseStudents)
                .Map(x =>
                {
                    x.MapLeftKey("Course");
                    x.MapRightKey("Student");
                    x.ToTable("StudentCourses");
                });
        }
    }
}
