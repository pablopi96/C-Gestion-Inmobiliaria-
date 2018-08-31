using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioInmobiliaria2014MMP
{
    interface IFábricadeObjetos
    {
        IPersona getPersona(string xApellido, int xCel, string xCI, bool xComprador, string xDirección, string xEmail, string xNombre); //Puede ser Propietario o Comprador. 

        IInmueble getInmueble(double xPrecio, int xCantidadDormitorios, int xCantidadBaños, int xCantidadGarajes, int xAñoConstrucción, double xMetrosEdificados, string xBarrio, string xCiudad, string xEstado, string xUbicación, string[] xConjuntoFotos, string xComentariosRelevantes, int xIdInmueble, bool xDisponibilidad, int xCantidadDePlantas, bool xJardín, bool xParrillero, bool xPatio); //Casa.

        IInmueble getInmueble(double xPrecio, int xCantidadDormitorios, int xCantidadBaños, int xCantidadGarajes, int xAñoConstrucción, double xMetrosEdificados, string xBarrio, string xCiudad, string xEstado, string xUbicación, string[] xConjuntoFotos, string xComentariosRelevantes, int xIdInmueble, bool xDisponibilidad, int xNumPiso, bool xPortería, string xGastosComunes, bool xJardín, bool xParrillero);  //Apartamento
        IVisita getVisita(string xComentarios, string xFecha, int xIdComprador, int xIdInmueble);
    }
}
