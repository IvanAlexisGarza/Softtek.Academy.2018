using EFLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLibrary.Configurations
{
    public class ItemConfiguration : EntityTypeConfiguration<ItemInfo>
    {
        public ItemConfiguration()
        {
            ToTable("ItemInfo");

            this.HasKey(x => x.ItemId);

            this.Property(x => x.Archived).IsRequired();
            this.Property(x => x.CreationDate).IsRequired();
            this.Property(x => x.Description).HasMaxLength(500).IsOptional();
            this.Property(x => x.DueDate).IsOptional();
            this.Property(x => x.ModDate).IsRequired();
            this.Property(x => x.Priority).IsRequired();
            this.Property(x => x.StatusId).IsRequired();
            this.Property(x => x.Title).HasMaxLength(50).IsRequired();

            this.HasMany<Tag>(t => t.Tags).WithMany(x => x.Items)
                .Map(x =>
                {
                    x.MapLeftKey("TagId");
                    x.MapRightKey("ItemId");
                    x.ToTable("ItemTags");
                });
        }
    }
}
