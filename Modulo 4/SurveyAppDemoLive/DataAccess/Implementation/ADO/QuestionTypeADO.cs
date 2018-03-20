using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTO;
using System.Data.SqlClient;
using DataAccess.Implementation.Helpers;
using System.Data;

namespace DataAccess.Implementation.ADO
{
    public class QuestionTypeADO : IQuestionTypeRepository<QuestionTypeDTO>
    {
        public QuestionTypeADO()
        {
        }

        public void Add(QuestionTypeDTO entity)
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();

            string commandText = "INSERT INTO [dbo].[QuestionTypes]([Description]) VALUES(@description)";

            SqlParameter parameter = new SqlParameter("@description", entity.Description);

            int rows = CommandHelper.ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameter);

            Console.WriteLine("{0} row inserted", rows);
        }

        public int CountQuestionType()
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string commandText = "SELECT COUNT(QuestionTypeId)FROM[Survey].[dbo].[QuestionTypes]";
            int count = 0;

            Object oValue = CommandHelper.ExecuteScalar(connectionString, commandText, CommandType.Text);

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
            throw new NotImplementedException();
        }

        public List<QuestionTypeDTO> GetAll()
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            List<QuestionTypeDTO> results = new List<QuestionTypeDTO>();

            string commandText = "SELECT[QuestionTypeId], [Description] FROM [Survey].[dbo].[QuestionTypes]";

            using (SqlDataReader reader = CommandHelper.ExecuteReader(connectionString, commandText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("ID: {0}, Description: {1}", reader["QuestionTypeId"], reader["Description"]);

                        results.Add(new QuestionTypeDTO
                        {
                            Description = reader["Description"].ToString(),
                            QestuionTypeId = (int)reader["QuestionTypeId"]
                        });
                    }
                }
                else
                {
                    Console.WriteLine("No Rows Found Boi !");
                }

                return results;
            }
        }

        public QuestionTypeDTO GetById(QuestionTypeDTO entity)
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();
            QuestionTypeDTO result = new QuestionTypeDTO();

            string commandText = "SELECT[QuestionId], [Description] FROM [Survey].[dbo].[Questions] WHERE [QuestionId] == [@Index]";

            SqlParameter parameter = new SqlParameter("@Index", entity.QestuionTypeId);

            using (SqlDataReader reader = CommandHelper.ExecuteReader(connectionString, commandText, CommandType.Text))
            {
                if (reader.HasRows)
                {
                    Console.WriteLine("ID: {0}, Description: {1}", reader["QuestionTypeId"], reader["Description"]);

                    result.Description = reader["Description"].ToString();
                    result.QestuionTypeId = (int)reader["QuestionTypeId"];
                }
                else
                {
                    Console.WriteLine("No Rows Found Boi !");
                }

                return result;
            }
        }

        public void Update(QuestionTypeDTO entity)
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();

            string commandText = "update [dbo].[QuestionTypes]" +
                                " set [Description] = @description" +
                                "where [QestuionTypeId] == @Index";

            SqlParameter parameter = new SqlParameter("@description", entity.Description);
            SqlParameter parameter2 = new SqlParameter("@Index", entity.QestuionTypeId);

            int rows = CommandHelper.ExecuteNonQuery(connectionString, commandText, CommandType.Text, parameter, parameter2);

            Console.WriteLine("{0} row Updated", rows);
        }
    }
}
