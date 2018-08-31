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
    /// Lógica de interacción para FrmVender.xaml
    /// </summary>
    public partial class FrmVender : Window
    {
        public FrmVender()
        {
            InitializeComponent();
            
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void DtgSeleccionarCliente_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtCliente.Text = DtgSeleccionarCliente.CurrentCell.Item.ToString();
        }

        private void DtgSeleccionarInmueble_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtInmueble.Text = DtgSeleccionarCasa.CurrentCell.Item.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contenedor.ArrayVentas.Add(new Transaccion(Convert.ToInt32(TxtCliente.Text[0].ToString()), Convert.ToInt32(TxtInmueble.Text[0].ToString()), "Vendido"));

                foreach (Persona i in Contenedor.ArrayPersonas)
                {
                    if (i.ToString() == TxtCliente.Text)
                        i.IsPropietario = true;
                }
                foreach (Casa i in Contenedor.ArrayCasas)
                {
                    if (i.ToString() == TxtInmueble.Text)
                        i.Disponibilidad = false;
                }
                foreach (Apartamento i in Contenedor.ArrayApartamentos)
                {
                    if (i.ToString() == TxtInmueble.Text)
                        i.Disponibilidad = false;
                }


                try
                {
                    File.Exists("Ventas.txt");
                    File.Delete("Ventas.txt");
                }
                finally { AdministradorArchivos.EscribirVentas(@".\Ventas.txt"); }

                MessageBox.Show("Inmueble " + TxtInmueble.Text[0] + " vendido al Cliente " + TxtCliente.Text[0]);
                TxtCliente.Clear();
                TxtInmueble.Clear();
                DtgSeleccionarCasa.UpdateLayout();
                DtgSeleccionarApto.UpdateLayout();
            }
            catch
            {
                MessageBox.Show("No ha seleccionado los parámetros correctamente");
            }
        }

        private void BtnAlquilar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Contenedor.ArrayAlquileres.Add(new Transaccion(Convert.ToInt32(TxtCliente.Text[0]), Convert.ToInt32(TxtInmueble.Text[0]), "Alquilado"));

                foreach (Persona i in Contenedor.ArrayPersonas)
                {
                    if (i.ToString() == TxtCliente.Text)
                        i.IsInquilino = true;
                }
                foreach (Casa i in Contenedor.ArrayCasas)
                {
                    if (i.ToString() == TxtInmueble.Text)
                        i.Disponibilidad = false;
                }
                foreach (Apartamento i in Contenedor.ArrayApartamentos)
                {
                    if (i.ToString() == TxtInmueble.Text)
                        i.Disponibilidad = false;
                }


                try
                {
                    File.Exists("Alquileres.txt");
                    File.Delete("Alquileres.txt");
                }
                finally { AdministradorArchivos.EscribirAlquileres(@".\Alquileres.txt"); }

                MessageBox.Show("Inmueble " + TxtInmueble.Text[0] + " alquilado al Cliente " + TxtCliente.Text[0]);
                TxtCliente.Clear();
                TxtInmueble.Clear();
                DtgSeleccionarCasa.UpdateLayout();
                DtgSeleccionarApto.UpdateLayout();
            }
            catch
            {
                MessageBox.Show("No ha seleccionado los parámetros correctamente");
            }
        }

        private void TxtInmueble_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtCliente_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtCliente.Clear();
        }

        private void TxtInmueble_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtInmueble.Clear();
        }

        private void FrmVender1_Loaded(object sender, RoutedEventArgs e)
        {            
            DtgSeleccionarCliente.ItemsSource = null;
            DtgSeleccionarCliente.ItemsSource = Contenedor.ArrayPersonas;

            DtgSeleccionarCasa.ItemsSource = null;
            DtgSeleccionarCasa.ItemsSource = Contenedor.ArrayCasas;

            DtgSeleccionarApto.ItemsSource = null;
            DtgSeleccionarApto.ItemsSource = Contenedor.ArrayApartamentos;
        }

        private void DtgSeleccionarCliente_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void DtgSeleccionarCasa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DtgSeleccionarApto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DtgSeleccionarApto_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtInmueble.Text = DtgSeleccionarApto.CurrentCell.Item.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frmMenu FrmMenu = new frmMenu();
            this.Close();
            FrmMenu.Show();
        }
    }
}
