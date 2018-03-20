using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormulatyLib;
using FormulatyLib.Entity;
using FormulatyLib.Buisness;

namespace Formulary
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> list = new List<Employee>();
            EmployeeRepository listEmployee = new EmployeeRepository(list);

            for (int i = 1; i <= 10; i++)
            {
                listEmployee.Create(
                        new Employee(i
                        , "FirstName" + i.ToString()
                        , "LastName" + i.ToString()
                        , "Address" + i.ToString()
                        , DateTime.Now
                        , Gender.Female));
                Console.WriteLine(list[i-1].FirstName);

            }

            listEmployee.Delete(3);
            listEmployee.Delete(6);
            listEmployee.Delete(3);
            listEmployee.Delete(8);


            for (int i = 1; i <= list.Count() ; i++)
            {
                Console.WriteLine(list[i-1].FirstName);
            }

            Console.Read();
        }
    }
}
