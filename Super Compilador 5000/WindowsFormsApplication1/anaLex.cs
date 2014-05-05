using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class anaLex
    {
        public class Simbolo
        {
            private Tokens token;
            private Tokens Token { get { return token; } }
            public Simbolo(Tokens token)
            {
                this.token = token;
            }

        }
        public enum Tokens
        {
            Identificador,
            Entero,
            OpSuma,
            OpMult,
            ParnIzq,
            ParnDer,
            FinLinea,
            Asignacion,
            Termina,
            Comienza,
            EspacioVacio,
            Error,
        }


        public class Lex
        {
            private List<Simbolo> simbolos;
            private string textoEntrada;
            private int indice;
            private List<Simbolo> simbolo = new List<Simbolo>();

            public Lex(string textoEntrada, List<Simbolo> simbolos)
            {
                this.simbolos = simbolos;
                this.textoEntrada = textoEntrada;
                indice = 0;
            }

            public char GetCaracter
            {
                get
                {

                    char c;
                    try
                    {
                        c = textoEntrada[indice];
                        indice++;
                    }
                    catch (Exception)
                    {
                        c = '@';
                        return c;
                    }
                    return c;
                }
            }

            public List<Simbolo> GetSimbolos()
            {
                Simbolo simbolo;
                simbolo = this.GetToken();

                while (true)
                {
                    simbolos.Add(simbolo);
                }
                //return simbolos;
            }

            public Simbolo GetToken()
            {
                char carActual = GetCaracter;

                if (indice > textoEntrada.Length || carActual == '@')
                    return new Simbolo(Tokens.Termina);

                switch (carActual)
                {
                    case ' ': { break; }
                    case '\t': { break; }
                    case '\n': { break; }
                    case '+': { return new Simbolo(Tokens.OpSuma); }
                    case '-': { return new Simbolo(Tokens.OpSuma); }
                    case '*': { return new Simbolo(Tokens.OpMult); }
                    case '/': { return new Simbolo(Tokens.OpMult); }
                    case '(': { return new Simbolo(Tokens.ParnIzq); }
                    case ')': { return new Simbolo(Tokens.ParnDer); }
                    //case : {return new Simbolo (Tokens.Entero);}

                    default:
                        {
                            if (Char.IsDigit(carActual))
                            {
                                while (Char.IsDigit(carActual))
                                    carActual = GetCaracter;
                                if (indice < textoEntrada.Length && carActual != '@')
                                    indice--;
                                return new Simbolo(Tokens.Entero);
                            }
                            else if (Char.IsLetter(carActual))
                            {
                                while (Char.IsLetter(carActual) ||
                                Char.IsDigit(carActual))
                                    carActual = GetCaracter;
                                if (indice < textoEntrada.Length && carActual != '@') indice--;
                                return new Simbolo(Tokens.Identificador);
                            }
                            else
                                return new Simbolo(Tokens.Error);
                        }
                }
                return new Simbolo(Tokens.EspacioVacio);
            }
        }
    }
}
