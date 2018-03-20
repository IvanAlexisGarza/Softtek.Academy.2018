using Academy2018.Final.Test.V2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy2018.Final.Test.V2.Data
{
    public class SurveyContext : DbContext
    {
        public SurveyContext() : base("SurveyTestDb2")
        {
        }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Option> Options { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<QuestionType> QuestionTypes { get; set; }

        public DbSet<Status> Status { get; set; }

        //public DbSet<AnsweredSurvey> AnsweredSurveys { get; set; }
        //This is a nice to have left for when i finish
    }
}
