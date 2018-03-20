using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FormulatyLib.Entity;
using FormulatyLib.Buisness;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class EmployeeUTest
    {
        [TestMethod]
        public void CreateEmployee()
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
                Console.WriteLine(list[i - 1].FirstName);
            }

            Assert.AreEqual(10, list.Count);

            Assert.AreEqual(list[1].FirstName, "FirstName2");

            listEmployee.Delete(1);
            Assert.AreEqual(list[1].FirstName, "FirstName2");

        }
    }
}
