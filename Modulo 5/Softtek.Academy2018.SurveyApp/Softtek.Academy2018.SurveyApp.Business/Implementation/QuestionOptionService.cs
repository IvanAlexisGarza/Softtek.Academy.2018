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
    public class QuestionOptionService : IQuestionOptionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IOptionRepository _optionRepository;

        public QuestionOptionService(IQuestionRepository questionRepository, IOptionRepository optionRepository)
        {
            _questionRepository = questionRepository;
            _optionRepository = optionRepository;
        }

        public bool AddOptionToQuestion(int optionId, int questionId)
        {
            if (optionId <= 0 || questionId <= 0) return false;

            bool optionExist = _optionRepository.Exist(optionId);
            if(!optionExist) return false;

            bool questionExist = _questionRepository.Exist(questionId);
            if (!questionExist) return false;

            Question currentQuestion = _questionRepository.Get(questionId);
            if (currentQuestion.QuestionTypeId == 1) return false;

            ICollection<Option> questionOptions = GetOptionsByQuestion(questionId);
            int optionsCount = questionOptions.Count();

            if (currentQuestion.QuestionTypeId == 2 && optionsCount >=2 ) return false;
            if (currentQuestion.QuestionTypeId == 3 && optionsCount >=3 ) return false;

            return _questionRepository.AddOption(optionId,  questionId);

        }

        public ICollection<Option> GetOptionsByQuestion(int questionId)
        {
            throw new NotImplementedException();
        }
    }
}
