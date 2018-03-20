using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T item);

        void Update(T item);

        void Delete(int itemId);

        List<T> GetAll();

        T GetById(int itemId);
    }
}
