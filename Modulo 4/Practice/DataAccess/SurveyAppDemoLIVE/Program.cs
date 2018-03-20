using DataAccesEF;
using DataAccesEF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataAccesEF.Implementation;
using DataAccess.Interfaces;
using DataAccess.DTO;
using Interfaces;

namespace SurveyAppDemoLIVE
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var context = new DemoContext())
            {
                ////not going to save this option because we didint use //context.SaveChanges();
                //context.Options.Add(new Option { OptionId = 6, Text = "HAVE YOU SEEN MALCOM IN THE MIDDLE?" });


                IQuestionTypeRepository questionTypeRepository = new QuestionTypeEF();

                questionTypeRepository.Add(new QuestionTypeDTO
                {
                    Description = "Testing",
                    CreateDate = DateTime.Now
                });
                context.SaveChanges();

                questionTypeRepository.Update(new QuestionTypeDTO { Description = "Haciendo cambio", QestuionTypeId = 3 });
                // questionTypeRepository.Delete(4);

                IQuestionRepository questionRepository = new QuestionEF();

                questionRepository.Add(new QuestionDTO
                {
                    QuestionId = 100,
                    Description = "Say WHAAAAAAT?",
                    CreateDate = DateTime.Now,
                    ModifyDate = DateTime.Now,
                    QuestionTypeId = 4
                });

                var results  = questionTypeRepository.GetAll();

                foreach (var r in results)
                {
                    Console.WriteLine(r.Description);
                }

                 Console.WriteLine("You're not the boss of me now !");
            }
        }
    }
}
