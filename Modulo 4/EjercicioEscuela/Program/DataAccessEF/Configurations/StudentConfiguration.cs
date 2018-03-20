using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessEF.Entities;

namespace DataAccessEF.Configurations
{
    public class StudentConfiguration : EntityTypeConfiguration<StudentDTO>
    {
        public StudentConfiguration()
        {
            this.ToTable("Student");
            this.HasKey(s => s.StudentId);

            this.Property(s => s.Names).IsRequired();
            this.Property(s => s.Names).HasMaxLength(60);
            this.Property(s => s.LastName).IsRequired();
            this.Property(s => s.LastName).HasMaxLength(60);
            this.Property(s => s.SecondLastName).HasMaxLength(60);

            this.HasMany<Class>(s => s.Workload);
            this.HasMany<Asignation>(s => s.Tasks);

        }
    }
}
