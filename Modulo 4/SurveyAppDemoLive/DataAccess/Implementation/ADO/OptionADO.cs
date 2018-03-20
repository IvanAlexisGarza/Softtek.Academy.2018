using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using DataAccess.DTO;
using DataAccess.Implementation.Helpers;
using System.Data.SqlClient;

namespace DataAccess.Implementation.ADO
{
    public class OptionADO : IQuestionTypeRepository<OptionDTO>
    {
        public void Add(OptionDTO entity)
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

        public List<OptionDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public OptionDTO GetById(OptionDTO Entity)
        {
            List<OptionDTO> results = new List<OptionDTO>();

            string connString = ConnectionStringHelper.GetconnStringFromConfigFile();

            SqlConnection connStringObj = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("dbo.GetOptions", connStringObj);

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Add("@questionId", sqlDbType.Int).Value = questionId;

            connStringObj.Open();

            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Console.WriteLine("QuestionId: {0}, Option text: {1}", questionId);
                    results.Add(new OptionDTO
                    {
                        Text = reader["Test"].ToString(),
                        OptionId = int.Parse(reader["OptionId"].ToString()),
                        QuestionId = (int)reader["QuestionId"],
                        Value = reader["Value"].ToString()
                    });

                } 
            }
        }

        public void Update(OptionDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
