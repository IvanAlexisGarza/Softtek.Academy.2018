using Academy2018.Final.Test.V2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy2018.Final.Test.V2.Data.Contracts
{
    public interface ISurveyRepository : IGenericRepository<Survey>
    {
        int Create(Survey survey);

        bool AddQuestion(int addedQuestionId, int surveyId);

        bool ChangeStatus(int surveyId, int newStatus);

        bool ContainsQuestion(int surveyId, int questionId);

        bool ActivateSurvey(int surveyId);

        bool DeactivateSurvey(int surveyId);

        bool UpdateSurvey(Survey survey);

        ICollection<Question> GetQuestionsBySurvey(int surveyId);
    }
}
