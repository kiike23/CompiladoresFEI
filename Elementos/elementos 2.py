import sys
"""
Gramatica
"""
terminales = []
noTerminales = []
inicial = ""
reglas = {}
tmp =[]

"""
funciones de creacion de diccionarios e iniciacion de variables
"""
def leerArchivo(archivo):
    """
    funcion de lectura de archivo
    -se leen terminales, noTerminales y las reglas
    """
    a.open(sys.argv[1], 'r')
    #leer no terminales
    leerLineas(a.readline(),noTerminales)
    #leer terminales
    leerLineas(a.readline(),terminales)
    #leer inicial
    leerLineas(a.readline(),inicial)
    #leer reglas
    linea = a.readline()
    while  linea != "":
        leerReglas(linea,reglas)
        linea = a.readline()
    a.close()
def leerLineas(l,x):
	"""
	leerLineas: recibe 2 parametros,
	el primero es la linea del archivo de text
	el segundo es la lista que guardara los terminales o no terminales
	
	"""
	cad = ""
	for c in l:
		if ((c != ',') and (c != ' ') and (c != '\n') and (c != '\t')):
			x.append(c)
		else:
			pass
	return x
def leerReglas(l,r,t):
	s=""
	cad = ""
	t=[]
	r={}
	#eliminar comas y espacios
	for c in l:
		if ((c != ',') and (c != ' ') and (c != '\n') and (c != '\t')):
			cad +=c
		else:
			pass
	# validar que el primer elemento sea noTermina
	#gusardarlo como regla y el resto en una lista
	b= 0
	for c in cad:
		if b == 0:
			if (c in noTerminales):
				s=c
				b=1
			else:
				print "Error %s no es un noTerminal" %(c)
		else: #ya se obtuvo la regla
			if ((c in terminales) or (c in noTerminales) or (c == '0')):
				t.append(c)
			else:
				print "Error %s no es un caracter no valido" %(c)
	reglas.__setitem__(s,t)
	
def impDescrp():
	print "="*80
	
	print noTerminales
	print terminales
	
	print reglas
	print inicial

if __name__ == '__main__':
   
    archivo = sys.argv[1]
    a.open(sys.argv[1], 'r')
    #leer no terminales
    leerLineas(a.readline(),noTerminales)
    #leer terminales
    leerLineas(a.readline(),terminales)
    #leer inicial
    leerLineas(a.readline(),inicial)
    #leer reglas
    linea = a.readline()
    while  linea != "":
        leerReglas(linea,reglas)
        linea = a.readline()
    a.close()
    impoDescrip()