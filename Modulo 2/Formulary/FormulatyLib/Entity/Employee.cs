using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulatyLib.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Puesto { get; set; }
        public string Address { get; set; }
        public DateTime RegisterDate { get; set; }
        public Gender Gender { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }

        public Employee()
        {
        }

        public Employee(int Id, string FirstName, string LastName, string Address, DateTime RegisterDate, Gender Gender)
        {
            this.Id = Id;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.RegisterDate = RegisterDate;
            this.Gender = Gender;
        }
    }
}
