using Softtek.Academy2018.SurveyApp.Domain.Model;
using System.Data.Entity;

namespace Softtek.Academy2018.SurveyApp.Data
{
    public class SurveyDBContext : DbContext
    {
        public DbSet<Survey> Surveys { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<QuestionType> QuestionTypes { get; set; }

        public DbSet<Option> Options { get; set; }

        public SurveyDBContext() : base("SurveyDb")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Survey>()
                .Property(x => x.Title)
                    .IsRequired()
                    .HasMaxLength(200);

            modelBuilder.Entity<Survey>()
                .Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(500);

            modelBuilder.Entity<Question>()
                .Property(x => x.Text)
                    .IsRequired()
                    .HasMaxLength(300);

            modelBuilder.Entity<QuestionType>()
                .Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(50);

            modelBuilder.Entity<QuestionType>()
                .Property(x => x.Description)
                    .IsRequired()
                    .HasMaxLength(200);

            modelBuilder.Entity<Option>()
                .Property(x => x.Text)
                    .IsRequired()
                    .HasMaxLength(500);


            base.OnModelCreating(modelBuilder);
        }
    }
}
