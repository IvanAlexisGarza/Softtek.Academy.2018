using DataAccesEF.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesEF.Configurations
{
    public class QuestionConfiguration : EntityTypeConfiguration<Question>
    {
        public QuestionConfiguration()
        {
            this.ToTable("Question");

            this.HasKey(p => p.QuestionId);

            this.Property(p => p.Text).HasMaxLength(200).IsRequired();

            this.Property(p => p.IsActive).IsRequired();
            this.Property(p => p.IsRequired).IsRequired();

            this.HasMany<Option>(op => op.Options).WithMany(q => q.Questions)
                .Map(qo =>
                {
                    qo.MapLeftKey("QuestionId");
                    qo.MapRightKey("OptionId");
                    qo.ToTable("QuestionOptions");
                });
        }
    }
}
