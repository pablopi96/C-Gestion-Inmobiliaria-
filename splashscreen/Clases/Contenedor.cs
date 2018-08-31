using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ObligatorioInmobiliaria2014MMP
{
    class Contenedor : IContenedor
    {
        private static ArrayList arrayPersonas = new ArrayList();

        public static ArrayList ArrayPersonas
        {
            get { return Contenedor.arrayPersonas; }
            set { Contenedor.arrayPersonas = value; }
        }

        private static ArrayList arrayCasas = new ArrayList();

        public static ArrayList ArrayCasas
        {
            get { return Contenedor.arrayCasas; }
            set { Contenedor.arrayCasas = value; }
        }

        private static ArrayList arrayApartamentos = new ArrayList();

        public static ArrayList ArrayApartamentos
        {
            get { return Contenedor.arrayApartamentos; }
            set { Contenedor.arrayApartamentos = value; }
        }

        private static ArrayList arrayVisitas = new ArrayList();

        public static ArrayList ArrayVisitas
        {
            get { return Contenedor.arrayVisitas; }
            set { Contenedor.arrayVisitas = value; }
        }

        private static ArrayList arrayVentas = new ArrayList();
        public static ArrayList ArrayVentas
        {
            get { return Contenedor.arrayVentas; }
            set { Contenedor.arrayVentas = value; }
        }

        private static ArrayList arrayAlquileres = new ArrayList();
        public static ArrayList ArrayAlquileres
        {
            get { return Contenedor.arrayAlquileres; }
            set { Contenedor.arrayAlquileres = value; }
        }      


    }
}
