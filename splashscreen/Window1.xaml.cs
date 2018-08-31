using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.IO;

namespace ObligatorioInmobiliaria2014MMP
{
	/// <summary>
	/// Lógica de interacción para Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
        private int time = 3;
        private DispatcherTimer Timer;

        MainWindow ProgressBarr = new MainWindow();
            
        
		public Window1()
		{
			this.InitializeComponent();
            Timer = new DispatcherTimer();
			Timer.Interval = new TimeSpan(0,0,1);
            Timer.Tick += timer_tick;
            Timer.Start();
            
          //  time.Tick += new EventHandler(time_tick);
            // A partir de este punto se requiere la inserción de código para la creación del objeto.
        }
		
		private void timer_tick(object sender, EventArgs e)
		{
            if (time > 0)
            {
                time--;
            }
            else
            {
                Window.Close();
                frmMenu FrmMenu = new frmMenu();
                ProgressBarr.Close();
                FrmMenu.Show();

               

                
                
                Timer.Stop();
            }
		}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ProgressBarr.Show();
           /* MainWindow ProgressBarr = new MainWindow();
            ProgressBarr.Show(); */
        }

        private void Rectangle_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists("Clientes.txt") == true)
            {
                foreach (String i in AdministradorArchivos.Leer("Clientes.txt"))
                {
                    char b = ';';
                    string[] a = i.Split(b);
                    Contenedor.ArrayPersonas.Add(new Persona(Convert.ToInt32(a[0]), a[1], Convert.ToInt32(a[2]), Convert.ToInt32(a[3]), a[4], Convert.ToBoolean(a[5]), Convert.ToBoolean(a[6]), Convert.ToBoolean(a[7]), Convert.ToBoolean(a[8]), a[9], a[10], a[11]));
                }
            }

            if (File.Exists("Casas.txt") == true)
            {
                foreach (String i in AdministradorArchivos.Leer("Casas.txt"))
                {
                    char b = ';';
                    string[] a = i.Split(b);
                    Contenedor.ArrayCasas.Add(new Casa(Convert.ToInt32(a[0]), Convert.ToBoolean(a[1]), Convert.ToBoolean(a[2]), Convert.ToDouble(a[3]), Convert.ToInt32(a[4]), Convert.ToInt32(a[5]), Convert.ToInt32(a[6]), Convert.ToInt32(a[7]), Convert.ToDouble(a[8]), a[9], a[10], a[11], a[12], a[13], a[14], Convert.ToBoolean(a[15]), Convert.ToInt32(a[16]), Convert.ToBoolean(a[17]), Convert.ToBoolean(a[18]), Convert.ToBoolean(a[19])));

                }
            }
            if (File.Exists("Apartamentos.txt") == true)
            {
                foreach (String i in AdministradorArchivos.Leer("Apartamentos.txt"))
                {
                    char b = ';';
                    string[] a = i.Split(b);
                    Contenedor.ArrayApartamentos.Add(new Apartamento(Convert.ToInt32(a[0]), Convert.ToBoolean(a[1]), Convert.ToBoolean(a[2]), Convert.ToDouble(a[3]), Convert.ToInt32(a[4]), Convert.ToInt32(a[5]), Convert.ToInt32(a[6]), Convert.ToInt32(a[7]), Convert.ToDouble(a[8]), a[9], a[10], a[11], a[12], a[13], a[14], Convert.ToBoolean(a[15]), Convert.ToInt32(a[16]), Convert.ToBoolean(a[17]), a[18], Convert.ToBoolean(a[19]), Convert.ToBoolean(a[20])));

                }
            }
        }
		
		
		//Timer_______________________
		
		/* 
		DisptcherTimer timer = new DisptcherTimer();

public MainWindow()
{
InitializeComponent();
timer.Tick += new EventHandler(time_tick);
timer.Interval = new TimeSpan(0,0,1);
}

int zahl = 0;


private void timer_tick(objet sender, EventArgs e)
{
zahl++;
label1.Content = zahl.ToString();
}

timer.Start();
		*/
		
		
		
		
	}
}