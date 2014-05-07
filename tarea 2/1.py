import sys

#variables 
terminales = []
noTerminales = []
reglas = []
tmp = []
#variables que se utilizaran para la pila del parser llr(1)
state='q0'
tabla=[]

#construir tabla
def crearTabla():
	"""
	tabla del paser ll
	"""
	#para cada noTerminal obtener sus transicion al terminal
	
	l=0
	for i in range(0,len(noTerminales)):
		#recorrer cada terminal, para cada noTerminal
		for j in range(0,len(terminales)):
			#revisar cada elemento de las reglas
			t=[]
			nt=noTerminales[i]
			ter=terminales[j]
			for x in range(0,len(reglas)):
				t=reglas[x]
				
				t1=[]
				te=()
				if (nt == t[0]):#si estamos en el no terminal deseado revisamos la regla para el terminal en turno
					t1=t[1]
					
					if (ter == t1[0]):
						te=(ter,t1)
						
					else:
						te=(ter,"ERROR")
						
				
					t=[]
					t.append(nt)
					t.append(te)

					l+=1
					tabla.append(t)
				else:
					pass	
			
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
		

if __name__ == '__main__':
	cadEval = sys.argv[2]
	leerArchivo()
	print "="*30
	
	print noTerminales
	print terminales
	
	print reglas
	print cadEval
	crearTabla()
	print tabla