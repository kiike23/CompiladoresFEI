import sys

#variables globales

palabras=[]
catLexicas={':=':'Asignacion','*':'OpMult','/':'OpMult',
            'MOD':'OpMult','REM':'OpMult','-':'OpSuma',
            '+':'OpSuma','comienza':'Init','termina':'End',
            '(':'ParentesisIzq',')':'ParentesisDer',';':'FinLinea'}
TablaLex={}
codigo=""
def obtPal(l,x):
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


def leerArchivo(codigo):
	a = open(sys.argv[1],'r')
	for linea in a:
		codigo+=linea
	return codigo

if __name__ == '__main__':
	cadEval = sys.argv[1]
	print cadEval
	leerArchivo(codigo)
	#obtPal(codigo,palabras)
	print codigo
	print palabras
	
	