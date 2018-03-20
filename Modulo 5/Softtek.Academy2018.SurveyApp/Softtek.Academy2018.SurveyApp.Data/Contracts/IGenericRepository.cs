namespace Softtek.Academy2018.SurveyApp.Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        int Add(T item);

        T Get(int id);

        bool Update(T item);

        bool Delete(T item);
    }
}
