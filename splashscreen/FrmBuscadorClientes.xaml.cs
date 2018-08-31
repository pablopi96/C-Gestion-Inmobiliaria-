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
using System.Collections;
using System.Windows;
using System.IO;
using Microsoft.Win32;

namespace ObligatorioInmobiliaria2014MMP
{
    /// <summary>
    /// Lógica de interacción para FrmBuscadorClientes.xaml
    /// </summary>
    public partial class FrmBuscadorClientes : Window
    {
        public FrmBuscadorClientes()
        {
            InitializeComponent();
        }

        //BOTÓN BUSCAR POR APELLIDO

        ArrayList personasBusquedas = new ArrayList(); //Array con las personas que se buscan
        private void BtnBuscar_Click_2(object sender, RoutedEventArgs e)
        {
            personasBusquedas.Clear();
            DtgClientes.ItemsSource = null;
        
            /*Recorre el Array de personas y si encuentra alguna 
             * con apellido igual o parecido a lo que escribimos lo agregamos al Array creado*/
            foreach (Persona i in Contenedor.ArrayPersonas)
            {
                if (i.Apellido1.ToUpper().Contains(TxtBuscar.Text.ToUpper()))
                {
                    personasBusquedas.Add(i);
                }
            }
            MessageBox.Show(personasBusquedas.Count.ToString() + " clientes encontrados");

            //Mostramos el Array creado
            DtgClientes.ItemsSource = null;
            DtgClientes.ItemsSource = personasBusquedas;

            TxtBuscar.Clear();

            TxtID.IsEnabled = true;
            BtnBuscarID.IsEnabled = true;
        }

        private void DtgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        //BOTÓN GUARDAR CAMBIOS
        private void BtnCargar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                File.Exists("Clientes.txt");
                File.Delete("Clientes.txt");
            }
            finally { AdministradorArchivos.EscribirClientes(@".\Clientes.txt");
            MessageBox.Show("Cambios guardados exitosamente");
            }
        }

        private void TxtBuscar_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            TxtBuscar.Clear();
            TxtID.IsEnabled = false;
            BtnBuscarID.IsEnabled = false;
        }

        private void Window_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
        }

        private void TxtID_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            TxtID.Clear();
            TxtBuscar.IsEnabled = false;
            BtnBuscar.IsEnabled = false;
        }

        //BOTÓN BUSCAR POR ID
        private void BtnBuscarID_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            int id;

            if (int.TryParse(TxtID.Text, out id) == true)
            {
                personasBusquedas.Clear();
                DtgClientes.ItemsSource = null;
                
                /*Recorre el Array de personas y si encuentra el ID que escribimos
                 agrega la persona*/
                foreach (Persona i in Contenedor.ArrayPersonas)
                {
                    if (i.IdPersona.ToString() == TxtID.Text)
                    {
                        personasBusquedas.Add(i);
                    }
                }
                MessageBox.Show(personasBusquedas.Count.ToString() + " clientes encontrados");

                //Muestra el Array
                DtgClientes.ItemsSource = null;
                DtgClientes.ItemsSource = personasBusquedas;

                TxtID.Clear();

                TxtBuscar.IsEnabled = true;
                BtnBuscar.IsEnabled = true;
            }

            else
                MessageBox.Show("Verificar ID");
        }

        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            FrmAgregarCliente frmAgregarCliente = new FrmAgregarCliente();
            this.Close();
            frmAgregarCliente.Show();
        }
    }
}
