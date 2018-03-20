using System;
using System.Collections.Generic;
using System.CoolCar.Buisness;

namespace Training
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> CarList = new List<Car>();
            List<Driver> DriverList = new List<Driver>();

            int i=0;
            CarList.Add(new Car( i, "2", i+100, "Red", "BMW", "S3"));
            DriverList.Add(new Driver(i, "Mark", "Camp", "Red"));

            Console.WriteLine(CarList[0].Color);

            
        }
    }
}
