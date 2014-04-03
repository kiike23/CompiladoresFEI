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

namespace Lexico
{


	public class AnalizadorLexico
	{
		private int estadoActual;
		private MatrizDeTransicion mt;
		private Tokens estadosFinales;
		private Tokens tokensReconocidos;
		private int nroTokenIdentificadores;
		private int nroTokenPalabraReservada;
		private PalabrasReservadas pr = new PalabrasReservadas();
		
		public void Escanear (string ruta)
		{
			estadoActual = 0;
			mt = new MatrizDeTransicion();
			mt.LeerDesdeArchivo("tablaDeTransicionCsharp.csv");
			Movimientos m = new Movimientos();
			estadosFinales = new Tokens();
			estadosFinales.LeerDesdeArchivo("tokens.txt");
			tokensReconocidos = new Tokens();
			pr.LeerDesdeArchivo("palabrasReservadas.txt");
			
			//Buscar el numero de token de identificadores y palabra reservada
			Token tid = estadosFinales.DameToken("id");
			nroTokenIdentificadores = tid.Numero;
			tid = estadosFinales.DameToken("pr");
			nroTokenPalabraReservada = tid.Numero;	
			
			//Leer el archivo caracter por caracter
			FileStream stream = new FileStream (ruta, FileMode.Open, FileAccess.Read);
			StreamReader archivo = new StreamReader (stream);						
			
			char caracter = ' ';			
			int estadoSig;
			string palabra = "";
			bool leerDeArchivo = true;
			while (archivo.Peek () > -1) {
				if(leerDeArchivo){
					caracter = (char)archivo.Read();						
				}
				else{
					leerDeArchivo = true;
					palabra = "";
				}
				
				estadoSig = mt.Mover(estadoActual,caracter);
				//Console.WriteLine(m.Agregar(estadoActual,caracter,estadoSig));
				m.Agregar(estadoActual,caracter,estadoSig);
				estadoActual = estadoSig;
				if(estadosFinales.Contiene(estadoSig)){ //Reconocio el token
					estadoActual = 0;
					Token tk = new Token();
					tk.Numero = estadoSig;
					tk.Lexema = palabra;
					if(estadoSig == nroTokenIdentificadores){
						if(pr.EsPalabraReservada(palabra)){
							estadoSig = nroTokenPalabraReservada;
						}
					}
					//Detalles de un token
					Token tkD = estadosFinales.DameToken(estadoSig);
					if(tkD != null){
						tk.Nombre = tkD.Nombre;
						tk.Sinonimo = tkD.Sinonimo;
					}
					//Fin Detalles del token
					palabra = "";
					leerDeArchivo = false;
					tokensReconocidos.Agregar(tk);
				}
				palabra += caracter.ToString();
			}
			archivo.Close ();
			
			//m.Imprimir();
			tokensReconocidos.Imprimir();
		}		
		
	}
}
