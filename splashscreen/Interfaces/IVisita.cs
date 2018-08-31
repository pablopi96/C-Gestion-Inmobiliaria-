using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioInmobiliaria2014MMP
{
    interface IVisita
    {
        int IdInmueble1
        {
            get;
            set;
        }

        int IdComprador1
        {
            get;
            set;
        }

        string Comentarios1
        {
            get;
            set;
        }

        string Fecha1
        {
            get;
            set;
        }

        string ToString();
    }
}
