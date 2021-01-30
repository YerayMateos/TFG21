# -*- coding: utf-8 -*-
"""
Created on Mon Jul 13 16:46:59 2020

@author: Yeray
"""
from opensky_api import OpenSkyApi
import time
def filtrado():
    #Recuperar todos los datos de OpenSky
    api = OpenSkyApi()
    s = api.get_states()
    listAviones = []
    contador = 0 
    #Recorrer cada StateArray (avion)
    #Añadiremos en dicho array los datos que mas nos interesen de cada avion.
    #Para ello, haremos una lista de listas, donde cada lista corresponderá a un avión.
    #Añadiremos: icao24, origin_country, longitude, latitude, altitude, velocity, heading, vertical_rate
    for avion in s.states:
            contador = contador + 1
            aux = [None]*8
            aux[0] = avion.icao24
            aux[1] = avion.origin_country
            aux[2] = avion.longitude
            aux[3] = avion.latitude
            aux[4] = avion.geo_altitude
            aux[5] = avion.velocity
            aux[6] = avion.heading
            aux[7] = avion.vertical_rate
            listAviones.append(aux)
    return listAviones
def escribirFichero():
    listAviones = filtrado()
    f = open("resultado.txt", "w")
    for i in range(len(listAviones)):
        f.write(str(listAviones[i][0])+"\n"+
                str(listAviones[i][1])+"\n"+
                str(listAviones[i][2])+"\n"+
                str(listAviones[i][3])+"\n"+
                str(listAviones[i][4])+"\n"+
                str(listAviones[i][5])+"\n"+
                str(listAviones[i][6])+"\n"+
                str(listAviones[i][7])+"\n")
    f.write(str(len(listAviones)))
    f.close()   
    print("Programa terminado correctamente")

def escribirFicheroReducido():
    listAviones = filtrado()
    f = open("resultado2.txt", "w")
    i = 0
    for i in range(10):
        f.write(str(listAviones[i][0])+"\n"+
                str(listAviones[i][1])+"\n"+
                str(listAviones[i][2])+"\n"+
                str(listAviones[i][3])+"\n"+
                str(listAviones[i][4])+"\n"+
                str(listAviones[i][5])+"\n"+
                str(listAviones[i][6])+"\n"+
                str(listAviones[i][7])+"\n")
    f.write(str(len(listAviones)))
   
    f.close()   
    print("Programa terminado correctamente")


#Este es el programa principal, encargado de ejecutar el codigo a modo de bucle infinito. Para finalizar este proceso
#habria que finalizar el proceso desde el administrador de tareas. Esto pasa porque estamos realizando una simulacion en local
#la idea de esto es que se mantenga en un servidor y que se ejecute 24/7
#El programa tiene una espera de 3 segundos ya que si no se colapsa la aplicación por hacer peticiones excesivas
#Además al ser una app gratuita, hay momentos en los que se hace una petición y la coordenada no cambia hasta pasados
#8-10 segundos por lo general. De algunos aviones tendremos datos y de otros no. 
def crearDatabase(numFichero):
    listAviones = filtrado()
    f = open("DatabaseAviones/resultado"+str(numFichero)+".txt", "w")
    i = 0
    for i in range(10):
        f.write(str(listAviones[i][0])+"\n"+
                str(listAviones[i][1])+"\n"+
                str(listAviones[i][2])+"\n"+
                str(listAviones[i][3])+"\n"+
                str(listAviones[i][4])+"\n"+
                str(listAviones[i][5])+"\n"+
                str(listAviones[i][6])+"\n"+
                str(listAviones[i][7])+"\n")
    f.write(str(len(listAviones)))
    i = i + 1
   
    f.close()   
    print("Programa terminado correctamente")
def principal():
    i = 0
    while True:
        crearDatabase(i)
        i = i+1
        time.sleep(10);
principal()

    
    
    
    
    
    
    
    
    
    

