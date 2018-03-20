using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using School.Configurations;
using School.Entities;
using School.Migrations;

namespace School.Helper
{
    public class DemoContext : DbContext
    {
        public DemoContext() : base("AWSConnection")
        {
            //Database.SetInitializer<DemoContext>(new DropCreateDatabaseIfModelChanges<DemoContext>());
            //Database.SetInitializer<DemoContext>(new DemoInitializer());
            Database.SetInitializer<DemoContext>(
                 new MigrateDatabaseToLatestVersion<DemoContext, Configuration>());
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Course> Courses { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new TeacherConfiguration());
        }
    }
}
