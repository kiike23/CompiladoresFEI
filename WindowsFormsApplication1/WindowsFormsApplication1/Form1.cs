using System;
using System.Collections.Generic;
using System.Windows.Forms;

 

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            

        }
        ///variables
        ///
        String codigo = "";

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

        

        
        
    }
}
