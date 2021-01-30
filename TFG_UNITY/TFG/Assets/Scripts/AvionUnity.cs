using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace AvionesGeneral
{
    public class AvionUnity
    {
        private String icao;
        private String pais;
        private double longitud;
        private double latitud;
        private double altitud;
        private double velocidad;
        private double heading;
        private double inclinacion;
        private double xGlobal;
        private double yGlobal;
        private double zGlobal;

        public AvionUnity(String icao, String pais, double longitud, double latitud, double altitud, double velocidad, double heading, double inclinacion, double xGlobal, double yGlobal, double zGlobal)
        {
            this.icao = icao;
            this.pais = pais;
            this.longitud = longitud;
            this.latitud = latitud;
            this.altitud = altitud;
            this.velocidad = velocidad;
            this.heading = heading;
            this.inclinacion = inclinacion;
            this.xGlobal = xGlobal;
            this.yGlobal = yGlobal;
            this.zGlobal = zGlobal;
        }

        public String getIcao()
        {
            return icao;
        }
        public String getPais()
        {
            return pais;
        }
        public double getLong()
        {
            return longitud;
        }
        public double getLat()
        {
            return latitud;
        }
        public double getAlt()
        {
            return altitud;
        }
        public double getVelocidad()
        {
            return velocidad;
        }
        public double getHeading()
        {
            return heading;
        }
        public double getInlinacion()
        {
            return inclinacion;
        }
        public double getXGlobal()
        {
            return xGlobal;
        }
        public double getYGlobal()
        {
            return yGlobal;
        }
        public double getZGlobal()
        {
            return zGlobal;
        }
        public void setIcao(String icao)
        {
            this.icao = icao;
        }
        public void setPais(String pais)
        {
            this.pais = pais;
        }
        public void setLong(double longitud)
        {
            this.longitud = longitud;
        }
        public void setLat(double latitud)
        {
            this.latitud = latitud;
        }
        public void setAlt(double altitud)
        {
            this.altitud = altitud;
        }
        public void setVelocidad(double velocidad)
        {
            this.velocidad = velocidad;
        }
        public void setHeading(double heading)
        {
            this.heading = heading;
        }
        public void setInclinacion(double inclinacion)
        {
            this.inclinacion = inclinacion;
        }
        public void setXGlobal(double xGlobal)
        {
            this.xGlobal = xGlobal;
        }
        public void setYGlobal(double yGlobal)
        {
            this.yGlobal = yGlobal;
        }
        public void setZGlobal(double zGlobal)
        {
            this.zGlobal = zGlobal;
        }
    }
}

