using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class PresentYourself
    {
        static void Main(string[] args)
        {
            var names = new List<String>();
            names.Add("Ivan Alexis");

            //Present yourself
            Console.WriteLine($"\t Hello  my name is {names[0]} !");

            //Ask for name
            Console.WriteLine("\t What's your name ?");
            Console.Write(" \t");
            names.Add(Console.ReadLine());

            //Greet new friend
            Console.WriteLine($"\t Pleased to meet you {names[1]}");
            Console.ReadLine();
        }
    }
}
