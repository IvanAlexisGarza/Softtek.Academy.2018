using Softtek.Academy2018.SurveyApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.SurveyApp.Domain.Model;

namespace Softtek.Academy2018.SurveyApp.Data.Implementations
{
    public class SurveyDataRepository : ISurveyRepository
    {
        public int Add(Survey item)
        {
            if (item == null)
            {
                Console.WriteLine("Can't add option because it's a null value");
                return -1;
            }

            using (var context = new SurveyDBContext())
            {
                item.CreatedDate = DateTime.Now;
                item.ModifiedDate = DateTime.Now;
                item.IsArchived = false;
                context.Surveys.Add(item);
                context.SaveChanges();
                return item.Id;
            }
        }

        public bool AddQuestion(int surveyId, int questionId)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Survey item)
        {
            if (item == null)
            {
                Console.WriteLine("Can't delete option because it's a null value");
                return false;
            }
            using (var context = new SurveyDBContext())
            {
                Survey currentSurvey = context.Surveys.SingleOrDefault(x => x.Id == item.Id);
                if (currentSurvey == null) return false;
                currentSurvey.IsArchived = true;
                context.SaveChanges();
                return true;
            }
        }

        public bool Exist(int id)
        {
            using (var context = new SurveyDBContext())
            {
                return context.Surveys.Any(x => x.Id == id);
            }
        }

        public Survey Get(int id)
        {
            using (var context = new SurveyDBContext())
            {
                return context.Surveys.AsNoTracking().SingleOrDefault(x => x.Id == id);
            }
        }

        public ICollection<Question> GetQuestionsBySurvey(int surveyId)
        {
            throw new NotImplementedException();
        }

        public bool Restore(Survey item)
        {
            if (item == null)
            {
                Console.WriteLine("Can't delete option because it's a null value");
                return false;
            }
            using (var context = new SurveyDBContext())
            {
                Survey currentSurvey = context.Surveys.SingleOrDefault(x => x.Id == item.Id);
                if (currentSurvey == null) return false;

                currentSurvey.IsArchived = false;
                context.SaveChanges();
                return true;
            }
        }

        public bool SurveyContainsQuestion(int projectId, int userId)
        {
            throw new NotImplementedException();
        }

        public bool Update(Survey item)
        {
            using (var context = new SurveyDBContext())
            {
                Survey currentSurvey = context.Surveys.SingleOrDefault(x => x.Id == item.Id);

                if (currentSurvey == null) return false;

                currentSurvey.Id = item.Id;
                currentSurvey.Title = item.Title;
                currentSurvey.Description = item.Description;
                currentSurvey.ModifiedDate = DateTime.Now;

                context.SaveChanges();

                return true;
            }
        }

        bool Exist(string name)
        {
            using (var context = new SurveyDBContext())
            {
                return context.Surveys.Any(x => x.Description.ToLower() == name.ToLower());
            }
        }


    }
}
