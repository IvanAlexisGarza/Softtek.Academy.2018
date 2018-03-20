using DataAccess.DTO;
using System.Collections.Generic;

namespace DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetAll();

        T GetById(int entityId);

        void Add(T entity);

        void Update(T entity);

        void Delete(int entityId);

        int CountItems();
    }
}
