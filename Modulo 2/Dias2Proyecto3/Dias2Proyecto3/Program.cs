using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace Dias2Proyecto3
{
    class Program
    {
        static void Main(string[] args)
        {
            //regresar numeros primo del -10 al 1000
            bool sip = Class1.PrintPrime(-10, 1000);
            Console.Read();
        }
    }
}
