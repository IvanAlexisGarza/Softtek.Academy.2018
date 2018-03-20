using EFLibrary.Entities;
using EFLibrary.Helper;
using EFLibrary.Implementation;
using EFLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExaminationM4
{
    public class Program
    {
        static void Main(string[] args)
        {
            DemoInitializer filler = new DemoInitializer();
            //filler.DBFiller();
            using (var context = new DemoContext())
            {
                IRepository<ItemInfoDTO> itemRepository = new ItemEF();
                IRepository<TagDTO> tagRepository = new TagEF();
                TagDTO tagTest = new TagDTO{ Title = "main tag test" };
                context.SaveChanges();
                ItemInfoDTO itemtest = new ItemInfoDTO { Title = "tag main test", Archived = false, Description = "Step 1 Wipe the floor at the Academy / Step 2: ? / Step 3: Profit $$$$$$$$", CreationDate = DateTime.Now, ModDate = DateTime.Now, Priority = 1, StatusId = 1, DueDate = new DateTime(2020, 10, 27) };
                context.SaveChanges();

                itemRepository.AddTags(tagTest, itemtest);
                context.SaveChanges();
            }



        }
    }
}

//public void ChangeStatus(int id, int status)
//{
//    switch (status)
//    {
//        case 1://Draft    
//            if (STaskList[id].StatusId == Status.New || STaskList[id].StatusId == Status.InProgress)
//            {
//                STaskList[id].StatusId = Status.Draft;
//                Console.WriteLine("Status changed successfully !");
//            }
//            else
//            {
//                Console.WriteLine("You can't change to that status");
//            }
//            break;

//        case 2: //New
//            if (STaskList[id].StatusId == Status.Draft)
//            {
//                STaskList[id].StatusId = Status.New;
//                Console.WriteLine("Status changed successfully !");
//            }
//            else
//            {
//                Console.WriteLine("You can't change to that status");
//            }
//            break;

//        case 3://InProgress
//            if (STaskList[id].StatusId == Status.New)
//            {
//                STaskList[id].StatusId = Status.InProgress;
//                Console.WriteLine("Status changed successfully !");
//            }
//            else
//            {
//                Console.WriteLine("You can't change to that status");
//            }
//            break;

//        case 4://Cancel
//            if (STaskList[id].StatusId == Status.New || STaskList[id].StatusId == Status.InProgress)
//            {
//                STaskList[id].StatusId = Status.Cancel;
//                Console.WriteLine("Status changed successfully !");
//            }
//            else
//            {
//                Console.WriteLine("You can't change to that status");
//            }
//            break;

//        case 5://Done
//            if (STaskList[id].StatusId == Status.InProgress)
//            {
//                STaskList[id].StatusId = Status.Done;
//                Console.WriteLine("Status changed successfully !");
//            }
//            else
//            {
//                Console.WriteLine("You can't change to that status");
//            }
//            break;
//    }

//}

//namespace SurveyAppDemo
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {

//            /* IQuestionTypeRepository questionTypeRepository = new QuestionTypeADO();

//             int count;

//             IOptionsRepository optionRepository = new OptionADO();


//             QuestionTypeDTO question = new QuestionTypeDTO();
//             OptionDTO option = new OptionDTO();

//             //DEMO 2
//             //ConnectionStringHelper.OpenSqlConnectionInFromAppConfig();

//             //DEMO 3
//             // questionTypeRepository.Add(new QuestionTypeDTO { Description = "cerrada" });


//             //count = questionTypeRepository.CountQuestionType();
//             //Console.WriteLine("Hay {0} elementos en la tabla.", count);

//             //questionTypeRepository.GetAll();

//             //questionTypeRepository.Delete(1006);


//             //question.QustionTypeId = 1003;
//             //question.Description = "abierta";

//             //questionTypeRepository.Update(question);

//             //questionTypeRepository.GetById(1003);


//             //AGREGA DATOS EN LA TABLA OPTION DE LA BASE DE DATOS USANDO UN Store Procedure
//             //option.Text = "Casado";
//             //optionRepository.Add(option);


//             /*****************************************************************************************
//              *   ENTITY FRAMEWORK                                                                    *
//              *****************************************************************************************
//             using (var context = new DemoContext())
//             {
//                 context.QuestionsTypes.Add(new QuestionType { Description = " update" });
//                 context.SaveChanges();
//             }*/


//            //QUESTIONTYPE EF
//            /* IQuestionTypeRepository questionTypeRepository = new QuestionTypeEF();
//             // ADD EF
//             questionTypeRepository.Add(new QuestionTypeDTO
//             {
//                 Description = "vaia vaia",
//                 CreateDate = DateTime.Now
//             });

//             var result = questionTypeRepository.GetAll();

//             foreach (var item in result)
//             {
//                 Console.WriteLine(item.Description);
//             }


//             //UPDATE EF
//             questionTypeRepository.Update(new QuestionTypeDTO { QustionTypeId = 7, Description = "Waaaaaooh!!!" });

//             //DELETE
//             questionTypeRepository.Delete(6);

//             Console.WriteLine(" ");

//             foreach (var item in result)
//             {
//                 Console.WriteLine(item.Description);
//             }
//             */

//            IQuestionRepository questionTypeRepository = new QuestionEF();

//            /* questionTypeRepository.Add(new QuestionDTO
//             {
//                 Text = "¿Tienes hijos?",
//                 QuestionTypeId = 2,
//                 CreateDate = DateTime.Now,
//                 HasAnswer = false
//             });*/

//            var result = questionTypeRepository.GetById(4);

//            //Console.WriteLine("{0}",result.)

//            /* IOptionsRepository optionRepository = new OptionEF();

//             optionRepository.Add(new OptionDTO{
//                 Text = "pruebas",
//                 CreateDate = DateTime.Now,
//                 Description = "Fue agregado en las pruebas"

//             });*/



//            Console.WriteLine("YA TERMINEEEEE!!!!!!!!!!!!!");


//            Console.ReadLine();
//        }
//    }
//}
