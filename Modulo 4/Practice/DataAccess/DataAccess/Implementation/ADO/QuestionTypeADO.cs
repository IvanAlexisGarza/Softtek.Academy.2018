using DataAccess.DTO;
using DataAccess.Implementation.Helpers;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementation.ADO
{
    public class QuestionTypeADO : IRepository<QuestionTypeADO>
    {
        public QuestionTypeADO()
        { }

        public void Add(QuestionTypeADO entity)
        {
            throw new NotImplementedException();
        }

        public int CountQuestionType()
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<QuestionTypeADO> GetAll()
        {
            throw new NotImplementedException();
        }

        public QuestionTypeADO GetById(QuestionTypeADO Entity)
        {
            throw new NotImplementedException();
        }

        public void Update(QuestionTypeADO entity)
        {
            throw new NotImplementedException();
        }
    }
}
