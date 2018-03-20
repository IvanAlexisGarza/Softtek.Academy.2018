
using Academy2018.Final.Test.V2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy2018.Final.Test.Business.Contracts
{
    public interface IQuestionService : IGenericService<Question>
    {
        ICollection<Option> GetOptionsByQuestion(int questionId);

        ICollection<Answer> GetAnswersByQuestion(int questionId);
    }
}
