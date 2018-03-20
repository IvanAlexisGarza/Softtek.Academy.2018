using Softtek.Academy2018.SurveyApp.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academy2018.SurveyApp.Domain.Model;
using Softtek.Academy2018.SurveyApp.Data.Contracts;

namespace Softtek.Academy2018.SurveyApp.Business.Implementation
{
    public class SurveyQuestionService : ISurveyQuestionService
    {
        private readonly ISurveyRepository _surveyRespository;
        private readonly IQuestionRepository _questionRespository;

        public SurveyQuestionService(ISurveyRepository surveyRespository, IQuestionRepository questionRespository)
        {
            _surveyRespository = surveyRespository;
            _questionRespository = questionRespository;
        }

        public bool AddQuestionToSurvey(int surveyId, int questionId)
        {
            if (surveyId <= 0 || questionId <= 0) return false;

            bool surveyExist = _surveyRespository.Exist(surveyId);
            if (!surveyExist) return false;

            bool questionExist = _questionRespository.Exist(questionId);
            if (!questionExist) return false;

            bool surveyContainsQuestion = _surveyRespository.SurveyContainsQuestion(surveyId, questionId);
            if (surveyContainsQuestion) return false;

            Question currentQuestion = _questionRespository.Get(questionId);
            if(currentQuestion.IsActive == false) return false;

            return _surveyRespository.AddQuestion(surveyId, questionId);
        }

        public ICollection<Question> GetQuestionsBySurvey(int surveyId)
        {
            if (surveyId <= 0) return null;

            return _surveyRespository.GetQuestionsBySurvey(surveyId);
        }
    }
}
