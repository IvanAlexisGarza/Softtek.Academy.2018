using CoolCar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    public class Car
    {
        public Car()
        {

        }
        
        public int Id { get; set; }
        public string NumberOfDoors { get; set; }
        public int SerialNum { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public Driver AssignedDriver { get; set; }

        public Car(int Id, string NumberOfDoors, int SerialNum, string Color, string Brand, string Model)
        {
            this.Id = Id;
            this.NumberOfDoors = NumberOfDoors;
            this.SerialNum = SerialNum;
            this.Color = Color;
            this.Brand = Brand;
            this.Model = Model;
        }
    }
}
