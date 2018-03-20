using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encuesta;

namespace Survey
{
    class Program
    {
        //List<Questions> 
        public static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.PrintMenu();
        }
    }
}
