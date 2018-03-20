using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulatyLib.Buisness
{
    public interface IGenericRepository<T> /*where T:class*/
    {
        void Create(T Item);

        List<T> Update(T Item);

        bool Delete(int Id);

        T SearchId(int Id);

        List<T> Search(string Filter);
    }
}
