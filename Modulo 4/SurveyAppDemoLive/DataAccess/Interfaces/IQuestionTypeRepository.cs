using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IQuestionTypeRepository <T>
    {
        List<T> GetAll();

        T GetById(T Entity);

        void Add(T entity);

        void Update(T entity);

        void Delete(int entityId);

        int CountQuestionType();
    }
}
