import lex, sys
#lista de tokens
tokens = (
#palabras reservadas
    'MOD','REM',
    'COMIENZA','TERMINA',
#operadores
    'SUMA','RESTA',
    'MULT', 'DIVISION',
    'IPAREN','DPAREN',
    'FINLINEA','ASIGN',
    
#otros
    'ID',
    'ENTEROS',
    'ESPACIOS',
)

#EXPRESIONES REGULARES PARA LOS SIMBOLOS

t_SUMA = r'\+'
t_RESTA = r'-'
t_DIVISION = r'/'
t_MULT = r'\*'
t_ASIGN = r'\:='
t_FINLINEA = r';'
t_IPAREN = r'\('
t_DPAREN  = r'\)'
#\W Equivle a [a-zA-Z0-9]
t_ID = r'\w+(\d\w)*'
# \d Equivale a [0-9]
t_ENTEROS = r'\d+'
#\s 	Cualquier carácter en blanco. Equivale a [ \t\n\r\f\v]
t_ESPACIOS = '\s+'  

#FUNCIONES PARA LAS PALABRAS RESERVADAS
#QUE HACER CON MOD Y ASI...

def t_MOD(t):
    r'MOD'
    return '/'
def t_newline(t):
	r'\n+'
	t.lexer.lineno += len(t.value)

def t_error(t):
	print "Lexical error: " + str(t.value[0])
	t.lexer.skip(1)

def prueba(data, lexer):
	lexer.input(data)
	while True:
		tok = lexer.token()
		if not tok:
			break
		print tok

lexer = lex.lex()

# Prueba 
if __name__ == '__main__':
    ar  = open(sys.argv[1],'r')
    data = ar.read()
    ar.close()
    print data
# Prueba

    lexer.input(data)
    prueba(data, lexer)


    
