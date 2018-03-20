using Demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.Contracts
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        bool AddPlanToStudent(int studentId, int planId);
    }
}
