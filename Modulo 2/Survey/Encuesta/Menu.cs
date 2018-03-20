using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Encuesta
{
    public class Menu
    {
        Questions question = new Questions();

        public int PrintMenu()
        {
            int option = 0;
            Console.WriteLine("Choose an option:");
            Console.WriteLine("\t 1. Add a Question");
            Console.WriteLine("\t 2. Modify a Question");
            Console.WriteLine("\t 3. Answer a Survey");

            option = Convert.ToInt16(Console.Read());

            switch (option - '0')
            {
                case 1:
                     option = AddQuestion();
                    break;

            }
            return option;
        }

        public int AddQuestion()
        {
            int carc = 0;
            string text;
            Console.WriteLine("Choose an option:");
            Console.WriteLine("\t 1. Add a multiple choice question");
            Console.WriteLine("\t 2. Add an open question");
            Console.WriteLine("\t 3. Add a single choice question");

            //For some reason read 13 and 10, as in buffering the enter kwy 
            carc = Convert.ToInt16(Console.Read());
            carc = Convert.ToInt16(Console.Read());

            carc = Convert.ToInt16(Console.Read());

            Thread.Sleep(1000);

            switch (carc - '0')
            {
                case 1:
                    Console.WriteLine("Add thw question text please:");

                    //For some reason read 13 and 10, as in buffering the enter kwy 
                    carc = Convert.ToInt16(Console.Read());
                    carc = Convert.ToInt16(Console.Read());

                    text = Console.ReadLine();

                    question.Add(text);
                    question.Get();
                    break;
            }
            return carc;
        }
    }
}
