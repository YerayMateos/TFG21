using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Globalization;
namespace AvionesGeneral { 
    public class ProgramUnity
    {
        public static Dictionary<string,AvionUnity> crearAviones(Dictionary<string, AvionUnity> diccionario)
        {
            string[] lines = new string[0];
            string aux = "";
            try {
                lines = System.IO.File.ReadAllLines(@"D:\Yeray\Escritorio\TFG\opensky-api-master\python\dist\resultado2.txt");
                //lines = System.IO.File.ReadAllLines(@"D:\Yeray\Escritorio\TFG\opensky-api-master\python\DatabaseAviones\resultado0.txt");
                aux = lines[0];
            }
            catch(Exception) {
                UnityEngine.Debug.LogError("Ha habido problemas al abrir el fichero");
            }

            AvionUnity a;
            double[] ECEF = new double[3];
            int numAviones = lines.Length - 1;
            if (lines.Length != 0)
            {
                for (int i = 0; i < (numAviones); i = i + 8)
                {
                    a = new AvionUnity(null, null, Double.Epsilon, Double.Epsilon, Double.Epsilon, Double.Epsilon, Double.Epsilon, Double.Epsilon, 0, 0, 0);
                    if (!((string)lines[i + 2]).Equals("None") && !((string)lines[i + 3]).Equals("None") && !((string)lines[i + 4]).Equals("None"))
                    {
                        ECEF = ConversorUnity.GeoToECEF(double.Parse((lines[i + 3]), new CultureInfo("en-US")), double.Parse((lines[i + 2]), new CultureInfo("en-US")), double.Parse((lines[i + 4]), new CultureInfo("en-US")));
                        a.setXGlobal(ECEF[0]);
                        a.setYGlobal(ECEF[1]);
                        a.setZGlobal(ECEF[2]);
                    }
                    if (!((string)lines[i]).Equals("None"))
                    {
                        a.setIcao(lines[i]);
                    }
                    if (!((string)lines[i + 1]).Equals("None"))
                    {
                        a.setPais(lines[i + 1]);
                    }
                    if (!((string)lines[i + 2]).Equals("None"))
                    {
                        a.setLong(double.Parse((lines[i + 2]), new CultureInfo("en-US")));
                    }
                    if (!((string)lines[i + 3]).Equals("None"))
                    {
                        a.setLat(double.Parse((lines[i + 3]), new CultureInfo("en-US")));
                    }
                    if (!((string)lines[i + 4]).Equals("None"))
                    {
                        a.setAlt(double.Parse((lines[i + 4]), new CultureInfo("en-US")));
                    }
                    if (!((string)lines[i + 5]).Equals("None") == true)
                    {
                        a.setVelocidad(double.Parse((lines[i + 5]), new CultureInfo("en-US")));
                    }
                    if (!((string)lines[i + 6]).Equals("None"))
                    {
                        a.setHeading(double.Parse((lines[i + 6]), new CultureInfo("en-US")));
                    }
                    if (!((string)lines[i + 7]).Equals("None"))
                    {
                        a.setInclinacion(double.Parse((lines[i + 7]), new CultureInfo("en-US")));
                    }
                    //Si la clave, en este caso el ICAO, es nuevo (lo que significa avión nuevo), añadirlo al final. Si un avión está por debajo de 1000 metros, eliminarlo.  
                    if (!diccionario.ContainsKey(a.getIcao()))
                    {
                        diccionario.Add(a.getIcao(), a);
                    }
                    //Si ya existe la clave, significa que el avión existe, por lo que acutalizamos el valor en esa clave con el nuevo avión. 
                    else
                    {
                        diccionario[a.getIcao()] = a;
                    }
                }
                return diccionario;
            }
            else
            {
                return null;
            }
        }
        
        public static Dictionary<string, AvionUnity> crearAvionesSimulacionDiccionario(string fichero, Dictionary<string, AvionUnity> diccionario) 
        {
            string[] lines = new string[0];
            AvionUnity a;
            double[] ECEF;
            int numAviones = 0;
            lines = new string[0];
            try
            {
                lines = System.IO.File.ReadAllLines(fichero);
            }
            catch (Exception)
            {
                UnityEngine.Debug.LogError("Ha habido problemas al abrir el fichero");
            }
            numAviones = lines.Length - 1;
            for (int i = 0; i < (numAviones); i = i + 8)
            {
                a = new AvionUnity(null, null, Double.Epsilon, Double.Epsilon, Double.Epsilon, Double.Epsilon, Double.Epsilon, Double.Epsilon, 0, 0, 0);
                if (!((string)lines[i + 2]).Equals("None") && !((string)lines[i + 3]).Equals("None") && !((string)lines[i + 4]).Equals("None"))
                {
                    ECEF = ConversorUnity.GeoToECEF(double.Parse((lines[i + 3]), new CultureInfo("en-US")), double.Parse((lines[i + 2]), new CultureInfo("en-US")), double.Parse((lines[i + 4]), new CultureInfo("en-US")));
                    a.setXGlobal(ECEF[0]);
                    a.setYGlobal(ECEF[1]);
                    a.setZGlobal(ECEF[2]);
                }
                if (!((string)lines[i]).Equals("None"))
                {
                    a.setIcao(lines[i]);
                }
                if (!((string)lines[i + 1]).Equals("None"))
                {
                    a.setPais(lines[i + 1]);
                }
                if (!((string)lines[i + 2]).Equals("None"))
                {
                    a.setLong(double.Parse((lines[i + 2]), new CultureInfo("en-US")));
                }
                if (!((string)lines[i + 3]).Equals("None"))
                {
                    a.setLat(double.Parse((lines[i + 3]), new CultureInfo("en-US")));
                }
                if (!((string)lines[i + 4]).Equals("None"))
                {
                    a.setAlt(double.Parse((lines[i + 4]), new CultureInfo("en-US")));
                }
                if (!((string)lines[i + 5]).Equals("None") == true)
                {
                    a.setVelocidad(double.Parse((lines[i + 5]), new CultureInfo("en-US")));
                }
                if (!((string)lines[i + 6]).Equals("None"))
                {
                    a.setHeading(double.Parse((lines[i + 6]), new CultureInfo("en-US")));
                }
                if (!((string)lines[i + 7]).Equals("None"))
                {
                    a.setInclinacion(double.Parse((lines[i + 7]), new CultureInfo("en-US")));
                }
                //Si la clave, en este caso el ICAO, es nuevo (lo que significa avión nuevo), añadirlo al final. Si un avión está por debajo de 1000 metros, eliminarlo.  
                if (!diccionario.ContainsKey(a.getIcao()))
                {
                    diccionario.Add(a.getIcao(), a);
                }
                //Si ya existe la clave, significa que el avión existe, por lo que acutalizamos el valor en esa clave con el nuevo avión. 
                else 
                {
                    diccionario[a.getIcao()] = a;
                }
            }
            return diccionario;
        }



    }
}
