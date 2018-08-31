using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioInmobiliaria2014MMP
{
    public abstract class Inmueble : IInmueble
    {
        double precio;
        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        int cantidadDormitorios;
        public int CantidadDormitorios
        {
            get { return cantidadDormitorios; }
            set { cantidadDormitorios = value; }
        }
        int cantidadBaños;
        public int CantidadBaños
        {
            get { return cantidadBaños; }
            set { cantidadBaños = value; }
        }
        int cantidadGarajes;
        public int CantidadGarajes
        {
            get { return cantidadGarajes; }
            set { cantidadGarajes = value; }
        }
        int añoConstruccion;
        public int AñoConstruccion
        {
            get { return añoConstruccion; }
            set { añoConstruccion = value; }
        }
        double metrosEdificados;
        public double MetrosEdificados
        {
            get { return metrosEdificados; }
            set { metrosEdificados = value; }
        }
        string ciudad;
        public string Ciudad
        {
            get { return ciudad; }
            set { ciudad = value; }
        }
        string barrio;
        public string Barrio
        {
            get { return barrio; }
            set { barrio = value; }
        }
        string estado;
        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }
        string ubicación;
        public string Ubicación
        {
            get { return ubicación; }
            set { ubicación = value; }
        }
        string conjuntoFotos; //Un array con strings con las ubicaciones de las fotos.
        public string ConjuntoFotos
        {
            get { return conjuntoFotos; }
            set { conjuntoFotos = value; }
        }

        string comentariosRelevantes;
        public string ComentariosRelevantes
        {
            get { return comentariosRelevantes; }
            set { comentariosRelevantes = value; }
        }

        bool disponibilidad;
        public bool Disponibilidad
        {
            get { return disponibilidad; }
            set { disponibilidad = value; }
        }
        bool alquiler;
        public bool Alquiler
        {
            get { return alquiler; }
            set { alquiler = value; }
        }
        bool venta;
        public bool Venta
        {
            get { return venta; }
            set { venta = value; }
        }

        public Inmueble() { }
        public Inmueble(bool xAlquiler, bool xVenta, double xPrecio, int xCantidadDormitorios, int xCantidadBaños, int xCantidadGarajes, int xAñoConstrucción, double xMetrosEdificados, string xBarrio, string xCiudad, string xEstado, string xUbicación, string xConjuntoFotos, string xComentariosRelevantes, bool xDisponibilidad)
        {
            this.alquiler = xAlquiler;
            this.venta = xVenta;
            this.precio = xPrecio;
            this.cantidadDormitorios = xCantidadDormitorios;
            this.cantidadBaños = xCantidadBaños;
            this.cantidadGarajes = xCantidadGarajes;
            this.añoConstruccion = xAñoConstrucción;
            this.metrosEdificados = xMetrosEdificados;
            this.ciudad = xCiudad;
            this.barrio = xBarrio;
            this.estado = xEstado;
            this.ubicación = xUbicación;
            this.conjuntoFotos = xConjuntoFotos;
            this.comentariosRelevantes = xComentariosRelevantes;
            this.disponibilidad = xDisponibilidad;
        }
    }
}
