using Softtek.Academy2018.SurveyApp.Data.Contracts;
using Softtek.Academy2018.SurveyApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.SurveyApp.Data.Implementations
{
    class QuestionTypeDataRespository : IQuestionTypeRepository
    {
        public int Add(QuestionType item)
        {
            if(item == null)
            {
                Console.WriteLine("Can't add Question type because it's a null value");
                return -1;
            }

            using (var context = new SurveyDBContext())
            {
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                context.QuestionTypes.Add(item);
                context.SaveChanges();
                return item.Id;
            }
        }

        public bool Delete(QuestionType item)
        {
            if (item == null)
            {
                Console.WriteLine("Can't delete Question types because it's a null value");
                return false;
            }
            using (var context = new SurveyDBContext())
            {
                context.QuestionTypes.Remove(item);
                context.SaveChanges();
                return true;
            }
        }

        public QuestionType Get(int id)
        {
            using (var context = new SurveyDBContext())
            {
                return context.QuestionTypes.AsNoTracking().SingleOrDefault(x => x.Id == id);
            }
        }

        public ICollection<QuestionType> GetAll()
        {
            using (var context = new SurveyDBContext())
            {
                return context.QuestionTypes.ToList();
            }
        }

        public bool Update(QuestionType item)
        {
            using (var context = new SurveyDBContext())
            {
                QuestionType currentQuestionType = context.QuestionTypes.SingleOrDefault(x => x.Id == item.Id);

                if (currentQuestionType == null) return false;

                currentQuestionType.Id = item.Id;
                currentQuestionType.Description = item.Description;
                currentQuestionType.ModifiedDate = DateTime.Now;

                context.SaveChanges();

                return true;
            }
        }
        bool Exist(string name)
        {
            using (var context = new SurveyDBContext()) 
             {
                 return context.QuestionTypes.Any(x => x.Description.ToLower() == name.ToLower());
             }
        }
    }
}
