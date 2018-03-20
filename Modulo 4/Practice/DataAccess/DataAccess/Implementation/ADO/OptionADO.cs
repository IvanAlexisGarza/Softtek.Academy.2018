using DataAccess.DTO;
using DataAccess.Implementation.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Implementation.ADO
{
    public class OptionADO : IRepository<OptionADO>
    {
        public void Add(OptionDTO entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<OptionDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public OptionDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<OptionDTO> GetOptionsByQuestionId(int questionId)
        {
            throw new NotImplementedException();
        }

        public void Update(OptionDTO entity)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRepository<T>
    {
    }
}
