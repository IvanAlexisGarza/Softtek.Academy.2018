using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                //regresar numeros primo del -10 al 1000
                bool sip = PrintPrime(-10, 1000);
                Console.Read();
            }

            //public static bool PrintPrime(int min, int max)
            //{
            //    int i,j;
            //    bool isPrime = true;
            //    int staringValue = 2;

            //    if (min < 2)
            //    {
            //        Console.WriteLine("Los numeros primos comienzan a partir del 2 Prro !");
            //        staringValue = 2;
            //    }
            //    else
            //    {
            //        staringValue = min;
            //    }

            //    for (i= staringValue; i <= max ; i++)
            //    {
            //        for (j = staringValue; j <= i ; j++)
            //        {
            //            if (i != j && i % j == 0)
            //            {
            //                isPrime = false;
            //                break;
            //            }

            //        }

            //        if (isPrime)
            //        {
            //            Console.Write("\t" + i);
            //        }
            //        isPrime = true;
            //    }

            //    return isPrime;
            //}

        }
    }
}
