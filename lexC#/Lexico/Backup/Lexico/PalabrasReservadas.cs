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

namespace Lexico
{


	public class PalabrasReservadas
	{
		private List<string> palabras = new List<string>();

	
		public void LeerDesdeArchivo (string ruta)
		{			
			FileStream stream = new FileStream (ruta, FileMode.Open, FileAccess.Read);
			StreamReader reader = new StreamReader (stream);
			
			palabras.Clear();
			while (reader.Peek () > -1) {
				palabras.Add (reader.ReadLine ());
			}
			reader.Close ();	
		}
		
		public void Imprimir(){
			foreach(string p in palabras){
				Console.WriteLine(p);
			}
		}
		
		public bool EsPalabraReservada(string palabra){
			return palabras.Contains(palabra);
		}
	}
}
