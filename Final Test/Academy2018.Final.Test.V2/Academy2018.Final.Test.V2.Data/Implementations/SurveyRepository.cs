using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy2018.Final.Test.V2.Data.Contracts;
using Academy2018.Final.Test.V2.Domain.Model;
using Newtonsoft.Json.Linq;

namespace Academy2018.Final.Test.V2.Data.Implementations
{
    public class SurveyRepository : ISurveyRepository
    {

        public bool ActivateSurvey(int surveyId)
        {
            using (var context = new SurveyContext())
            {
                Survey surveyInDb = GetById(surveyId);
                if (surveyInDb == null) return false;

                surveyInDb.IsActive = true;
                context.SaveChanges();
                return true;
            }
        }

        public bool AddQuestion(int addedQuestionId, int surveyId)
        {
            using (var context = new SurveyContext())
            {
                Survey surveyInDb = context.Surveys.SingleOrDefault(x => x.Id == surveyId);
                if (surveyInDb == null) return false;

                Question questionInDb = context.Questions.SingleOrDefault(x => x.Id == addedQuestionId);
                if (questionInDb == null) return false;

                surveyInDb.Questions.Add(questionInDb);

                context.SaveChanges();

                return true;
            }
        }

        public bool ChangeStatus(int surveyId, int newStatus)
        {
            using (var context = new SurveyContext())
            {
                Survey surveyInDb = GetById(surveyId);

                if (surveyInDb == null) return false;

                surveyInDb.Status = (Status)newStatus;

                context.SaveChanges();
                return true;
            }
        }

        public bool ContainsQuestion(int surveyId, int questionId)
        {
            using (var context = new SurveyContext())
            {
                return context.Surveys.Any
                    (x => x.Id == surveyId && x.Questions.Any
                    (q => q.Id == questionId));
            }
        }

        public int Create(Survey survey)
        {
            using (var context = new SurveyContext())
            {

                survey.Status = (Status)2;//Draft
                context.Surveys.Add(survey);
                context.SaveChanges();
                return survey.Id;
            }
        }

        public bool DeactivateSurvey(int surveyId)
        {
            using (var context = new SurveyContext())
            {
                Survey surveyInDb = context.Surveys.Where(x => x.Id == surveyId).FirstOrDefault();
                if (surveyInDb == null) return false;

                surveyInDb.IsActive = false;
                context.SaveChanges();
                return true;
            }
        }

        public bool Exist(string title)
        {
            using (var context = new SurveyContext())
            {
                Survey surveyInDb = context.Surveys.Where(x => x.Title == title).FirstOrDefault();
                if (surveyInDb == null)
                    return false;
                else
                    return true;
            }
        }

        public bool UpdateSurvey(Survey survey)
        {
            using (var context = new SurveyContext())
            {
                Survey surveyInDb = context.Surveys.Where(x => x.Id == survey.Id).FirstOrDefault();

                if (surveyInDb == null) return false;

                surveyInDb.Id = survey.Id;
                surveyInDb.Title = survey.Title;
                surveyInDb.Description = survey.Description;
                surveyInDb.IsActive = survey.IsActive;

                context.SaveChanges();

                return true;
            }
        }

        public bool Exist(int itemId)
        {
            using (var context = new SurveyContext())
            {
                Survey surveyInDb = context.Surveys.Where(x => x.Id == itemId).FirstOrDefault();
                if (surveyInDb == null)
                    return false;
                else
                    return true;
            }
        }

        public ICollection<Survey> GetAll()
        {
            using (var context = new SurveyContext())
            {
                return context.Surveys.ToList();
            }
        }

        public Survey GetById(int surveyId)
        {
            using (var context = new SurveyContext())
            {
                Survey surveyInDb = context.Surveys.Where(x => x.Id == surveyId).FirstOrDefault();
                if (surveyInDb == null)
                    return null;
                else
                    return surveyInDb;
            }
        }

        public ICollection<Question> GetQuestionsBySurvey(int surveyId)
        {
            using (var context = new SurveyContext())
            {
                Survey surveyInDb = context.Surveys.Where(x => x.Id == surveyId).FirstOrDefault();
                if (surveyInDb == null) return null;

                var questionList =  surveyInDb.Questions.ToList();

                //var pushToken = JObject.Parse(Json)["pushToken"];

                //survey = context.Surveys.Include(x => x.Questions).ToList();

                // if (survey == null || !survey.Questions.Any()) return null;

                return questionList;
            }
        }
    }
}
