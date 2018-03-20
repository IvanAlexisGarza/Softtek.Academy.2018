using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            String value = "ligar es ser agil";
            int j, i;
            bool palindrome = true;


            //remove spaces and get char count
            string substrings = value.Replace(" ", String.Empty);
            j = substrings.Count() -1 ;

            //check palindrome 
            for (i = 0; palindrome && i <= j; i++)
            {
                
                if (substrings[i] != substrings[j])
                {
                    Console.WriteLine($"{value} \n Is not a palindrome");
                    palindrome = false;
                }
                j--;
            }

            if(palindrome)
            {
                Console.WriteLine($"{value} \n Is  a palindrome");
            }

            Console.Read();
        }
    }
}

