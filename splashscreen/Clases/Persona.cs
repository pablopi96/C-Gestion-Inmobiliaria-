using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObligatorioInmobiliaria2014MMP
{
    class Persona : IPersona
    {
        private string Apellido;

        public string Apellido1
        {
            get { return Apellido; }
            set { Apellido = value; }
        }
        private int Cel;

        public int Cel1
        {
            get { return Cel; }
            set { Cel = value; }
        }

        int Tel;
        public int Tel1
        {
            get { return Tel; }
            set { Tel = value; }
        }

        private string CI;

        public string CI1
        {
            get { return CI; }
            set { CI = value; }
        }

        private bool isPropietario;
        public bool IsPropietario
        {
            get { return isPropietario; }
            set { isPropietario = value; }
        }

        private bool isInquilino;
        public bool IsInquilino
        {
            get { return isInquilino; }
            set { isInquilino = value; }
        }

        private bool isComprador;
        public bool IsComprador
        {
            get { return isComprador; }
            set { isComprador = value; }
        }

        private bool isSuscriptor;
        public bool IsSuscriptor
        {
            get { return isSuscriptor; }
            set { isSuscriptor = value; }
        }
        
        private string Dirección;

        public string Direccion1
        {
            get { return Dirección; }
            set { Dirección = value; }
        }
        private string Email;

        public string Email1
        {
            get { return Email; }
            set { Email = value; }
        }
        private string Nombre;

        public string Nombre1
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        int idPersona;
        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        int n = 0;

        public void AsignarID()
        {
            foreach (Persona i in Contenedor.ArrayPersonas)
            {
                if (i.idPersona > n)
                    n = i.idPersona;
            }
        }

        public Persona(string xApellido, int xCel, int xTel, string xCI, bool xComprador, bool xPropietario, bool xInquilino, bool xSuscriptor, string xDirección, string xEmail, string xNombre)
        {
            AsignarID();
            this.idPersona = n+1;
            this.Apellido = xApellido;
            this.Cel = xCel;
            this.CI = xCI;
            this.Tel = xTel;
            this.isComprador = xComprador;
            this.isPropietario = xPropietario;
            this.isInquilino = xInquilino;
            this.isSuscriptor = xSuscriptor;
            this.Dirección = xDirección;
            this.Email = xEmail;
            this.Nombre = xNombre;
        }
        public Persona(int id, string xApellido, int xCel, int xTel, string xCI, bool xComprador, bool xPropietario, bool xInquilino, bool xSuscriptor, string xDirección, string xEmail, string xNombre)
        {
            this.idPersona = id;
            this.Apellido = xApellido;
            this.Cel = xCel;
            this.CI = xCI;
            this.Tel = xTel;
            this.isComprador = xComprador;
            this.isPropietario = xPropietario;
            this.isInquilino = xInquilino;
            this.isSuscriptor = xSuscriptor;
            this.Dirección = xDirección;
            this.Email = xEmail;
            this.Nombre = xNombre;
        }

        public override string ToString()
        {
            return idPersona.ToString() + ";" + Apellido + ";" + Cel.ToString() + ";" + Tel.ToString() + ";" + CI + ";" + isComprador.ToString() + ";" + isPropietario.ToString() + ";" + isInquilino.ToString() + ";" + isSuscriptor.ToString() + ";" + Dirección + ";" + Email + ";" + Nombre;
        }
    }
}
