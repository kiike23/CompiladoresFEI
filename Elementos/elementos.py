
"""
Gramatica
"""
terminales = ['+', '*', '(', ')', 'id']
noTerminales = ['E', 'Ep', 'T', 'Tp', 'F']

inicial = 'E' 

reglas = {'E': [['T', 'Ep']],
          'Ep': [['+','T','Ep'], ['lambda']],
          'T': [['F', 'Tp']],
          'Tp': [['*', 'F', 'Tp'], ['lambda']],
          'F' : [['(','E', ')'], ['id']]}

def primero(alpha, visitados=set({})):
    """
    visitados es para revisar si hay reglas recursivas
    """
    if alpha in terminales or alpha == 'lambda': #regla 1
        return {alpha}

    #regla2 a partir de aqui
    visitados2 = visitados.copy() #siempre copiar
    visitados2.add(alpha)
    res = set({})
    for regla in reglas[alpha]: #para cada regla de ese no terminal
        nNulls = 0 #para saber si todos los elementos contenian nulo
        for elem in regla:
            if elem in visitados2:
                print('Esta gramatica es recursiva, no se puede asegurar una solucion completa')
                break #se regresa hasta donde se haya procesado
            temp = primero(elem, visitados2)
            temp2 = temp.difference({'lambda'}) #sacar lambda
            res = res.union(temp2)
            if not 'lambda' in temp:
                break;
            else:
                nNulls += 1            
        if nNulls == len(regla): #todos los elementos de la regla tienen lambda
            res.add('lambda')
    return res

def primeroCad(lista):
    res = set({})
    nn = 0
    for c in lista:        
        temp = primero(c)
        temp2 = temp.difference({'lambda'}) #sacar lambda
        res = res.union(temp2)
        if not 'lambda' in temp:
            break
        else:
            nn += 1
    if nn == len(lista): #todos los elementos tienen el elemento vacío
        res.add('lambda')
    return res
        

def indexes(cad, c):
    res = []
    for i in range(len(cad)):
        if cad[i] == c:
            res.append(i)
    return res

#para saber los simbolos a la derecha de un no-terminal en cada regla
def buscarLadoDer(A):
    res = []
    for k in reglas:
        for regla in reglas[k]:
            if A in regla:
                for indi in indexes(regla, A): #A puede aparece mas de una vez en la regla
                    if indi+1 == len(regla): # A esta al final
                        res.append((k, []))
                    else:
                        res.append((k, regla[indi+1:]))
    return res
        
    

def siguiente(A, visitados=set({})):
    res = set({})
    visitados2 = visitados.copy()
    visitados2.add(A)
    if inicial == A: #primera regla
        res.add('$')
    for der in buscarLadoDer(A): #por cada gamma
        if der[1] != []: # A no esta al final de la regla, aplica regla 2
            temp = primeroCad(der[1])
            temp2 = temp.difference({'lambda'})
            res = res.union(temp2)
            if 'lambda' in temp: # entra en caso 3
                B = der[0] 
                if B in visitados2: #evitar recursion
                    continue
                s = siguiente(B, visitados2)
                res = res.union(s)
        else: #entra directo a la regla 3
            B = der[0] 
            if B in visitados2: #evitar recursion
                continue
            s = siguiente(B, visitados2)
            res = res.union(s)
    return res
                
        
            
        
            

            
