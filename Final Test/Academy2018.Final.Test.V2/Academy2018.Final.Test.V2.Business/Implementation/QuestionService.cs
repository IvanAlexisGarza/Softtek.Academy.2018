using Academy2018.Final.Test.Business.Contracts;
using Academy2018.Final.Test.V2.Data.Contracts;
using Academy2018.Final.Test.V2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy2018.Final.Test.Business.Implementation
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionService(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public ICollection<Question> GetAll()
        {
            return _questionRepository.GetAll();
        }

        public ICollection<Answer> GetAnswersByQuestion(int questionId)
        {
            return _questionRepository.GetAnswersByQuestion(questionId);
        }

        public Question GetById(int itemId)
        {
            return _questionRepository.GetById(itemId);
        }

        public ICollection<Option> GetOptionsByQuestion(int questionId)
        {
            ICollection < Option > optionList = _questionRepository.GetOptionsByQuestion(questionId);
            return optionList;
        }
    }
}
