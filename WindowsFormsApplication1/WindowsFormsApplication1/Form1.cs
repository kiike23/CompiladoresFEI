using System;
using System.Collections.Generic;
using System.Windows.Forms;

 

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<char> alfabeto = new List<char>();
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
            

            foreach (char c in alfabeto)
            {
                
                listBox1.Items.Add(c);
            }

            codigo = richTextBox1.Text;
            textBox1.Text = codigo;
         
        }
        

        

        
        
    }
}
