using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolCar
{
    public interface IGeneric<T>
    {
        void Add(T Item);

        bool Remove(int Id);

        bool CheckRepeat(T Item);

        bool AssignDriver(int id, List<T> driverList);

        T Search(int Id);

        int SearchId(T Item);

    }
}
