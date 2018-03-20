using EFLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLibrary.Configurations
{
    public class TagConfiguration : EntityTypeConfiguration<Tag>
    {
        public TagConfiguration()
        {
            this.HasKey(x => x.TagId);

            this.Property(x => x.Title).HasMaxLength(100).IsRequired();

            this.ToTable("Tags");
        }
    }
}
