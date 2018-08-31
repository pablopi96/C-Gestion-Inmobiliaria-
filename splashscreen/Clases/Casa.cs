using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioInmobiliaria2014MMP
{
    class Casa : Inmueble
    {
        int cantidadDePlantas;
        public int CantidadDePlantas
        {
            get { return cantidadDePlantas; }
            set { cantidadDePlantas = value; }
        }
        bool jardín;
        public bool Jardín
        {
            get { return jardín; }
            set { jardín = value; }
        }
        bool parrillero;
        public bool Parrillero
        {
            get { return parrillero; }
            set { parrillero = value; }
        }
        bool patio;
        public bool Patio
        {
            get { return patio; }
            set { patio = value; }
        }

        int idInmueble;
        public int IdInmueble
        {
            get { return idInmueble; }
            set { idInmueble = value; }
        }

        int n = 0;

        public void AsignarID()
        {
            foreach (Casa i in Contenedor.ArrayCasas)
            {
                if (i.idInmueble > n)
                    n = i.idInmueble;
            }
        }
        public Casa() { }
        public Casa(bool xAlquiler, bool xVenta, double xPrecio, int xCantidadDormitorios, int xCantidadBaños, int xCantidadGarajes, int xAñoConstrucción, double xMetrosEdificados, string xBarrio, string xCiudad, string xEstado, string xUbicación, string xConjuntoFotos, string xComentariosRelevantes, bool xDisponibilidad, int xCantidadDePlantas, bool xJardín, bool xParrillero, bool xPatio)
            : base(xAlquiler, xVenta, xPrecio, xCantidadDormitorios, xCantidadBaños, xCantidadGarajes, xAñoConstrucción, xMetrosEdificados, xBarrio, xCiudad, xEstado, xUbicación, xConjuntoFotos, xComentariosRelevantes, xDisponibilidad)
        {
            AsignarID();
            this.idInmueble = n + 1;
            this.cantidadDePlantas = xCantidadDePlantas;
            this.jardín = xJardín;
            this.parrillero = xParrillero;
            this.patio = xPatio;
        }
        public Casa(int id, bool xAlquiler, bool xVenta, double xPrecio, int xCantidadDormitorios, int xCantidadBaños, int xCantidadGarajes, int xAñoConstrucción, double xMetrosEdificados, string xBarrio, string xCiudad, string xEstado, string xUbicación, string xConjuntoFotos, string xComentariosRelevantes, bool xDisponibilidad, int xCantidadDePlantas, bool xJardín, bool xParrillero, bool xPatio)
            : base(xAlquiler, xVenta, xPrecio, xCantidadDormitorios, xCantidadBaños, xCantidadGarajes, xAñoConstrucción, xMetrosEdificados, xBarrio, xCiudad, xEstado, xUbicación, xConjuntoFotos, xComentariosRelevantes, xDisponibilidad)
        {
            this.idInmueble = id;
            this.cantidadDePlantas = xCantidadDePlantas;
            this.jardín = xJardín;
            this.parrillero = xParrillero;
            this.patio = xPatio;
        }
        public override string ToString()
        {
            return IdInmueble.ToString() + ";" + Alquiler.ToString() + ";" + Venta.ToString() + ";" + Precio.ToString() + ";" + CantidadDormitorios.ToString() + ";" + CantidadBaños.ToString() + ";" + CantidadGarajes.ToString() + ";" + AñoConstruccion.ToString() + ";" + MetrosEdificados.ToString() + ";" + Barrio + ";" + Ciudad + ";" + Estado + ";" + Ubicación + ";" + ConjuntoFotos + ";" + ComentariosRelevantes + ";" + Disponibilidad.ToString() + ";" + cantidadDePlantas.ToString() + ";" + jardín.ToString() + ";" + parrillero.ToString() + ";" + patio.ToString();
        }

    }
}
