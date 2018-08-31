using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioInmobiliaria2014MMP
{
    interface IInmueble
    {
        double Precio { get; set; }
        int CantidadDormitorios { get; set; }
        int CantidadBaños { get; set; }
        int CantidadGarajes { get; set; }
        int AñoConstruccion { get; set; }
        double MetrosEdificados { get; set; }
        string Ciudad { get; set; }
        string Barrio { get; set; }
        string Estado { get; set; } //a estrenar, usado, etc.
        string Ubicación { get; set; }
        string ConjuntoFotos { get; set; } //Array con las ubicaciones de las fotos
        string ComentariosRelevantes { get; set; }
        bool Disponibilidad { get; set; }
    }
}
