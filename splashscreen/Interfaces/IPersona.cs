using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioInmobiliaria2014MMP
{
    interface IPersona
    {
        bool IsComprador
        {
            get;
            set;
        }

        string Nombre1
        {
            get;
            set;
        }

        string Email1
        {
            get;
            set;
        }

        string Direccion1
        {
            get;
            set;
        }

        string CI1
        {
            get;
            set;
        }

        int Cel1
        {
            get;
            set;
        }

        string Apellido1
        {
            get;
            set;
        }

        string ToString();
    }
}
