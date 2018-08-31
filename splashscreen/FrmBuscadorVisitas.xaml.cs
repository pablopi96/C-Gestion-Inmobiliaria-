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
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace ObligatorioInmobiliaria2014MMP
{
    /// <summary>
    /// Lógica de interacción para FrmBuscadorVisitas.xaml
    /// </summary>
    public partial class FrmBuscadorVisitas : Window
    {
        public FrmBuscadorVisitas()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        ArrayList visitasBusquedas = new ArrayList();
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
         
            visitasBusquedas.Clear();
            DtgVisitas.ItemsSource = null;
            

            foreach (Visita i in Contenedor.ArrayVisitas)
            {
                if (i.Fecha1.ToUpper().Contains(TxtBuscar.Text.ToUpper()))
                {
                    visitasBusquedas.Add(i);
                }
            }

            MessageBox.Show(visitasBusquedas.Count.ToString() + " visitas encontradas");

            DtgVisitas.ItemsSource = null;
            DtgVisitas.ItemsSource = visitasBusquedas;
            TxtBuscar.Clear();
        }

        private void DtgVisitas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DtgVisitas.ItemsSource = null;
            DtgVisitas.ItemsSource = Contenedor.ArrayVisitas;
        }

        private void BtnCargar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "Texto|*.TXT";
            openfiledialog.ShowDialog();
                
        }

        private void TxtBuscar_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            TxtBuscar.Clear();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FrmAgregarVisita AVisita = new FrmAgregarVisita();
            this.Close();
            AVisita.Show();
        }
    }
}
