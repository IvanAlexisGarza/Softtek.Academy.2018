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
    public class QuestionTypeADO : IQuestionTypeRepository
    {
        public QuestionTypeADO()
        { }

        public void Add(QuestionTypeDTO entity)
        {
            string connectionString = ConnectionStringHelper
                .GetConnStringFromConfigFile();

            string commandText = "INSERT INTO " +
                "[dbo].[QuestionType]([Description])VALUES(@descripcion)";

            SqlParameter parameter = new SqlParameter("@descripcion",
                entity.Description);

            int rows = CommandHelper.ExecuteNonQuery(connectionString,
                commandText, CommandType.Text, parameter);

            Console.WriteLine("{0} row inserted.", rows);
        }

        public int CountQuestionType()
        {
            string connectionString =
                ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "SELECT COUNT(QuestionTypeID) " +
                " FROM [Survey].[dbo].[QuestionType]";
            int count = 0;

            Object oValue = CommandHelper.ExecuteScalar(connectionString,
                commandText, CommandType.Text);

            if (int.TryParse(oValue.ToString(), out count))
            {
                return count;
            }
            else
            {
                return 0;
            }
        }

        public void Delete(int entityId)
        {
            string connectionString = ConnectionStringHelper
               .GetConnStringFromConfigFile();

            string commandText = "DELETE FROM [dbo].[QuestionType] " +
                "WHERE QuestionTypeId = @QuestionTypeId";

            SqlParameter parameterId = new SqlParameter("@QuestionTypeId",
                entityId);

            int rows = CommandHelper.ExecuteNonQuery(connectionString,
                commandText, CommandType.Text, parameterId);

            Console.WriteLine("{0} Rows Delete.", rows);
        }

        public List<QuestionTypeDTO> GetAll()
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            List<QuestionTypeDTO> results = new List<QuestionTypeDTO>();

            string commandText = "SELECT [QuestionTypeID] ,[Description] " +
                "FROM [Survey].[dbo].[QuestionType]";

            using (SqlDataReader reader =
                CommandHelper.ExecuteReader(connectionString, 
                commandText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("ID: {0}, Description: {1} ", 
                            reader["QuestionTypeId"], reader["Description"]);

                        results.Add(new QuestionTypeDTO
                        {
                            Description = reader["Description"].ToString(),
                            QuestionTypeId = (int)reader["QuestionTypeId"]
                        });
                    }
                }
                else
                {
                    Console.Write("No rows found");
                }

                return results;
            }
        }

        public QuestionTypeDTO GetById()
        {
            throw new NotImplementedException();
        }

        public void Update(QuestionTypeDTO entity)
        {
            string connectionString = ConnectionStringHelper
                .GetConnStringFromConfigFile();

            string commandText = "UPDATE [dbo].[QuestionType] " +
                "SET Description = @Description " +
                "WHERE QuestionTypeId = @QuestionTypeId";

            SqlParameter parameter = new SqlParameter("@Description",
                entity.Description);
            SqlParameter parameterId = new SqlParameter("@QuestionTypeId",
                entity.QuestionTypeId);

            int rows = CommandHelper.ExecuteNonQuery(connectionString,
                commandText, CommandType.Text, parameter,parameterId);

            Console.WriteLine("{0} Rows Updated.", rows);

        }
    }
}
