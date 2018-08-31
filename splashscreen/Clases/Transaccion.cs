using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioInmobiliaria2014MMP
{
    public class Transaccion
    {
        int idCliente;
        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }
        int idInmueble;
        public int IdInmueble
        {
            get { return idInmueble; }
            set { idInmueble = value; }
        }
        string tipoTransaccion;
        public string TipoTransaccion
        {
            get { return tipoTransaccion; }
            set { tipoTransaccion = value; }
        }

        public Transaccion(int xIDCliente, int xIDInmueble, string xTipoTransacción)
        {
            this.idCliente = xIDCliente;
            this.idInmueble = xIDInmueble;
            this.tipoTransaccion = xTipoTransacción;
        }

        public override string ToString()
        {
            return "ID Cliente: " + idCliente.ToString() + " | " + "ID Inmueble: " + idInmueble.ToString() + " | " + "Tipo de transacción: " + tipoTransaccion;
        }
    }
}
