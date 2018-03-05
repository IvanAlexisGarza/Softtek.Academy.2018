using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Contracts
{
    public interface IGenericRepository<T> 
    {
        int Add(T item);

        ICollection<T> GetAll();

        T GetById(int id);

        bool Update(T item);

        bool Remove(int id);

        bool Exist(int id);
    }
}
