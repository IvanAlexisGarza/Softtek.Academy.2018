using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy2018.Final.Test.V2.Data.Contracts
{
    public interface IGenericRepository<T>
    {
        ICollection<T> GetAll();

        T GetById(int itemId);

        bool Exist(string title);

        bool Exist(int itemId);
    }
}
