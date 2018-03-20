using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessEF.Entities;

namespace DataAccessEF.Configurations
{
    public class TeacherConfiguration : EntityTypeConfiguration<Teacher>
    {
        public TeacherConfiguration()
        {
            this.ToTable("Teacher");
            this.HasKey(t => t.TeacherId);

            this.Property(t => t.Names).IsRequired();
            this.Property(t => t.Names).HasMaxLength(60);
            this.Property(t => t.LastName).IsRequired();
            this.Property(t => t.LastName).HasMaxLength(60);
            this.Property(t => t.SecondLastName).HasMaxLength(60);

            this.HasMany<Class>(t => t.Classes);

        }
    }
}
