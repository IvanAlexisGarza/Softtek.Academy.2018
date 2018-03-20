using DataAccess.DTO;
using DataAccess.Implementation.Helpers;
using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.Implementation.ADO
{
    public class QuestionADO : IQuestionRepository
    {
        public void Add(QuestionDTO entity)
        {
            int rowCount = 0;

            string connString = ConnectionStringHelper.GetConnStringFromConfigFile();
            string insertCommandText = "INSERT INTO [dbo].[Question] " +
                "([Text] ,[QuestionTypeID] ,[isActive] ,[IsRequired]) " +
                "VALUES(@text ,@questionTypeId,@isActive,@isRequired)";

            SqlConnection connStringObj = new SqlConnection(connString);
            SqlCommand insertCommand = new SqlCommand(insertCommandText, 
                connStringObj);

            insertCommand.Parameters.Add("@text", SqlDbType.VarChar, 200)
                .Value = entity.Text;
            insertCommand.Parameters.Add("@questionTypeId", SqlDbType.Int)
                .Value = entity.QuestionTypeId;
            insertCommand.Parameters.Add("@isActive", SqlDbType.Bit)
                .Value = entity.IsActive;
            insertCommand.Parameters.Add("@isRequired", SqlDbType.Bit)
                .Value = entity.IsRequired;

             //SqlDataAdapter adapter = new SqlDataAdapter();
            // adapter.InsertCommand = insertCommand;

            SqlDataAdapter adapter = new SqlDataAdapter
            {
                InsertCommand = insertCommand
            };

            
            connStringObj.Open();
            rowCount = adapter.InsertCommand.ExecuteNonQuery();
            connStringObj.Close();

            Console.WriteLine("Inserted {0} record", rowCount);
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<QuestionDTO> GetAll()
        {
            string connString = ConnectionStringHelper.GetConnStringFromConfigFile();

            string commandText = "SELECT * FROM [Survey].[dbo].[Question]";
            List<QuestionDTO> results = new List<QuestionDTO>();

            DataSet dsQuestionTypes = new DataSet();

            SqlDataAdapter adapter = new SqlDataAdapter(commandText, connString);

            using (SqlConnection connection = new SqlConnection(connString))
            {
                adapter.Fill(dsQuestionTypes, "Question");
               // adapter.Fill(dsQuestionTypes, "Question");
            }

            int rowCount = dsQuestionTypes.Tables["Question"].Rows.Count;

            Console.WriteLine("Row count from DataSet: {0}", rowCount);

            return results;
        }

        public QuestionDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(QuestionDTO entity)
        {
            throw new NotImplementedException();
        }


    //ME DIO FLOJERA Y LO HICE STATIC Y NO ESTA EN LA INTERFAZ
        public static void TransactionTest(QuestionDTO entity)
        {
            string connectionString = ConnectionStringHelper.GetConnStringFromConfigFile();

            //NO EXISTE!!
            int questionTypeId = 100;

            using (SqlConnection connection = 
                new SqlConnection(connectionString))
            {
                connection.Open();

                // Start a local transaction.
                SqlTransaction sqlTran = connection.BeginTransaction();

                // Enlist a command in the current transaction.
                SqlCommand command = new SqlCommand();// connection.CreateCommand();
                command.Transaction = sqlTran;
                command.Connection = connection;

                try
                {
                    command.CommandText =
                     "INSERT INTO [dbo].[Question] ([Text] ,[QuestionTypeID] ,[isActive] ,[IsRequired]) " +
                "VALUES(@text ,@questionTypeId,@isActive,@isRequired)";

                    command.Parameters.Add("@text", SqlDbType.VarChar, 200).Value = entity.Text;
                    command.Parameters.Add("@questionTypeId", SqlDbType.Int).Value = questionTypeId;
                    command.Parameters.Add("@isActive", SqlDbType.Bit).Value = entity.IsActive;
                    command.Parameters.Add("@isRequired", SqlDbType.Bit).Value = entity.IsRequired;

                    command.ExecuteNonQuery();

                    // Commit the transaction.
                    sqlTran.Commit();
                    Console.WriteLine("Both records were written to database.");
                }
                catch (Exception ex)
                {
                    // Handle the exception if the transaction fails to commit.
                    Console.WriteLine(ex.Message);

                    try
                    {
                        // Attempt to roll back the transaction.
                        sqlTran.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    }
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
