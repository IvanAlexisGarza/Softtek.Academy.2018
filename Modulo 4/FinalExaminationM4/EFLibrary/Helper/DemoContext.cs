using EFLibrary.Configurations;
using EFLibrary.Entities;
using EFLibrary.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFLibrary.Helper
{
    public class DemoContext : DbContext
    {
        public DemoContext() : base("SQLExpress")
        {
            //Database.SetInitializer<DemoContext>(new DropCreateDatabaseIfModelChanges<DemoContext>());
            //Database.SetInitializer<DemoContext>(new DemoInitializer());
            Database.SetInitializer<DemoContext>(
                 new MigrateDatabaseToLatestVersion<DemoContext, Configuration>());
        }

        public DbSet<ItemInfo> Items { get; set; }
        public DbSet<Tag> Tags { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           modelBuilder.Configurations.Add(new ItemConfiguration());
           modelBuilder.Configurations.Add(new TagConfiguration());

        }
    }
}

