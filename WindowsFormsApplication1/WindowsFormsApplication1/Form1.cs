using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

 

namespace WindowsFormsApplication1
{
    

    public partial class AnaliZator5000 : Form
    {
        List<char> alfabeto = new List<char>();
        List<Token> TabTokens = new List<Token>();
        String f = "";
 
        int inicial = 0, indice;
        
        public AnaliZator5000()
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
           
            alfabeto.Add(m = Convert.ToChar("\v"));
            alfabeto.Add(m = Convert.ToChar("\f"));
            alfabeto.Add(m = Convert.ToChar(" "));
            alfabeto.Add(m = Convert.ToChar("\n")); //salto de linea
            alfabeto.Add(m = Convert.ToChar("\t"));
            
             
            alfabeto.Add(m = Convert.ToChar("("));
            alfabeto.Add(m = Convert.ToChar(")"));
            alfabeto.Add(m = Convert.ToChar("+"));
            alfabeto.Add(m = Convert.ToChar("-"));
            alfabeto.Add(m = Convert.ToChar("/"));
            alfabeto.Add(m = Convert.ToChar("*"));
            alfabeto.Add(m = Convert.ToChar(":"));
            alfabeto.Add(m = Convert.ToChar("="));
            alfabeto.Add(m = Convert.ToChar(";"));
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
            
            comprobar();
            
        }

