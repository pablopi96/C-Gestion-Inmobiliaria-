using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioInmobiliaria2014MMP
{
    class Apartamento : Inmueble
    {
        int numPiso;
        public int NumPiso
        {
            get { return numPiso; }
            set { numPiso = value; }
        }
        bool portería;
        public bool Portería
        {
            get { return portería; }
            set { portería = value; }
        }

        private string gastosComunes;
        public string GastosComunes
        {
            get { return gastosComunes; }
            set { gastosComunes = value; }
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

        int idInmueble;
        public int IdInmueble
        {
            get { return idInmueble; }
            set { idInmueble = value; }
        }
        int n = 0;
        public void AsignarID()
        {
            foreach (Apartamento i in Contenedor.ArrayApartamentos)
            {
                if (i.idInmueble > n)
                    n = i.idInmueble;
            }
        }

        public Apartamento(bool xAlquiler, bool xVenta, double xPrecio, int xCantidadDormitorios, int xCantidadBaños, int xCantidadGarajes, int xAñoConstrucción, double xMetrosEdificados, string xBarrio, string xCiudad, string xEstado, string xUbicación, string xConjuntoFotos, string xComentariosRelevantes, bool xDisponibilidad, int xNumPiso, bool xPortería, string xGastosComunes, bool xJardín, bool xParrillero)
            : base(xAlquiler, xVenta, xPrecio, xCantidadDormitorios, xCantidadBaños, xCantidadGarajes, xAñoConstrucción, xMetrosEdificados, xBarrio, xCiudad, xEstado, xUbicación, xConjuntoFotos, xComentariosRelevantes, xDisponibilidad)
        {
            AsignarID();
            this.idInmueble = n + 1;
            this.numPiso = xNumPiso;
            this.portería = xPortería;
            this.gastosComunes = xGastosComunes;
            this.jardín = xJardín;
            this.parrillero = xParrillero;
        }
        public Apartamento(int id, bool xAlquiler, bool xVenta, double xPrecio, int xCantidadDormitorios, int xCantidadBaños, int xCantidadGarajes, int xAñoConstrucción, double xMetrosEdificados, string xBarrio, string xCiudad, string xEstado, string xUbicación, string xConjuntoFotos, string xComentariosRelevantes, bool xDisponibilidad, int xNumPiso, bool xPortería, string xGastosComunes, bool xJardín, bool xParrillero)
            : base(xAlquiler, xVenta, xPrecio, xCantidadDormitorios, xCantidadBaños, xCantidadGarajes, xAñoConstrucción, xMetrosEdificados, xBarrio, xCiudad, xEstado, xUbicación, xConjuntoFotos, xComentariosRelevantes, xDisponibilidad)
        {
            this.idInmueble = id;
            this.numPiso = xNumPiso;
            this.portería = xPortería;
            this.gastosComunes = xGastosComunes;
            this.jardín = xJardín;
            this.parrillero = xParrillero;
        }

        public override string ToString()
        {
            return IdInmueble.ToString() + ";" + Alquiler.ToString() + ";" + Venta.ToString() + ";" + Precio.ToString() + ";" + CantidadDormitorios.ToString() + ";" + CantidadBaños.ToString() + ";" + CantidadGarajes.ToString() + ";" + AñoConstruccion.ToString() + ";" + MetrosEdificados.ToString() + ";" + Barrio + ";" + Ciudad + ";" + Estado + ";" + Ubicación + ";" + ConjuntoFotos + ";" + ComentariosRelevantes + ";" + Disponibilidad.ToString() + ";" + numPiso.ToString() + ";" + portería.ToString() + ";" + gastosComunes.ToString() + ";" + jardín.ToString() + ";" + parrillero.ToString();
        }
    }
}
