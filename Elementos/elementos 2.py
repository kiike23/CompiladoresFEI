import sys
"""
Gramatica
"""
terminales = []
noTerminales = []
inicial = []
reglas = {}
tmp =[]
arch=[]
"""
funciones de creacion de diccionarios e iniciacion de variables
"""
def cargarElementos():
	"""
	funcion de lectura de archivo
	-se leen terminales, noTerminales y las reglas
	"""

	noTerminales.append(leerLinea(arch[0]))
	#leer terminales
	terminales.append(leerLinea(arch[1]))
	#leer inicial
	inicial.append(leerLinea(arch[2]))
	#leer reglas
    
def leerLinea(l):
	"""
	leerLineas: recibe 2 parametros,
	el primero es la linea del archivo de text
	el segundo es la lista que guardara los terminales o no terminales
	
	"""
	cad = ""
	x = []
	for c in l:
		if ((c != ',') and (c != ' ') and (c != '\n') and (c != '\t')):
			x.append(c)
		else:
			pass
	return x
def leerReglas():
	s=""
	cad = ""
	x = []
	t=[]
	r={}
	l=arch[3:]
	#eliminar comas y espacios
	for li in l:
	    for c in li:
	
			if ((c != ',') and (c != ' ') and (c != '\n') and (c != '\t')):
			    cad +=c
			else:
				x.append(cad)
				cad=''
		t.append(x)
	print t

def impDescrp():
	print "="*80
	print 'No terminales: %s ;'%noTerminales
	print 'Terminales: %s ;'%terminales
	print 'Inicial: %s ;'%inicial
	print 'Reglas: %s ;'%reglas

def cargarArchivo(archivo):
    a = open(archivo,'r')
    for l in a:
       arch.append(l)
    a.close
    
if __name__ == '__main__':
    archivo = sys.argv[1]
    #
    cargarArchivo(archivo)
    
    cargarElementos()
    impDescrp()
    print arch