        public char GetCaracter()
        {
            
                char c;
                try
                {
                    c = codigo[indice];
                    indice++;
                }
                catch (Exception)
                {
                    c = '@';
                    return c;
                }

                return c;
            
        }
        public void limpiarListbox()
        {
            listBox1.Items.Clear();
        }
        public void comprobar()
        {
            char cActual;
            indice =0;
            limpiarListbox();
            int numero;
            bool b = true;
            

            while (indice<codigo.Length)
            {
                cActual = GetCaracter();
                if (indice > codigo.Length)
                {
                    break;
                }
                else
                {
                    if (alfabeto.Contains( cActual))
                    {
                        //b = true;
                        continue;
                    }
                    else
                    {
                        b = false;
                        if ((cActual != '\t') || (cActual != '\n') || (cActual != '\v') || (cActual != '\f'))
                        {
                            listBox1.Items.Add(cActual + "\tEs un caracter no valido, Pos: "+ indice);
                        }
                    }
                }
            }
                if (b == true) { textBox1.Text="Codigo aprobado";}
                else { textBox1.Text = "Error existen caracteres no validos"; }
                f = "";           
                        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpiarListbox();
            crearTablaLexemas();
            printTablaLexemas();
                        
        }
        public void printTablaLexemas()
        {
            foreach(Token t in TabTokens){
                listBox1.Items.Add(t.lexema+"\t"+t.token+"\t"+t.pos);
            }
        }
        public void crearTablaLexemas()
        {
            char cActual;
            indice = 0;
            f = "";
            TabTokens.Clear();
            while (indice < codigo.Length)
            {
                cActual = GetCaracter();
                if (cActual == '+') { 
                    //listBox1.Items.Add(cActual + "\t OPSUMA" + "\t" + indice); 
                    Token t = new Token(Convert.ToString(cActual), "OPSUMA", indice); TabTokens.Add(t); }
                else if (cActual == '-') {
                    //listBox1.Items.Add(cActual + "\t OPSUMA" + "\t" + indice);
                    Token t = new Token(Convert.ToString(cActual), "OPSUMA", indice); TabTokens.Add(t); }
                else if (cActual == '*') {
                    //listBox1.Items.Add(cActual + "\t OPMULT" + "\t" + indice); 
                    Token t = new Token(Convert.ToString(cActual), "OPMULT", indice); TabTokens.Add(t); }
                else if (cActual == '/') {
                    //listBox1.Items.Add(cActual + "\t OPMULT" + indice); 
                    Token t = new Token(Convert.ToString(cActual), "OPMULT", indice); TabTokens.Add(t); }
                else if (cActual == '(') {
                    //listBox1.Items.Add(cActual + "\t PAREIZQ" + "\t" + indice);
                    Token t = new Token(Convert.ToString(cActual), "PAREIZQ", indice); TabTokens.Add(t); }
                else if (cActual == ')') {
                    //listBox1.Items.Add(cActual + "\t PAREDER" + "\t" + indice);
                    Token t = new Token(Convert.ToString(cActual), "PAREDER", indice); TabTokens.Add(t); }
                else if (cActual == ';') {
                    //listBox1.Items.Add(cActual + "\t FINLINEA" + "\t" + indice); 
                    Token t = new Token(Convert.ToString(cActual), "FINLINEA", indice); TabTokens.Add(t); }
                else if (cActual == ':')
                {
                    f = Convert.ToString(cActual);
                    cActual = GetCaracter();
                    if (cActual == '=') {
                        //listBox1.Items.Add(f + cActual + "\t ASIGNACION" + "\t" + indice); f = " "; 
                        Token t = new Token(f, "ASIGNACION", indice); TabTokens.Add(t); }
                }
                else//reconocer las palabras
                {
                    if (cActual != (Convert.ToChar(" ")) & cActual != (Convert.ToChar("\t")) & cActual != (Convert.ToChar("\r")) & cActual != (Convert.ToChar("\n")))
                    {
                        f = f + cActual;
                    }
                    if (cActual == (Convert.ToChar(" ")) | cActual == (Convert.ToChar("\t")) | cActual == (Convert.ToChar("\n")) | cActual == (Convert.ToChar("\r")))
                    {
                        if (f == "comienza" )
                        { 
                            //listBox1.Items.Add(f + "\t INIT" + "\t" + indice);
                            Token t = new Token(f, "INIT", indice); TabTokens.Add(t);
                            f = " ";
                        }
                        else if (f == "termina") 
                        {
                            //listBox1.Items.Add(f + "\t END" + "\t" + indice);
                            Token t = new Token(f, "END", indice); TabTokens.Add(t);
                            f = " ";
                        }
                        else if (f == "mod")
                        {
                            //listBox1.Items.Add(f + "\t OPMULT" + "\t" + indice);
                            Token t = new Token(f, "OPMULT", indice); TabTokens.Add(t);
                            f = " ";
                        }
                        else if (f == "rem")
                        {
                            //listBox1.Items.Add(f + "\t OPMULT" + "\t" + indice);
                            Token t = new Token(f, "OPMULT", indice); TabTokens.Add(t);
                            f = " ";
                        }
                        else if (cActual == (Convert.ToChar(" ")))
                            //DEFINIR SI ES NUMERO O DIGITO
                        {
                            if (!alfabeto.Contains(cActual))
                            {
                                //listBox1.Items.Add(f + "\t OPMULT" + "\t" + indice);
                                Token t = new Token(f, "ERROR LEXICO", indice); TabTokens.Add(t);
                                f = " ";
                            }
                            else
                            {
                                //listBox1.Items.Add(f + "\tIDENTIFICADOR" + "\t" + indice);
                                Token t = new Token(f, "IDENTIFICADOR", indice); TabTokens.Add(t);
                                f = " ";
                            }
                        }
                        
                        else { continue; }

                    }

                    continue;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SaveFileDialog textDialog = new SaveFileDialog();
            textDialog = new SaveFileDialog();
            textDialog.Filter = "Text Files | *.txt";
            textDialog.DefaultExt = "txt";

            try
            {
                textDialog.ShowDialog();
                //bool resultado = textDialog.ShowDialog();
                //if (resultado == true)
                //{
                System.IO.Stream fileStream = textDialog.OpenFile();
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fileStream);
                String linea = "";
                foreach (Token t in TabTokens)
                {
                    linea += t.lexema + "\t" + t.token + "\t" + t.pos + "\n";
                    sw.WriteLine(linea);
                }

                sw.Flush();
                sw.Close();
                //}
            }
            catch (Exception error) {
                MessageBox.Show("Ocurrio un error al guardar el archivo :/");
            }

            
            
            
            
            
        
        }
    }

    public class Token
    {
        public string lexema;
        public string token;
        public int pos;
        public Token(string lexema, string token, int pos)
        {
            this.lexema = lexema;
            this.token = token;
            this.pos = pos;
        }

    }
   
   
    
}


