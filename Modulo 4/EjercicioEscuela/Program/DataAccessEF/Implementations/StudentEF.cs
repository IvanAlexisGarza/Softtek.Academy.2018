using DataAccessEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessEF.Entities
{
    public class StudentEF : IRepository<StudentDTO>
    {
        //LOL too late
        public void Create(StudentDTO item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int itemId)
        {
            throw new NotImplementedException();
        }

        public List<StudentDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public StudentDTO GetById(int itemId)
        {
            throw new NotImplementedException();
        }

        public void Update(StudentDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
