using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioInmobiliaria2014MMP
{
    interface IInmobiliaria
    {
        void Vender(String Hola);

        void Alquilar();

        void IngresarVisita();

        void IngresarInmueble();

        void IngresarPersona();

        void CargarArchivoPersonas();

        void CargarArchivoInmuebles();

        void CargarArchivoVisitas();

        void CargarArchivoPropietarios();

        void getListadoInmuebles();//Filtros: Ciudad, barrio, tipo de inmueble, rango de precios, con garaje.

        void getListadoCompradores();

        void setContenedor(); //Ordenados de forma alfabética por nombre.
    }
}
