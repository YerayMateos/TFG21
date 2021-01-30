using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using Wrld.Space;




using System;

namespace AvionesGeneral
{

    public class ConversorUnity
    {
        private const double a = 6378138; //Radio ecuatorial o semieje mayor de la tierra en metros WGS-84
        private const double f = 1.0/ 298.257223563;
        private const double b = a*(1.0-f); //Radio polar o semieje menor de la tierra en metros
        public static double[] GeoToECEF(double latitud, double longitud, double altitud)
        {

            double[] ECEF = new double[3];
            /*double x, y, z;
            double a2 = Math.Pow(a, 2);
            double b2 = Math.Pow(b, 2);
            double gar = Math.PI / 180.0;
            x = (N(latitud) + altitud) * Math.Cos(gar * latitud) * Math.Cos(gar * longitud);
            y = (N(latitud) + altitud) * Math.Cos(gar * latitud) * Math.Sin(gar * longitud);
            z = ((b2 / a2) * N(latitud) + altitud) * Math.Sin(gar * latitud);
            ECEF[0] = x;
            ECEF[1] = y;
            ECEF[2] = z;*/

            //Console.WriteLine("X= " + x + " Y= " + y + " Z= " + z);
            var ll = LatLongAltitude.FromDegrees(latitud, longitud, altitud);
            ECEF[0] = ll.ToECEF().x;
            ECEF[1] = ll.ToECEF().y;
            ECEF[2] = ll.ToECEF().z;
            return ECEF;
        }

        public static double N(double latitud)
        {
            double a2 = Math.Pow(a, 2);
            double b2 = Math.Pow(b, 2);
            double e2 = 1 - b2 / a2;
            //Para convertir de grados a radianes (gar)
            double gar = Math.PI / 180.0;
            double sinlat = Math.Sin(gar * latitud);
            double d2 = 1.0 - e2 * sinlat * sinlat;
            double d = Math.Sqrt(d2);

            double N = a / d;
            return N;
        }
    }
}
