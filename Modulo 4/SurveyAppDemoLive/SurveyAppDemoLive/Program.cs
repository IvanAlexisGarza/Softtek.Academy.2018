using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Implementation.Helpers;
using DataAccess.Interfaces;
using DataAccess.Implementation.ADO;
using DataAccess.DTO;

namespace SurveyAppDemoLive
{
    class Program
    {
        static void Main(string[] args)
        {
            QuestionTypeADO questionTypeRepository = new QuestionTypeADO();

            //Demo 1
            //

            //Demo2
            //ConnectionStringHelper.OpenSqlConnectionInCode();

            //Demo 3
            //questionTypeRepository.Add(new QuestionTypeDTO { Description = "Opcion Abierte" });

            //int count = questionTypeRepository.CountQuestionType();

            //Console.WriteLine(count);

            var results = questionTypeRepository.GetAll();

            Console.Read();
        }
    }
}
