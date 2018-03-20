using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training;

namespace CoolCar.Buisness
{
    public class IGeneric : IGeneric<Driver>
    {

        private readonly List<Driver> DriverList;

        public IGeneric(List<Driver> driverList)
        {
            DriverList = driverList;
        }

        public void Add(Driver Item)
        {
            throw new NotImplementedException();
        }

        public Driver AssignDriver(int Id, Driver Item)
        {
            throw new NotImplementedException();
        }

        public bool CheckRepeat(Driver Item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int Id)
        {
            throw new NotImplementedException();
        }

        public Driver Search(int Id)
        {
            throw new NotImplementedException();
        }

        public int SearchId(Driver Item)
        {
            throw new NotImplementedException();
        }

         bool IGeneric<Driver>.AssignDriver(int id, List<Driver> driverList)
        {
            throw new NotImplementedException();
        }
    }
}
