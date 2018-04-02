using Academy2018.Final.Test.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy2018.Final.Test.V2.Domain.Model;
using Academy2018.Final.Test.V2.Data.Implementations;
using Academy2018.Final.Test.V2.Data.Contracts;

namespace Academy2018.Final.Test.Business.Implementation
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IQuestionRepository _questionRepository;

        public SurveyService(ISurveyRepository surveyRepository, IQuestionRepository questionRepository)
        {
            _surveyRepository = surveyRepository;
            _questionRepository = questionRepository;
        }

        public bool ActivateSurvey(int surveyId)
        {
            return _surveyRepository.ActivateSurvey(surveyId);
        }

        public bool AddQuestion(int addedQuestionId, int surveyId)
        {
            if (addedQuestionId <= 0 || surveyId <= 0) return false;

            bool questionExist = _questionRepository.Exist(addedQuestionId);
            if (!questionExist) return false;

            bool surveyExist = _surveyRepository.Exist(surveyId);
            if (!questionExist) return false;

            bool isQuestionAdded = _surveyRepository.ContainsQuestion(surveyId, addedQuestionId);
            if (isQuestionAdded) return false;

            Survey currentSurvey = _surveyRepository.GetById(surveyId);

            //ICollection<Question> surveyQuestions = _surveyRepository.GetQuestionsBySurvey(surveyId);
            //int questionsinSurvey = surveyQuestions.Count();
            //if (questionsinSurvey >= 5) return false;

            return _surveyRepository.AddQuestion(addedQuestionId, surveyId);

        }

        public bool UpdateSurvey(Survey survey)
        {
            return _surveyRepository.UpdateSurvey(survey);
        }

        public bool ChangeStatus(int surveyId, int newStatus)
        {
            Survey surveyInDb = _surveyRepository.GetById(surveyId);

            #region Read ME
            /*
             * 
             * Dearest
             * Tester? Teacher? Senior? Master? IDK!
             * I needed to implement the business for the status change but it's managed by ID and not by description
             * I coudn't implement it by ID perfectly since it was constantly changing with the migrations
             * Hope i can come back and implement it 
             * 
             * Best Iavan Alexis :)
             */

            //Status currentStatus = new Status
            //{
            //    Id = surveyInDb.Status.Id,
            //};

            /*
             * 1 = Draft
             * 2 = Ready
             * 3 = Done
             * 4 = Cancelled
             * */

            //if (currentStatus.Description == "Done" || currentStatus.Description == "Cancelled")
            //    return false;

            //if (currentStatus.Description == "Draft" && !(currentStatus.Description == "Ready"))
            //    return false;
#endregion

            return _surveyRepository.ChangeStatus(surveyId, newStatus);
        }

        public bool ContainsQuestion(int surveyId, int questionId)
        {
           return  _surveyRepository.ContainsQuestion(surveyId, questionId);
        }

        public int Create(Survey survey)
        {
            return _surveyRepository.Create(survey);
        }

        public bool DeactivateSurvey(int surveyId)
        {
            return _surveyRepository.DeactivateSurvey(surveyId);
        }

        public bool Exist(string title)
        {
            return _surveyRepository.Exist(title);
        }

        public bool Exist(int surveyId)
        {
            return _surveyRepository.Exist(surveyId);
        }

        public ICollection<Survey> GetAll()
        {
            return _surveyRepository.GetAll();
        }

        public Survey GetById(int itemId)
        {
            return _surveyRepository.GetById(itemId);
        }

        public ICollection<Question> GetQuestionsBySurvey(int surveyId)
        {
            return _surveyRepository.GetQuestionsBySurvey(surveyId);
        }
    }
}
