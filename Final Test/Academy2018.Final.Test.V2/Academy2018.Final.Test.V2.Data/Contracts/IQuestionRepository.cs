using Academy2018.Final.Test.V2.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy2018.Final.Test.V2.Data.Contracts
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        ICollection<Option> GetOptionsByQuestion(int questionId);

        ICollection<Answer> GetAnswersByQuestion(int questionId);

    }
}
