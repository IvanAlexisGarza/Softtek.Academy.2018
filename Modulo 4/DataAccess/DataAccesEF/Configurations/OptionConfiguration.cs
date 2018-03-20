using DataAccesEF.Entities;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesEF.Configurations
{
    public class OptionConfiguration : EntityTypeConfiguration<OptionDTO>
    {
        public OptionConfiguration()
        {
            this.HasKey(p => p.OptionId);

            this.Property(p => p.Text).HasMaxLength(100).IsRequired();
            
            this.ToTable("Options");
        }
    }
}
