using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training;
using CoolCar;

namespace CoolCar.Buisness
{
    public class CarInterace : IGeneric<Car>, IGeneric<Driver>
    {

        private readonly List<Car> CarList;

        public CarInterace(List<Car> carList)
        {
            CarList = carList;
        }

        public void Add(Car Item)
        {
            CarList.Add(Item);
        }

        public void Add(Driver Item)
        {
            throw new NotImplementedException();
        }

        public bool AssignDriver(int id, List<Car> carList )
        {
            throw new NotImplementedException();
        }

        public bool AssignDriver(int id, List<Driver> driverList)
        {
            Driver assign = driverList[driverList.FindIndex(x => x.FavoriteColor == CarList[id].Color)];
            CarList[id].AssignedDriver = assign;

            return true;
        }

        public bool CheckRepeat(Car Item)
        {
            return Item.Equals(CarList);
        }

        public bool CheckRepeat(Driver Item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int Id)
        {
            Car Item = Search(Id);
            CarList.Remove(Item);
            return true;
        }

        public Car Search(int Id)
        {
            Car Item = CarList.Where(Index => Index.Id == Id).First();
            return Item;
        }

        public int SearchId(Car Item)
        {
            int Id = Item.Id;
            return Id;
        }

        public int SearchId(Driver Item)
        {
            throw new NotImplementedException();
        }

        Driver IGeneric<Driver>.Search(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
