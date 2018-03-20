using Softtek.Academy2018.SurveyApp.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.SurveyApp.Data.Contracts
{
    public interface ISurveyRepository : IGenericRepository<Survey>
    {
        bool Restore(Survey item);

        bool SurveyContainsQuestion(int surveyId, int QuestionId);

        bool AddQuestion(int surveyId, int questionId);

        ICollection<Question> GetQuestionsBySurvey(int surveyId);

        bool Exist(int id);
    }
}
