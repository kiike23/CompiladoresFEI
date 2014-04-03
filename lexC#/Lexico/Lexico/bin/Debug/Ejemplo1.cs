
using System;
using System.IO;
using System.Collections;

namespace Lexico
{
	public class MatrizDeTransicion
	{
		private int filas = 0;
		private int cols = 0;
		private int[,] estados;
		private string[] caracteres;

		public void LeerDesdeArchivo (string ruta)
		{
			FileStream stream = new FileStream (ruta, FileMode.Open, FileAccess.Read);
			StreamReader reader = new StreamReader (stream);
			
			ArrayList lines = new ArrayList ();
			while (reader.Peek () > -1) {
				lines.Add (reader.ReadLine ());
			}
			reader.Close ();
			if (lines.Count > 0) {
				filas = lines.Count - 1;
				char[] TAB = new char[] { '\t' };
				//Primera linea es vector de carateres
				string[] lineaActual = ((string)lines[0]).Split (TAB);
				cols = lineaActual.Length - 1;
				
				//Lleno el vector de caracteres
				caracteres = new string[cols];
				for (int i = 1; i < lineaActual.Length; i++) {
					caracteres[i - 1] = lineaActual[i];
				}
				
				//lleno la matriz de estados
				estados = new int[filas, cols];
				for (int i = 1; i <= filas; i++) {
					lineaActual = ((string)lines[i]).Split (TAB);
					for (int j = 1; j <= cols; j++) {
						estados[i - 1, j - 1] = int.Parse (lineaActual[j]);
					}
				}
			}
		}

		public int Mover (int de, char leyendo)
		{
			return estados[de, PosicionDelCaracter (leyendo)];
		}

		public void ImprimirMatriz ()
		{
			for (int i = 0; i < filas; i++) {
				
				for (int j = 0; j < cols; j++) {
					Console.Write ("\t" + estados[i, j]);
				}
				Console.WriteLine ();
			}
		}

		public void ImprimirVectorDeCaracteres ()
		{
			for (int i = 0; i < caracteres.Length; i++) {
				Console.WriteLine (i + "\t" + caracteres[i]);
			}
		}

		public int PosicionDelCaracter (char caracter)
		{
			string caracterS = caracter.ToString ();			
			if (Char.IsDigit (caracter)) {
				caracterS = "\\D";
			} else if (Char.IsLetter (caracter)) {
				caracterS = "\\L";				
			} else if (caracter == '\n') {
				caracterS = "\\n";
			} else if (caracter == ' ') {
				caracterS = "\\B";
			}else if (caracter == '\t') {
				caracterS = "\\B";
			}else if (caracter == '\\') {
				caracterS = "\\L";
			}
			
			
			for (int i = 0; i < caracteres.Length; i++) {
				if (caracteres[i] == caracterS) {
					return i;
				}
			}
			
			return -1;
		}
	}
}

