using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace ObligatorioInmobiliaria2014MMP
{
    /// <summary>
    /// Lógica de interacción para FrmCliente.xaml
    /// </summary>
    public partial class FrmAgregarCliente : Window
    {
        public FrmAgregarCliente()
        {
            InitializeComponent();
        }

        //Método para verificar la CI
        public bool VerificarCedulaIdentidad(string CI)
        {
            int CIdentidad;
            if (int.TryParse(CI, out CIdentidad) == true)
            {
                if (CIdentidad.ToString().Count() == 8)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }

        //BOTÓN AGREGAR CLIENTE
        private void BtnAgregarCliente_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Pone valores por defecto a los datos no obligatorios

                if (TxtTelefono.Text == "")
                    TxtTelefono.Text = "0";
                if (TxtCelular.Text == "")
                    TxtCelular.Text = "0";
                if (TxtDireccion.Text == "")
                    TxtDireccion.Text = "No ingresado";
                if (ChkSuscriptor.IsChecked == true)
                {
                    if (TxtEmail.Text == "")
                        throw new EntryPointNotFoundException();
                }
                if (ChkSuscriptor.IsChecked == false)
                {
                    if (TxtEmail.Text == "")
                        TxtEmail.Text = "No ingresado";
                }
                 
                //Verifica si los valores obligatorios no son vacíos
                if(TxtNombre.Text=="" || TxtApellido.Text=="" || TxtCedula.Text=="")
                    throw new FormatException(); //si alguno lo es lanza una excepcion
                else if (ChkComprador.IsChecked == false && ChkInquilino.IsChecked == false && ChkPropietario.IsChecked == false && ChkSuscriptor.IsChecked == false)
                    throw new FormatException();
                
                //Verifica la CI
                else if (VerificarCedulaIdentidad(TxtCedula.Text) == false)
                    throw new InvalidDataException();

                //Si está todo correcto instancia una persona con los datos
                Contenedor.ArrayPersonas.Add(FábricaDeObjetos.getPersona(TxtApellido.Text, Convert.ToInt32(TxtCelular.Text), Convert.ToInt32(TxtTelefono.Text), 
                    TxtCedula.Text, Convert.ToBoolean(ChkComprador.IsChecked), Convert.ToBoolean(ChkPropietario.IsChecked), 
                    Convert.ToBoolean(ChkInquilino.IsChecked), Convert.ToBoolean(ChkSuscriptor.IsChecked), TxtDireccion.Text, TxtEmail.Text, TxtNombre.Text));
                
                //Luego limpia los campos para un nuevo ingreso
                TxtNombre.Text = "";
                TxtApellido.Text = "";
                TxtCedula.Text = "";
                TxtTelefono.Text = "";
                TxtCelular.Text = "";
                TxtDireccion.Text = "";
                TxtEmail.Text = "";
                ChkComprador.IsChecked = false;
                ChkPropietario.IsChecked = false;
                ChkInquilino.IsChecked = false;
                ChkSuscriptor.IsChecked = false;
                
                MessageBox.Show("Cliente guardado exitosamente");
            }
            catch(FormatException)
            {
                MessageBox.Show("Alguno de los datos obligatorios no fue ingresado");
            }
            catch (InvalidDataException)
            {
                MessageBox.Show("Verifique la Cédula. Debe tener un formato como el siguiente: '12345678' (ocho números seguidos)");
            }
            catch (EntryPointNotFoundException)
            {
                MessageBox.Show("Los suscriptores deben tener mail");
            }

            try
            { //Escribe en el archivo
                File.Exists("Clientes.txt");
                File.Delete("Clientes.txt");
            }
            finally { AdministradorArchivos.EscribirClientes(@".\Clientes.txt"); }
        }

         //BOTÓN VENDER
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrmVender frmvender = new FrmVender();
            frmvender.Show();
        }

        private void BtnAgregarInmueble_Click(object sender, RoutedEventArgs e)
        {

        }

        //BOTÓN BUSCAR
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            FrmBuscadorClientes BuscadorClientes = new FrmBuscadorClientes();
            this.Close();
            BuscadorClientes.Show();

        }

        //BOTÓN ATRÁS
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            this.Hide();
            frmMenu.Show();
        }

    }
}
