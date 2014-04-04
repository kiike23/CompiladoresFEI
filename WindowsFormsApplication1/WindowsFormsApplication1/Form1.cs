using System;
using System.Collections.Generic;
using System.Windows.Forms;

 

namespace WindowsFormsApplication1
{
    

    public partial class Form1 : Form
    {
        List<char> alfabeto = new List<char>();
        String f = " ";
 
        int inicial = 0, indice;
        
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
            char cActual;
            indice = 0;
            while (indice <codigo.Length){
                cActual = GetCaracter();
                if (cActual == '+') { listBox1.Items.Add(cActual + "\t OPSUMA"); }
                else if (cActual == '-') { listBox1.Items.Add(cActual + "\t OPSUMA"); }
                else if (cActual == '*') { listBox1.Items.Add(cActual + "\t OPMULT"); }
                else if (cActual == '/') { listBox1.Items.Add(cActual + "\t OPMULT"); }
                else if (cActual == '(') { listBox1.Items.Add(cActual + "\t PAREIZQ"); }
                else if (cActual == ')') { listBox1.Items.Add(cActual + "\t PAREDER"); }
                else if (cActual == ';') { listBox1.Items.Add(cActual + "\t FINLINEA"); }
                else if (cActual == ':')
                {
                    f = Convert.ToString(cActual);
                    cActual = GetCaracter();
                    if (cActual == '=') { listBox1.Items.Add(f + cActual + "\t ASIGNACION"); f = " "; }
                }
                else//reconecer las palabras
                {

                    continue;
                }
        }
                        
        }
    }

    
   
   
    
}


