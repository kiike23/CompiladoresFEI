import os
import sys
#=====  variables globales ======
#archivo para almacenar el DMA que se reciba por parametros

#lista de estados 
estados=[]
#lista de alfabeto del lenguaje
alfabeto=[]
#estado inicial
inicial=[]
#estados finales
finales=[]
#transciciones de los estados
trans=[]
#cadena a evaluar
cad=[]
#tabla de transciciones
tabla=[]
#expr = argv[2]
#=====
#estados=['A','B','C']
te={}
dicc={}
x=[]
dtrans={}
B=[]
C=[]

#esta funcion permite crear todas las combinaciones posibles de estados y alfabeto
#y las compara con las transciciones para ver si son correctas o no
def permu():
        cont=0
        for d in estados:
                for f in alfabeto:
                        for g in estados:
                                #se crea una concatenacion de las posibles combinaciones
                                #que pueden existir entre estados y alfabeto
                                letra=d+','+f+','+g
                                i=0
                                for a in trans:
                                        while(i<=len(trans)):
                                                #compara las combinaciones creadas con
                                                #las transciciones 
                                                if letra not in a:
                                                        break            
                                                else:
                                                        cont=cont+1
                                                        break
                                                break
        #si el numero de transciciones encontradas es diferente al numero de transciciones
        #que tiene el DMA marcara un error y saldra del programa
        if cont==len(trans):
                return True
        else:
                return False


#esta funcion lo que realiza es que toma los elementos de las transcicones y los mete
#en dos listas las cuales ocupara para crear los diccionarios para el recorrido del DMA
def elemdicc(B,C):
        n=0
        while (n<len(trans)):
                ub=trans[n]
                i=0
                n=n+1
                #guarda en estas variables las listas de transciciones que ocupara
                #en una seran los estados y en otra el alfabeto los cuales se obtinene
                # de las transciciones
                B.append(ub[i+2])
                C.append(ub[i+4])
                i=i+1
       

def validaCadena():
        b=True        
        for c in cad:
                if (c in alfabeto):
                    b=True
                else:
                    b=False
                    return b

        return b
def contLin(l):
        cont=0
        for c in l:
                if ((c == ',') or (c == ' ') or (c=='\n')):
                        cont=cont
                else:
                        cont=cont+1
        
        return cont
def validarArchivo(archivo):

#leemos las primeras 2 linea        
  
        a=open(archivo, 'r')
        b=a.readline()
        c=a.readline()
        a.close()
#leemos el total de lineas de archivo
        a=open("DMA.txt", 'r')
        nl=0
        
        for linea in open(archivo).xreadlines( ):
                nl+= 1
        n1= contLin(b)
        n2= contLin(c)
        a.close()
        
#calcular el numero de lineas que deberia tener el archivo
        contador= ((n1*n2)+4)
#validamos 2 casos de error, si fallan salimos del programa,
        #de lo contrario retornamos true
        if ( contador < nl):
                
               
                print 'Error: Archivo DMA requiere de mas transciciones'
                os.system("pause")
                exit()
        elif (contador > nl ):#siguiente validacion
                print 'Error: Archivo DMa sobre pasa el numero de transciciones'
                print nl
                print contador
                os.system("pause")
                exit()
        else: #aprobado
                f= True
        return f
def leerLineas(l,x): #metodo para recuperar solo los caracteres validos de la cadena
        
        c=0
        for c in l:
                if ((c == ',') or (c == ' ') or (c=='\n')):
                        c=c             
                else:# si es algun caracter valido se agrega a la lista
                        x.append(c)
        return x

def cargarVariables(archivo):
        archDMA = open(archivo, 'r')
        t=[]
        #leer estados
        leerLineas(archDMA.readline(),estados)
        
        #leer alfabeto
        leerLineas(archDMA.readline(),alfabeto)
        #estado inicial
        leerLineas(archDMA.readline(),inicial)
        #estado final
        leerLineas(archDMA.readline(),finales)
        #transciciones
        c=archDMA.readline()
        while c != "":
                trans.append(c)
                c=archDMA.readline()
        #print 'variables cargadas'
        archDMA.close()
        
def crearDicc(te,trans,estados,alfabeto,b,c):
    i=0
    for x in range(0,len(estados)): #calculo de elementos de los estados 
        for j in range (0,len(alfabeto)):  # crear las rutas por cada elemento del lenguaje
            #
            te.__setitem__(B[i],C[i])
            i=i+1
        dtrans.__setitem__(estados[x],te)
        te={}
    


if __name__ == '__main__':
    
    
    archivo=sys.argv[1]
    cad=sys.argv[2]
    #cargarVariables()

# proceso de validaciones
    if (validarArchivo(archivo)): ## validar que tenga las lineas requeridas para poder funcionar
        #print 'archivo: ok'
        cargarVariables(archivo)
        if (validaCadena()): ##valida la cadena que queremos evaluar, revisar que use el lenguaje apropiado 
## revisar que las transciciones sean validas
            #print 'cadena a evaluar correcta'
            if (permu()):
            
            
                ea=inicial[0] #ei
                t={}
## si todo va bien a validar la cadena
    
                
                elemdicc(B,C)
                crearDicc(te,trans,estados,alfabeto,B,C) ##diccionario con las transiciones
                print ea
                for c in cad:
                    
                    t= dtrans[ea]
                    
                    ea=t[c]
                    
                    print 'estado siguiente '+ ea
             
                if (ea in finales):
                    print cad + " es una cadena valida"
                    #return True
                else:
                     print cad + " es una cadena invalida"
                     
                     #return False

                os.system("pause")
            else:
                print 'Error con transciones de estado'
                exit()
        else:
            print 'error con la cadena recibida '+cad
            exit()
    else:
        print 'error con el archivo: '+ archivo
        exit()
