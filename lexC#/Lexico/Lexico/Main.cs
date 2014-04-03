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

namespace Lexico
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Analizador Léxico!");
			//MatrizDeTransicion mt = new MatrizDeTransicion();
			//mt.LeerDesdeArchivo("tablaDeTransicionCsharp.csv");
			//mt.ImprimirMatriz();
			//mt.ImprimirVectorDeCaracteres();
			//Console.WriteLine(mt.PosicionDelCaracter('#'));
			
			//PalabrasReservadas pr = new PalabrasReservadas();
			//pr.LeerDesdeArchivo("palabrasReservadas.txt");
			//pr.Imprimir();
			//Console.WriteLine(pr.esPalabraReservada("public"));
			
			AnalizadorLexico alx = new AnalizadorLexico();
			alx.Escanear("Ejemplo1.cs");
			
			//Tokens tk = new Tokens();
			
			//tk.LeerDesdeArchivo("tokens.txt");
			//tk.Imprimir();
			
			
			//Console.WriteLine((int)'\n');
            Console.ReadKey();
		}
	}
}