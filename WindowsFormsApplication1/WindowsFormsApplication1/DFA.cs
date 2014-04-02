using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{

    public class DFA
    {
       public DFA(int numero, object FTrans, bool aceptacion=false, string catLex= null, bool trampa= false)
        {
           
            int num =numero;
            object ftran = FTrans;
            bool accept = aceptacion;
            string catLexica = catLex;
            bool tramp = trampa;
            
        }
        
    }

    public class DFALexico{
        /// <summary>
        /// clase due describe al automata
        /// 
        /// </summary>
        /// 
        public List<char> alfabeto{get; set;}
        List<DFA> estados = new List<DFA>();
        List<char> letras = new List<char>();
        List<string> digitos = new List<string>();
        List<string> espacios = new List<string>();
        
        public DFALexico() 
        {
            ///constructor
            ///lista de elementos del lenguaje
            ///
            
            int inicial = 0;
            char m;
            for (int i = 97; i < 123; i++)
            {
                m = Convert.ToChar(i);
                letras.Add(m);
            }
            for (int i = 65; i < 91; i++)
            {
                m = Convert.ToChar(i);
                letras.Add(m);
            }
            

            
            string n;
            for (int i = 0; i < 10; i++)
            {
                n = Convert.ToString(i);
                digitos.Add(n);
            }

            espacios.Add(" ");
            espacios.Add("\n");
            espacios.Add("\t");

            var alf = letras.Concat(digitos.ToString());
            alfabeto = alf.ToList();
            alfabeto.Concat(espacios.ToString());
 
            
        }

        public bool reconoce(string cadena)
        {
            return false;

        }
    }
}
