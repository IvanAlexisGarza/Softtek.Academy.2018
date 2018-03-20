using DataAccess.Implementation.Helpers;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Implementation.ADO
{
    class QuestionADO : IQuestionTypeRepository<QuestionADO>
    {
        public void Add(QuestionADO entity)
        {
            int rowCount = 0;

            string connString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string insertCommandText = "INSERT INTO [dbo].[Question] ([Text],[QuestionTyprId], [IsActive], [IsRequired], [])";

                        
        }

        public int CountQuestionType()
        {
            throw new NotImplementedException();
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<QuestionADO> GetAll()
        {
            throw new NotImplementedException();
        }

        public QuestionADO GetById(QuestionADO Entity)
        {
            throw new NotImplementedException();
        }

        public void Update(QuestionADO entity)
        {
            throw new NotImplementedException();
        }

        public static void TransactionTest()
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            
        }
    }
}
