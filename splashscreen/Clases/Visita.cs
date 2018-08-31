using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioInmobiliaria2014MMP
{
    class Visita : IVisita
    {
        private string Comentarios;

        public string Comentarios1
        {
            get { return Comentarios; }
            set { Comentarios = value; }
        }
        private string Fecha;

        public string Fecha1
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        private int IdComprador;

        public int IdComprador1
        {
            get { return IdComprador; }
            set { IdComprador = value; }
        }
        private int IdInmueble;

        public int IdInmueble1
        {
            get { return IdInmueble; }
            set { IdInmueble = value; }
        }

        public Visita(string xComentarios, string xFecha, int xIdComprador, int xIdInmueble)
        {
            this.Comentarios = xComentarios;
            this.Fecha = xFecha;
            this.IdComprador = xIdComprador;
            this.IdInmueble = xIdInmueble;
        }

        public override string ToString()
        {
            return "|Visita| " + "; Fecha: " + Fecha + "; ID Cliente: " + IdComprador + "; ID Inmueble: " + IdInmueble + "; Comentarios: " + Comentarios + "\n";
        }
    }
}
