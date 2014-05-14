import sys

#variables globales

palabras=[]
cat={
	':=':'Asignacion'
	,'*':'OpMult','/':'OpMult','mod':'OpMult','rem':'OpMult','-':'OpSuma','+':'OpSuma'
	,'comienza':'Init','termina':'End'
	,'(':'ParentesisIzq',')':'ParentesisDer'
	,';':'FinLinea'}
TablaLex=[]
digitos = [str(c) for c in range(0,10)]
def crearTabla(cat):
	t=()
	for p in palabras:
		if (p == ""):
			pass
		elif cat.has_key(p):
			t=(p,cat.get(p))
			TablaLex.append(t)
		
		else:
			if (p[0] in digitos):
				i=0
				cad=''
				while (i < len(p)):
					c=p[i]
					if (c in digitos):
						cad+=c
						i+=1
					else:
						t=(cad,'entero')
						TablaLex.append(t)
						cad=''
						t=(p[i:],'identificador')
						TablaLex.append(t)
						break
				if cad !='':
					t=(cad,'entero')
					TablaLex.append(t)
			else:
				t=(p,'identificador')
				TablaLex.append(t)
				
						
					
				
		
		t=()
def obtPal(l,x):
	"""
	leerLineas: recibe 2 parametros,
	el primero es la linea del archivo de text
	el segundo es la lista que guardara los terminales o no terminales
	
	"""
	cad = ""
	for c in l:
		if ((c != ',') and (c != ' ')and (c != "") and (c != '\n') and (c != '\t')):
			if c == ';' or c== '('or c== ')':
				"""
				si se encontro un ';' o un '(' o un ')'de fin de linea
				la palabra formada hasta el momento se guarda
				y despues se agrega el caracter especial
				los espacios ya se descartaron e
				"""
				x.append(cad)
				x.append(c)
			else:
				"""
				formando la palabra
				aqui es donde debo definir si es entero o identificador
				
				"""
				cad+=c
		else:
			if cad != "":
				"""
				como tuve un problema con el salto de linea del fin de cada linea
				aqui es donde evito que se envie a la lista de palabras la cadena en blanco
				"""
				x.append(cad)
			cad=""
	x.append(cad)
	return x



if __name__ == '__main__':
	codigo=""	
	try:
		a = open(sys.argv[1],'r')
		for linea in a:
			if linea != '\n':
				codigo +=(linea)
			else:
				pass
		a.close()
		
	except:
		print "error de lectura|"
	
	obtPal(codigo,palabras)
	crearTabla(cat)
	print TablaLex	
	