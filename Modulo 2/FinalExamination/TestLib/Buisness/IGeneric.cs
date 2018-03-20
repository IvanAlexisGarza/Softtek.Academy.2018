using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Change to abstract Class since methotds are to specific for a Interface
namespace TestLib.Buisness
{
    interface IGeneric<T>
    {
        void AssignDueDate(int id);

        void AssignPriority(int priority);

        void Create(T item);

        void ChangeStatus(int id, int status);

        void Modify(int id, int option);

        void Remove(int id);

        T SearchId(int id);

        void Archive(T item);
    }
}
