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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using System.Timers;
using System.IO;

namespace ObligatorioInmobiliaria2014MMP
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class frmMenu : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        
        public frmMenu()
        {
            InitializeComponent();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnClientes_Click(object sender, RoutedEventArgs e)
        {
            FrmAgregarCliente cliente = new FrmAgregarCliente();
            this.Close();
            cliente.Show();
        }

        private void LblHora_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Loaded_1(object sender, System.Windows.RoutedEventArgs e)
        {
            
            dispatcherTimer.Start();
        }

        int i = 0;
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            LblHora.Content = DateTime.Now.ToLongTimeString();
            
            // Forcing the CommandManager to raise the RequerySuggested event
            CommandManager.InvalidateRequerySuggested();
        }

        private void TxtblHora_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnInmuebles_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FrmAgregarInmueble inmueble = new FrmAgregarInmueble();
            this.Close();
            inmueble.Show();
        }

        private void btnOperaciones_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FrmVender vender = new FrmVender();
            this.Close();
            vender.Show();

        }

        private void btnVisitas_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FrmAgregarVisita visita = new FrmAgregarVisita();
            this.Close();
            visita.Show();
        }

        //BOTÓN AYUDA
        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {

            System.Diagnostics.Process.Start(@".\Ayuda.chm");
            
        }

    }
}
