namespace Academy2018.Final.Test.V2.Data.Migrations
{
    using Academy2018.Final.Test.V2.Domain.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Academy2018.Final.Test.V2.Data.SurveyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Academy2018.Final.Test.V2.Data.SurveyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //context.Status.Add(new Domain.Model.Status { Id = 1, Description = "Draft", CreatedDate = DateTime.Now, ModifiedDate = null });
            //context.Status.Add(new Domain.Model.Status { Id = 2, Description = "Ready", CreatedDate = DateTime.Now, ModifiedDate = null });
            //context.Status.Add(new Domain.Model.Status { Id = 3, Description = "Done", CreatedDate = DateTime.Now, ModifiedDate = null });
            //context.Status.Add(new Domain.Model.Status { Id = 4, Description = "Cancelled", CreatedDate = DateTime.Now, ModifiedDate = null });

            //context.QuestionTypes.Add(new Domain.Model.QuestionType { Id = 1, Description = "Open", CreatedDate = DateTime.Now, ModifiedDate = null });
            //context.QuestionTypes.Add(new Domain.Model.QuestionType { Id = 2, Description = "Multiple Choice", CreatedDate = DateTime.Now, ModifiedDate = null });

            //context.Options.Add(new Domain.Model.Option
            //{
            //    Id = 1,
            //    Text = "Option 1",
            //    ScoreValue = 1,
            //    Questions = context.Questions.Where(x => x.Id == 1).ToList(),
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = null
            //});

            //context.Options.Add(new Domain.Model.Option
            //{
            //    Id = 2,
            //    Text = "Option 2",
            //    ScoreValue = 2,
            //    Questions = context.Questions.Where(x => x.Id == 1).ToList(),
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = null
            //});


            //context.Questions.Add(new Domain.Model.Question
            //{
            //    Id = 1,
            //    Text = "Pregunta 1",
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = null,
            //    QuestionTypeId = 2,
            //    Options = context.Options.Where(x => x.Id == 1).ToList()
            //});

            //context.Questions.Add(new Domain.Model.Question
            //{
            //    Id = 1,
            //    Text = "Pregunta 2",
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = null,
            //    QuestionTypeId = 2,
            //    Options = context.Options.Where(x => x.Id == 2).ToList()
            //});

            //context.Surveys.Add(new Survey
            //{
            //    Id = 1,
            //    Title = "Survey 1",
            //    Description = "First Survey Test, Direct insert",
            //    Questions = context.Questions.Where(x => x.Id == 2).ToList(),
            //    IsActive = true,
            //    CreatedDate = DateTime.Now,
            //    ModifiedDate = DateTime.Now,
            //    Status = Status.Draft,
            //});

            //context.Questions.Add(new Domain.Model.Question
            //{
            //    Text = "Pregunta 3",
            //    CreatedDate = DateTime.Now,
            //    QuestionTypeId = 5,
            //    Options = context.Options.Where(x => x.Id == 5).ToList()
            //});


            //Question question = new Question
            //{
            //    Id = 5,
            //    Text = "Pregunta 9",
            //    CreatedDate = DateTime.Now,
            //    QuestionTypeId = 1,
            //};

            //Option option = context.Options.Where(x => x.Text == "Option 2").FirstOrDefault();

            //question.Options.Add(context.Options.Where(x => x.Text == "Option 2").FirstOrDefault());
            //question.OptionId.Add(6);

            //context.Questions.Add(question);
            //context.SaveChanges();
        }
    }
}
