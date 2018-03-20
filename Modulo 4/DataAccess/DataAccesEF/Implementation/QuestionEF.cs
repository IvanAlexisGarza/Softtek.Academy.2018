using DataAccesEF.Entities;
using DataAccess.DTO;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesEF.Implementation
{
    public class QuestionEF : IRepository<QuestionDTO>
    {
        public void Add(QuestionDTO entity)
        {
            throw new NotImplementedException();
        }

        public int CountItems()
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<QuestionDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public QuestionDTO GetById(int entityId)
        {
            throw new NotImplementedException();
        }

        public void Update(QuestionDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
