using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioInmobiliaria2014MMP
{
    class FábricaDeObjetos
    {
        public static IPersona getPersona(string xApellido, int xCel, int xTel, string xCI, bool xComprador, bool xPropietario, bool xInquilino, bool xSuscriptor, string xDirección, string xEmail, string xNombre)
        {
            Persona xPersona = new Persona(xApellido, xCel, xTel, xCI, xComprador, xPropietario, xInquilino, xSuscriptor, xDirección, xEmail, xNombre);
            return xPersona;
        }

        public static IInmueble getInmueble(bool xAlquiler, bool xVenta, double xPrecio, int xCantidadDormitorios, int xCantidadBaños, int xCantidadGarajes, int xAñoConstrucción, double xMetrosEdificados, string xBarrio, string xCiudad, string xEstado, string xUbicación, string xConjuntoFotos, string xComentariosRelevantes, bool xDisponibilidad, int xCantidadDePlantas, bool xJardín, bool xParrillero, bool xPatio)
        {
            Inmueble xInmueble = new Casa(xAlquiler, xVenta, xPrecio, xCantidadDormitorios, xCantidadBaños, xCantidadGarajes, xAñoConstrucción, xMetrosEdificados, xBarrio, xCiudad, xEstado, xUbicación, xConjuntoFotos, xComentariosRelevantes, xDisponibilidad, xCantidadDePlantas, xJardín, xParrillero, xPatio);
            return xInmueble;
        }

        public static IInmueble getInmueble(bool xAlquiler, bool xVenta, double xPrecio, int xCantidadDormitorios, int xCantidadBaños, int xCantidadGarajes, int xAñoConstrucción, double xMetrosEdificados, string xBarrio, string xCiudad, string xEstado, string xUbicación, string xConjuntoFotos, string xComentariosRelevantes, bool xDisponibilidad, int xNumPiso, bool xPortería, string xGastosComunes, bool xJardín, bool xParrillero)
        {
            Inmueble xInmueble = new Apartamento(xAlquiler, xVenta, xPrecio, xCantidadDormitorios, xCantidadBaños, xCantidadGarajes, xAñoConstrucción, xMetrosEdificados, xBarrio, xCiudad, xEstado, xUbicación, xConjuntoFotos, xComentariosRelevantes, xDisponibilidad, xNumPiso, xPortería, xGastosComunes, xJardín, xParrillero);
            return xInmueble;
        }

        public static IVisita getVisita(string xComentarios, string xFecha, int xIdComprador, int xIdInmueble)
        {
            Visita xVisita = new Visita(xComentarios, xFecha, xIdComprador, xIdInmueble);
            return xVisita;
        }
    }
}
