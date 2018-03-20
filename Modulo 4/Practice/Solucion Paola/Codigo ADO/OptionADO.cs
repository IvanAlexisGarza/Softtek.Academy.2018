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
    public class OptionADO : IOptionRepository
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
            List<OptionDTO> results = new List<OptionDTO>();

            string connString = ConnectionStringHelper.GetConnStringFromConfigFile();

            SqlConnection connStringObj = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("dbo.GetOptions", 
                connStringObj);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@questionID", SqlDbType.Int).
                Value = questionId;

            connStringObj.Open();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
               // Console.WriteLine("QuestionId: {0}, Option text: {1}", questionId, reader["Text"]);
                results.Add(new OptionDTO
                {
                    Text = reader["Text"].ToString(),
                    OptionId = int.Parse(reader["OptionId"].ToString()),
                    QuestionId = (int)reader["QuestionId"],
                    Value = reader["Value"].ToString()
                });
            }

            connStringObj.Close();

            return results;
        }

        public void Update(OptionDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
