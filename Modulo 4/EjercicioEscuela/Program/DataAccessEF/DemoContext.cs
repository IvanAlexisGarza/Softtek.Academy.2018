using DataAccessEF.Configurations;
using DataAccessEF.Entities;
using DataAccessEF.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF
{
    public class DemoContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentDTO> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Asignation> Asignations { get; set; }

        public DemoContext() : base("SchoolApp")
        {
            Database.SetInitializer<DemoContext>(new MigrateDatabaseToLatestVersion<DemoContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TeacherConfiguration());
            modelBuilder.Configurations.Add(new StudentConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new ClassConfiguration());
            modelBuilder.Configurations.Add(new AsignationConfiguration());
        }
    }
}
