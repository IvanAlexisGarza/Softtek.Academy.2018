using Softtek.Academy2018.SurveyApp.Domain.Model;

namespace Softtek.Academy2018.SurveyApp.Data.Contracts
{
    public interface IQuestionRepository : IGenericRepository<Question>
    {
        bool Activate(Question item);

        bool Exist(int id);

        bool AddOption(int optionId, int questionId);
    }
}
