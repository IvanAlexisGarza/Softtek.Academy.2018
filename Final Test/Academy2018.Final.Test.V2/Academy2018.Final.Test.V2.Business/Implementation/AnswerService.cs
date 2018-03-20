using Academy2018.Final.Test.Business.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy2018.Final.Test.V2.Domain.Model;
using Academy2018.Final.Test.V2.Data.Contracts;

namespace Academy2018.Final.Test.Business.Implementation
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerService(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public bool AddAnswerToQuestion(int answerId, int questionId)
        {
            return _answerRepository.AddAnswerToQuestion(answerId, questionId);
        }

        public int CreateAnswer(Answer answer)
        {
            return _answerRepository.CreateAnswer(answer);
        }

        public ICollection<Answer> GetAll()
        {
            return _answerRepository.GetAll();
        }

        public Answer GetById(int itemId)
        {
            return _answerRepository.GetById(itemId);
        }
    }
}
