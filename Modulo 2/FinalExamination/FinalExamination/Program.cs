using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestLib.Buisness;
using TestLib.Entity;

namespace FinalExamination
{
    class Program
    {
        static void Main(string[] args)
        {
            //Menu show = new Menu();
            //show.PrintMenu();

            List<STask> list = new List<STask>();
            TaskRepository listSTask = new TaskRepository(list);

            //string filename = @"\MyTest.txt";
            //System.IO.File.WriteAllText(@"\path.txt", listSTask);

            Console.WriteLine("Welcome !");
            Console.WriteLine("Choose and Option:");
            Console.WriteLine("1. Create a new Task");
            Console.WriteLine("2. Modify an existing Task");
            Console.WriteLine("3. Create a new Tag");
            Console.WriteLine("4. Archive a Task");
            Console.WriteLine("5. Sort Task's");
            Console.WriteLine("6. Show Task Assosiations");


            int option = Console.Read();
            Console.Read();
            Console.Read();

            switch ((option - '0'))
            {
                case 1:
                    {
                        STask item = new STask();
                        listSTask.Create(item);
                    }
                    break;

                case 2:
                    {

                    }
                    break;
            }

        }



    }
}
