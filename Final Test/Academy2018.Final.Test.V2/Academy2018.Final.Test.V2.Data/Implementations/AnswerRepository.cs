
using Academy2018.Final.Test.V2.Data;
using Academy2018.Final.Test.V2.Data.Contracts;
using Academy2018.Final.Test.V2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Academy2018.Final.Test.V2.Data.Implementations
{
    public class AnswerRepository : IAnswerRepository
    {
        public bool AddAnswerToQuestion(int answerId, int questionId)
        {
            using (var context = new SurveyContext())
            {
                Answer answerInDb = context.Answers.SingleOrDefault(x => x.Id == answerId);
                if (answerInDb == null) return false;

                Question quetionInDb = context.Questions.SingleOrDefault(x => x.Id == questionId);
                if (quetionInDb == null) return false;

                answerInDb.QuestionId = questionId;

                context.SaveChanges();

                return true;
            }
        }

        public int CreateAnswer(Answer answer)
        {
            using (var context = new SurveyContext())
            {
                Answer currentAnswer = new Answer
                {
                    SurveyId = answer.SurveyId,
                    QuestionId = answer.QuestionId,
                    OptionId = answer.OptionId,
                    OpenText = answer.OpenText,

                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                };

                context.Answers.Add(currentAnswer);
                context.SaveChanges();
                return currentAnswer.Id;
            }
        }

        public bool Exist(string title)
        {
            throw new NotImplementedException();
        }

        public bool Exist(int itemId)
        {
            using (var context = new SurveyContext())
            {
                Answer answerInDb = context.Answers.Where(x => x.Id == itemId).FirstOrDefault();
                if (answerInDb == null)
                    return false;
                else
                    return true;
            }
        }

        public ICollection<Answer> GetAll()
        {
            using (var context = new SurveyContext())
            {
                return context.Answers.ToList();
            }
        }

        public Answer GetById(int answerId)
        {
            using (var context = new SurveyContext())
            {
                Answer answerInDb = context.Answers.Where(x => x.Id == answerId).FirstOrDefault();
                if (answerInDb == null)
                    return null;
                else
                    return answerInDb;
            }
        }
    }
}
