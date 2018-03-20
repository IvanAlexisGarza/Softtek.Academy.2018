using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DataAccesEF.Entities;
using DataAccesEF.Configurations;
using DataAccesEF.Migrations;

namespace DataAccesEF
{
    public class DemoContext : DbContext
    {
        public DemoContext() : base("EntityFramework")
        {
            //Database.SetInitializer<DemoContext>(new DropCreateDatabaseIfModelChanges<DemoContext>());

            //Database.SetInitializer<DemoContext>(new DemoInitializer());

            Database.SetInitializer<DemoContext>(
                new MigrateDatabaseToLatestVersion<DemoContext, Configuration>());
        }

        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new QuestionConfiguration());
            modelBuilder.Configurations.Add(new OptionConfiguration());
        }
    }
}
