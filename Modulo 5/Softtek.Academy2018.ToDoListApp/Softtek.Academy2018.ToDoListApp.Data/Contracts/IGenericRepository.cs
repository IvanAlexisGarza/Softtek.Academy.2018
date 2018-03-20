using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.ToDoListApp.Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        int Create(T item);

        bool Update(T item);

        bool Delete(int itemId);

        bool IDExist(int itemId);

        bool NameExist(string itemName);

        T GetById(int itemId);
    }
}