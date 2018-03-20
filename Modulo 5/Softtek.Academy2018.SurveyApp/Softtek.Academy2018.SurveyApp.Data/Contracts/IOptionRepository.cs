using Softtek.Academy2018.SurveyApp.Domain.Model;

namespace Softtek.Academy2018.SurveyApp.Data.Contracts
{
    public interface IOptionRepository : IGenericRepository<Option>
    {
        bool Exist(int id);
    }
}
