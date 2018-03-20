using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Academy2018.Final.Test.V2.Data.Contracts;
using Academy2018.Final.Test.V2.Domain.Model;
using System.Collections;
//using System.Data.Entity.Include;

namespace Academy2018.Final.Test.V2.Data.Implementations
{
    public class QuestionRepository : IQuestionRepository
    {
        public bool Exist(string title)
        {
            using (var context = new SurveyContext())
            {
                Question questionInDb = context.Questions.Where(x => x.Text == title).FirstOrDefault();
                if (questionInDb == null)
                    return false;
                else
                    return true; 
            }
        }

        public bool Exist(int itemId)
        {
            using (var context = new SurveyContext())
            {
                Question questionInDb = context.Questions.Where(x => x.Id == itemId).FirstOrDefault();
                if (questionInDb == null)
                    return false;
                else
                    return true;
            }
        }

        public ICollection<Question> GetAll()
        {
            using (var context = new SurveyContext())
            {
                return context.Questions.ToList();
            }
        }

        public ICollection<Answer> GetAnswersByQuestion(int questionId)
        {
            using (var context = new SurveyContext())
            {
                Question questionInDb = context.Questions.Where(x => x.Id == questionId).FirstOrDefault();
                if (questionInDb == null) return null;
 
                //questionInDb = context.Questions.Include(x => x.Answers).SingleOrDefault();

                if (questionInDb == null || !questionInDb.Answers.Any()) return null;

                return questionInDb.Answers.ToList();
            }
        }

        public Question GetById(int questionId)
        {
            using (var context = new SurveyContext())
            {
                Question questionInDb = context.Questions.Where(x => x.Id == questionId).FirstOrDefault();
                if (questionInDb == null)
                    return null;
                else
                    return questionInDb;
            }
        }

        public ICollection<Option> GetOptionsByQuestion(int questionId)
        {
            using (var context = new SurveyContext())   
            {
                Question questionInDb = context.Questions.Where(x => x.Id == questionId).FirstOrDefault();
                if (questionInDb == null) return null;

                return questionInDb.Options.ToList();

                #region This is a 3 hour failure/ i was using the method GetById and that was droping the reference to my context, fun right?
                //ICollection<Option> optionList = question.Options.ToList();

                //Option option = context.Options.Where(x => x.Id == 6).FirstOrDefault();

                //question.Options.Add(option);
                //question.OptionId.Add(6);
                //context.SaveChanges();

                //List<Option> optionList = new List<Option>();
                //foreach (int optionInDbId in question.OptionId)
                //{
                //    optionList = context.Options.Where(x => x.Id == optionInDbId).ToList();
                //}

                //return optionList;



                //question = context.Questions.Include(x => x.Options).SingleOrDefault();

                //if (question == null || !question.Options.Any()) return null;

                //var listOfOptionId = question.Options.Select(r => r.Id);
                //var options = context.Options.Where(r => listOfOptionId.Contains(r.Id)).ToList();

                //context.Questions.Where(x => x.Options.Where(o => o.Id == optionId).ToList()).ToList();
#endregion
            }
        }
    }
}
