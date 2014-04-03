/*
 *      This program is free software; you can redistribute it and/or modify
 *      it under the terms of the GNU General Public License as published by
 *      the Free Software Foundation; either version 3 of the License, or
 *      (at your option) any later version.
 *      
 *      This program is distributed in the hope that it will be useful,
 *      but WITHOUT ANY WARRANTY; without even the implied warranty of
 *      MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *      GNU General Public License for more details.
 *      
 *      You should have received a copy of the GNU General Public License
 *      along with this program; if not, write to the Free Software
 *      Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 *      MA 02110-1301, USA.
 */

using System;
using System.IO;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{

	public class Token{
		private int numero;
		private string lexema;
		private string sinonimo;
		private string nombre;
		
		public int Numero{
            get {return numero;}
            set {numero = value;} 
        }
		
		public string Lexema{
            get {return lexema;}
            set {lexema = value;} 
        }
		
		public string Sinonimo{
            get {return sinonimo;}
            set {sinonimo = value;} 
        }
		
		public string Nombre{
            get {return nombre;}
            set {nombre = value;} 
        }		
		
		public override string ToString(){
			string l = Lexema.Replace("\n","salto");
			l = (Lexema == " ") ? "blanco" : Lexema.ToString();
			string v = Numero + "\t" + l + "\t" + Sinonimo + "\t" + Nombre;
			return v;
		}
	}

	public class Tokens
	{
		private List<Token> items = new List<Token>();

	
		public void LeerDesdeArchivo (string ruta)
		{			
			FileStream stream = new FileStream (ruta, FileMode.Open, FileAccess.Read);
			StreamReader reader = new StreamReader (stream);
			
			Token tk;
			items.Clear();
			while (reader.Peek () > -1) {
				tk = new Token();				
				string[] fila = reader.ReadLine().Split(new char[]{'\t'});				
				tk.Numero = int.Parse(fila[0]);
				tk.Nombre = fila[1];
				tk.Sinonimo = fila[2];
				items.Add (tk);
			}
			reader.Close ();	
		}
		
		public void Imprimir(){
			foreach(Token p in items){
				Console.WriteLine(p);
			}
		}
		
		public bool Contiene(int n){
			foreach(Token tk in items){
				if(tk.Numero == n){
					return true;
				}
			}			
			
			return false;
		}
		
		public Token DameToken(int numeroDeToken){
			foreach(Token tk in items){
				if(tk.Numero == numeroDeToken){
					return tk;
				}
			}	
			return null;
		}
		
		public Token DameToken(string id){
			foreach(Token tk in items){
				if(tk.Sinonimo == id){
					return tk;
				}
			}	
			return null;
		}
		
		public void Agregar(Token tk){
			items.Add(tk);
		}
	}
}