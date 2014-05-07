import sys

#variables 
terminales = []
noTerminales = []
reglas = []
tmp = []
#variables que se utilizaran para la pila del parser llr(1)

tabla={}
#funcion parser ll(1)
def parserLL(input):
	"""
parser ll que lee un simbolo.
p es la pila o stack. input es la cadena de entrada 
	"""
	parse = []
	dic = {}
	temp =[]
	estado = 'q0'
	symbol='' #simbolo de lectura
	ind=0 #indice den lectura
	#se coloca el simbolo # al inicio de la pila
	parse.append('#')
	estado='p'
	#iniciar la pila colocando la regla S
	parse.append('S')
	estado='q'
	#leer primer elemento de la entrada
	symbol=input[ind]
	#inicia el ciclo while para recorrer la cadena de entrada
	topPila=parse[-1]
	while (topPila != '#'): #mientras el tope de la pila no sea # hacer:
		#hacer...
		if (topPila in terminales):
			#si el tope es un terminal
			if (symbol == topPila):
				parse.pop()
				ind+=1
				symbol=input[ind]
			else:
				##error
				return False 
		elif (topPila in noTerminales):
			#si el tope de la pila es no terminal buscar sus regla
			if (topPila in tabla ):
				dic = tabla[topPila]
				parse.pop()
				#concatenar la regla a la pila
				#parse.extend(dic[symbol])
				if (dic[symbol]=="ERROR"):
					return False
				else:
					temp =(dic[symbol])
					temp.reverse()
					parse.extend(temp)
			else:
				return False
				
		elif (topPila == '#'):
			return True
		else:
			return False
		topPila=parse[-1]
#====================================================================	
#construir tabla
def crearTabla():
	"""
	tabla del paser ll
	"""
	#para cada noTerminal obtener sus transicion al terminal
	for nt in noTerminales:
		# para cada noTerminal obtener sus reglas
		tm=[]
		r={}
		for x in reglas:
			if (nt == x[0]):
				tm=x[1]
				ter = tm[0]
				c=tm[0]
				r.__setitem__(c,tm)
			
				#r.__setitem__(c,"ERROR")

		
		tabla.__setitem__(nt,r)
		
		t={}
		t=tabla[nt]
		terminales.append('$')
		for i in terminales:
			if (t.has_key(i)):
				pass
			else:
				r.__setitem__(i,"ERROR")
		tabla.__setitem__(nt,r)
#leer linea
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
	r=()
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
	r=(s,t)
	reglas.append(r)
	
	

#leer el archivo
def leerArchivo():
	a = open(sys.argv[1],'r')
#leer no terminales
	leerLineas(a.readline(),noTerminales)
#leer terminales
	leerLineas(a.readline(),terminales)
#leer reglas
	linea = a.readline()
	while  linea != "":
		leerReglas(linea,reglas,tmp)
		linea = a.readline()
		
def impDescrp():
	print "="*80
	
	print noTerminales
	print terminales
	
	print reglas
	print cadEval
	
if __name__ == '__main__':
	cadEval = sys.argv[2]
	leerArchivo()
	crearTabla()
	
	if (parserLL(cadEval)):
		print "Aprobada"
	else:
		print "Reprobada"