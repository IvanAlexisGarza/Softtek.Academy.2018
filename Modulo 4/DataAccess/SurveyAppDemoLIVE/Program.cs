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


                IRepository<QuestionTypeDTO> questionTypeRepository = new QuestionTypeEF();

                questionTypeRepository.Add(new QuestionTypeDTO
                    {
                    Description = "Testing"
                });
                context.SaveChanges();

                questionTypeRepository.Update(new QuestionTypeDTO { Description = "Haciendo cambio", QestuionTypeId = 4 });
                questionTypeRepository.Delete(4);


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
