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
using System.Collections.Generic;

namespace Lexico
{
	public class Movimiento{
		private int de;
		private char leyendo;
		private int estadoSiguiente;
		
		public int De{
            get {return de;}
            set {de = value;} 
        }
		
		public char Leyendo{
            get {return leyendo;}
            set {leyendo = value;} 
        }
		
		public int EstadoSiguiente{
            get {return estadoSiguiente;}
            set {estadoSiguiente = value;} 
        }
		
		public override string ToString(){
			string l = (Leyendo == '\n') ? "salto" : Leyendo.ToString();
			l = (Leyendo == ' ') ? "blanco" : Leyendo.ToString();
			return "De " + De + ", leyendo '" + l + "', a " + EstadoSiguiente;
		}
	}

	public class Movimientos
	{
		List<Movimiento> items = new List<Movimiento>();
		
		public Movimiento Agregar(int de, char leyendo,int estadoSiguiente){
			
			Movimiento m = new Movimiento();
			m.De = de;
			m.Leyendo = leyendo;
			m.EstadoSiguiente = estadoSiguiente;			
			items.Add(m);
			return m;
		}
		
		public void Imprimir(){
			foreach(Movimiento m in items){
				Console.WriteLine(m);
			}
		}
	}
}
