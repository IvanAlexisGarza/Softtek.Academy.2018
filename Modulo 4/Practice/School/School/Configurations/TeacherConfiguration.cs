using School.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Configurations
{
    public class TeacherConfiguration : EntityTypeConfiguration<Teacher>
    {
        public TeacherConfiguration()
        {
            this.HasKey(x => x.TeacherId);

            this.Property(x => x.Names);
            this.Property(x => x.LastName);
            this.Property(x => x.SecondLastName);
            this.Property(x => x.PhoneNumber);
            this.Property(x => x.Email);

            this.HasMany<Course>(x => x.Courses);
            this.HasMany<Subject>(x => x.Subjects).WithMany(x => x.SubjectTeachers)
                .Map(x =>
                {
                    x.MapLeftKey("Subject");
                    x.MapLeftKey("Teacher");
                    x.ToTable("SubjectTeachers");
                });
        }
    }
}
