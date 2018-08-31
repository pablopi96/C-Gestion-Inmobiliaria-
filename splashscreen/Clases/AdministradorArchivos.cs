using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace ObligatorioInmobiliaria2014MMP
{
    class AdministradorArchivos
    {
        public static void EscribirString(String nomArchivo, String texto)
        {
            StreamWriter writer = new StreamWriter(nomArchivo, true);
            writer.WriteLine(texto);
            writer.Close();
        }

        public static void EscribirClientes(String nomArchivo)
        {
            StreamWriter writer = new StreamWriter(nomArchivo, true);
            foreach (IPersona i in Contenedor.ArrayPersonas)
            {
                writer.WriteLine(i.ToString());
            }
            writer.Close();
        }
        public static void EscribirVisitas(String nomArchivo)
        {
            StreamWriter writer = new StreamWriter(nomArchivo, true);
            foreach (IVisita i in Contenedor.ArrayVisitas)
            {
                writer.WriteLine(i.ToString());
            }
            writer.Close();
        }

        public static void EscribirCasas(String nomArchivo)
        {
            StreamWriter writer = new StreamWriter(nomArchivo, true);
            foreach (Casa i in Contenedor.ArrayCasas)
            {
                writer.WriteLine(i.ToString());
            }
            writer.Close();
        }

        public static void EscribirApartamentos(String nomArchivo)
        {
            StreamWriter writer = new StreamWriter(nomArchivo, true);
            foreach (Apartamento i in Contenedor.ArrayApartamentos)
            {
                writer.WriteLine(i.ToString());
            }
            writer.Close();
        }
        public static void EscribirVentas(String nomArchivo)
        {
            StreamWriter writer = new StreamWriter(nomArchivo, true);
            foreach (Transaccion i in Contenedor.ArrayVentas)
            {
                writer.WriteLine(i.ToString());
            }
            writer.Close();
        }

        public static void EscribirAlquileres(String nomArchivo)
        {
            StreamWriter writer = new StreamWriter(nomArchivo, true);
            foreach (Transaccion i in Contenedor.ArrayAlquileres)
            {
                writer.WriteLine(i.ToString());
            }
            writer.Close();
        }

        public static ArrayList Leer(String nomArchivo)
        {
            StreamReader reader = new StreamReader(nomArchivo);
            ArrayList salida = new ArrayList();
            while (reader.Peek() > -1)
            {
                salida.Add(reader.ReadLine());
            }
            reader.Close();
            return salida;
        }

        public static ArrayList SepararCadenas(char separador, ArrayList Origen)
        {
            ArrayList retorno = new ArrayList();
            foreach (string linea in Origen)
            {
                string[] nuevaLinea = linea.Split(separador);
                retorno.Add(nuevaLinea);
            }
            return retorno;
        }

      /*  public static ArrayList SepararCadenas(char separador, string Cadena)
        {
            ArrayList retorno = new ArrayList();
            foreach (string linea in Origen)
            {
                string[] nuevaLinea = linea.Split(separador);
                retorno.Add(nuevaLinea);
            }
            return retorno;
        } */

        public static ArrayList ArrayListToString(string separador, ArrayList Origen)
        {
            ArrayList retorno = new ArrayList();
            foreach (string[] linea in Origen)
            {
                string nuevaLinea = string.Join(separador, linea);
                retorno.Add(nuevaLinea);
            }
            return retorno;
        }

        public static void CopiarArchivo()
        {
            throw new System.NotImplementedException();
        }
    }
}
