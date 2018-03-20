using Softtek.Academy2018.SurveyApp.Domain.Model;
using System.Collections.Generic;

namespace Softtek.Academy2018.SurveyApp.Data.Contracts
{
    public interface IQuestionTypeRepository
    {
        QuestionType Get(int id);

        ICollection<QuestionType> GetAll();
    }
}
