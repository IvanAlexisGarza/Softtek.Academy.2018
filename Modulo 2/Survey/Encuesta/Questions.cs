using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encuesta
{
    public class Questions
    {
       List<string> text_is = new List<string>();
        public int id;

        public List<string> Get()
        {
            return text_is;
        }

        public void Add(string text)
        {
            text_is.Add(text);
            id = text_is.Count;
        }

        public class otraClase
        {
            public int numero;
            public string cadena;
        }

        private void myMto()
        {
                        
            List<otraClase> miLista = new List<otraClase>();
            miLista.Find(delegate (otraClase a) 
                { return a.cadena == "loque quieroque sea" 
                            && a.numero == 2; });

            miLista.Find(x =>  x.cadena == "loque quieroque sea" && x.numero == 2);
                        
        }
    }
}
