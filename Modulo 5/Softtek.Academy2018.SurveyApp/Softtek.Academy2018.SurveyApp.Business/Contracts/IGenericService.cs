using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Academy2018.SurveyApp.Business.Contracts
{
    public interface IGenericService<T> where T : class
    {
        int Add(T item);

        T Get(int id);

        bool Update(T item);

        bool Delete(T item);

        bool Exist(int id);
    }
}
