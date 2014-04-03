using System;
using System.Collections.Generic;
using System.Windows.Forms;

 

namespace WindowsFormsApplication1
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

    public partial class Form1 : Form
    {
        List<char> alfabeto = new List<char>();
        List<Simbolo> simbolos = new List<Simbolo>();
        //List<EstadosDFA> estados = new List<EstadosDFA>();

 
        int inicial = 0;
        
        public Form1()
        {
            InitializeComponent();
            crearListas();

        }
        ///variables
        ///
        string codigo = "";

        public void crearListas()
        {
           
           
            int inicial = 0;
            char m;
            for (int i = 97; i < 123; i++)
            {
                m = Convert.ToChar(i);
                alfabeto.Add(m);
            }
            for (int i = 65; i < 91; i++)
            {
                m = Convert.ToChar(i);
                alfabeto.Add(m);
            }



            string n;
            for (int i = 0; i < 10; i++)
            {
                n = Convert.ToString(i);
                alfabeto.Add(m = Convert.ToChar(n));
            }

            alfabeto.Add(m = Convert.ToChar(" "));
            alfabeto.Add(m = Convert.ToChar("\n"));
            alfabeto.Add(m = Convert.ToChar("\t"));
            alfabeto.Add(m = Convert.ToChar("+"));
            alfabeto.Add(m = Convert.ToChar("-"));
            alfabeto.Add(m = Convert.ToChar("/"));
            alfabeto.Add(m = Convert.ToChar("*"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an OpenFileDialog object.
            OpenFileDialog archivo = new OpenFileDialog();

            // Initialize the filter to look for text files.
            archivo.Filter = "Archivos AdaMini|*.txt";

            // If the user selected a file, load its contents into the RichTextBox.
            if (archivo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                richTextBox1.LoadFile(archivo.FileName,
                RichTextBoxStreamType.PlainText);
            System.IO.StreamReader objReader;
            objReader = new
            System.IO.StreamReader(archivo.OpenFile());
            codigo =
            objReader.ReadToEnd();
            archivo.Dispose();

            
           
        }
       
        private void button2_Click(object sender, EventArgs e)
        {

            codigo = richTextBox1.Text;
            textBox1.Text = codigo;
            Lex a = new Lex(codigo, simbolos);
             foreach (Simbolo c in simbolos)
            {
                
                listBox1.Items.Add(c);
            }
            
        }
        

        

        
        
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

        private char GetCaracter
        {
            get {
                char c;
                try
                {
                    c = textoEntrada[indice];
                    indice++;
                }
                catch(Exception)
                {
                    c= '@';
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
	        char carActual= GetCaracter;

	        if (indice > textoEntrada.Length || carActual == '@')
	        return new Simbolo (Tokens.Termina);

	        switch(carActual)
	        {
	        case ' ': {break;}
	        case '\t':{break;}
	        case '\n':{break;}
	        case '+': {return new Simbolo (Tokens.OpSuma);}
	        case '-': {return new Simbolo (Tokens.OpSuma);}
	        case '*': {return new Simbolo (Tokens.OpMult);}
	        case '/': {return new Simbolo (Tokens.OpMult);}
	        case '(': {return new Simbolo (Tokens.ParnIzq);}
	        case ')': {return new Simbolo (Tokens.ParnDer);}
	        //case : {return new Simbolo (Tokens.Entero);}

	        default:
	        {
			        if(Char.IsDigit(carActual))
			        {
				        while (Char.IsDigit(carActual))
					        carActual=GetCaracter;
					        if(indice<textoEntrada.Length && carActual!='@')
						        indice--; 
                        return new Simbolo(Tokens.Entero);
			        }
			        else if(Char.IsLetter(carActual))
			        {
				        while (Char.IsLetter(carActual)||
				        Char.IsDigit(carActual))
				        carActual=GetCaracter;
				        if(indice<textoEntrada.Length && carActual!='@') indice--;
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


