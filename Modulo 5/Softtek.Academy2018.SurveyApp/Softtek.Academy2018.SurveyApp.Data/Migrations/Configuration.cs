namespace Softtek.Academy2018.SurveyApp.Data.Migrations
{
    using Softtek.Academy2018.SurveyApp.Domain.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Softtek.Academy2018.SurveyApp.Data.SurveyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SurveyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var optYes = new Option { Id = 1, Text = "Yes", CreatedDate = DateTime.Now, ModifiedDate = null };
            var optNo = new Option { Id = 2, Text = "No", CreatedDate = DateTime.Now, ModifiedDate = null };
            var opt1 = new Option { Id = 3, Text = "Create, Read, Update, Delete", CreatedDate = DateTime.Now, ModifiedDate = null };
            var opt2 = new Option { Id = 4, Text = "POST, Read, GET, Delete", CreatedDate = DateTime.Now, ModifiedDate = null };
            var opt3 = new Option { Id = 5, Text = "SOAP, REST, WSDL, JSON", CreatedDate = DateTime.Now, ModifiedDate = null };
            var opt4 = new Option { Id = 6, Text = "POST, PUT, GET, UPDATE, DELETE", CreatedDate = DateTime.Now, ModifiedDate = null };

            context.Options.AddOrUpdate(optYes, optNo, opt1, opt2, opt3, opt4);

            context.QuestionTypes.AddOrUpdate(
                new QuestionType
                {
                    Id = 1,
                    Description = "Open",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null
                },
                new QuestionType
                {
                    Id = 2,
                    Description = "Dichotomous",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null
                },
                new QuestionType
                {
                    Id = 3,
                    Description = "Multiple",
                    CreatedDate = DateTime.Now,
                    ModifiedDate = null
                }
            );

            var question1 = new Question
            {
                Id = 1,
                Text = "What is a Web Service?",
                QuestionTypeId = 1,
                IsActive = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = null
            };
            var question2 = new Question
            {
                Id = 2,
                Text = "Is SOAP a design patten for Software Development?",
                QuestionTypeId = 2,
                IsActive = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = null
            };

            question2.Options.Add(optYes);
            question2.Options.Add(optNo);

            var question3 = new Question
            {
                Id = 3,
                Text = "What are the main Http Methods used by RESTful APIs?",
                QuestionTypeId = 3,
                IsActive = true,
                CreatedDate = DateTime.Now,
                ModifiedDate = null
            };

            question3.Options.Add(opt1);
            question3.Options.Add(opt2);
            question3.Options.Add(opt3);
            question3.Options.Add(opt4);

            context.Questions.AddOrUpdate(question1, question2, question3);

            Survey survey = new Survey
            {
                Id = 1,
                Title = ".NET Academy 2018 - Web Service Module",
                Description = "Evaluate the acquired knowledge during the web service module.",
                IsArchived = false,
                CreatedDate = DateTime.Now,
                ModifiedDate = null
            };

            survey.Questions.Add(question1);
            survey.Questions.Add(question2);
            survey.Questions.Add(question3);

            context.Surveys.AddOrUpdate(survey);
        }
    }
}
