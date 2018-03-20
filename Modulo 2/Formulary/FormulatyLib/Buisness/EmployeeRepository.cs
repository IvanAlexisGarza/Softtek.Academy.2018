using FormulatyLib.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulatyLib.Buisness
{
    public class EmployeeRepository : IGenericRepository<Employee>
    {
        public EmployeeRepository()
        {

        }

        private readonly List<Employee> EmployeeList;

        public EmployeeRepository(List<Employee> employeeList)
        {
            EmployeeList = employeeList;
        }

        public void Create(Employee Item)
        {
            EmployeeList.Add(Item);
        }

        public bool Delete(int Id)
        {
            return EmployeeList.Remove(SearchId(Id));
        }

        public List<Employee> Search(string Filter)
        {
            //return EmployeeList.Where(e => e.FirstName.Contains(Filter) || e.LastName.Contains(Filter)).ToList();
            return EmployeeList.Where(e => e.FirstName.Contains(Filter)).ToList();
        }

        public Employee SearchId(int Id)
        {
            Employee employee = EmployeeList.Where(e => e.Id == Id).FirstOrDefault();
            return employee;
        }

        public List<Employee> Update(Employee Item)
        {
            EmployeeList[EmployeeList.FindIndex(index => index.Id == Item.Id)] = Item;
            return EmployeeList;
        }

        public void SearchByName(string Name)
        {
             EmployeeList.Where(e => e.FirstName.Contains(Name)).ToList();
        }
    }

}
