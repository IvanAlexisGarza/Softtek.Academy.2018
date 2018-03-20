using Softtek.Academy2018.SurveyApp.Data.Contracts;
using Softtek.Academy2018.SurveyApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.SurveyApp.Data.Implementations
{
    class QuestionDataRepository : IQuestionRepository
    {
        public bool Activate(Question item)
        {
            if (item == null)
            {
                Console.WriteLine("Can't delete Question because it's a null value");
                return false;
            }
            using (var context = new SurveyDBContext())
            {
                Question currentQuestion = context.Questions.AsNoTracking().SingleOrDefault(x => x.Id == item.Id);

                currentQuestion.IsActive = true;
                currentQuestion.ModifiedDate = DateTime.Now;
                context.SaveChanges();
                return true;
            }
        }

        public int Add(Question item)
        {
            if (item == null)
            {
                Console.WriteLine("Can't add Question because it's a null value");
                return -1;
            }

            using (var context = new SurveyDBContext())
            {
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                item.IsActive = true;
                context.Questions.Add(item);
                context.SaveChanges();
                return item.Id;
            }
        }

        public bool AddOption(int optionId, int questionId)
        {
            using (var context = new SurveyDBContext())
            {
                Question currentQuestion = context.Questions.SingleOrDefault(x => x.Id == questionId);
                if (currentQuestion == null) return false;

                Option currentOption = context.Options.SingleOrDefault(x => x.Id == optionId);
                if (currentOption == null) return false;

                currentQuestion.Options.Add(currentOption);
                context.SaveChanges();

                return true;
            }
        }

        public bool Delete(Question item)
        {
            if (item == null)
            {
                Console.WriteLine("Can't delete Question because it's a null value");
                return false;
            }
            using (var context = new SurveyDBContext())
            {
                Question currentQuestion = context.Questions.AsNoTracking().SingleOrDefault(x => x.Id == item.Id);

                currentQuestion.IsActive = false;
                currentQuestion.ModifiedDate = DateTime.Now;
                context.SaveChanges();
                return true;
            }
        }

        public bool Exist(int id)
        {
            using (var context = new SurveyDBContext())
            {
                return context.Questions.Any(x => x.Id == id);
            }
        }

        public Question Get(int id)
        {
            using (var context = new SurveyDBContext())
            {
                return context.Questions.AsNoTracking().SingleOrDefault(x => x.Id == id);
            }
        }

        public bool Update(Question item)
        {
            using (var context = new SurveyDBContext())
            {
                Question currentQuestion = context.Questions.SingleOrDefault(x => x.Id == item.Id);

                if (currentQuestion == null) return false;

                currentQuestion.Id = item.Id;
                currentQuestion.Text = item.Text;
                currentQuestion.ModifiedDate = DateTime.Now;
                currentQuestion.IsActive = item.IsActive;
                currentQuestion.QuestionTypeId = item.QuestionTypeId;

                context.SaveChanges();

                return true;
            }
        }
    }
}
