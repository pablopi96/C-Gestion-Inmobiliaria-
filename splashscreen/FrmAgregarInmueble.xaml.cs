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
using System.Windows.Forms;
using System.IO;

namespace ObligatorioInmobiliaria2014MMP
{
    /// <summary>
    /// Lógica de interacción para FrmAgregarInmueble.xaml
    /// </summary>
    public partial class FrmAgregarInmueble : Window
    {
        private String RutaImagenes; //RutaImagenes contendrá la ruta de la carpeta donde están las fotos del inmueble

        public FrmAgregarInmueble()
        {
            InitializeComponent();
        }

        //BOTÓN AGREGAR FOTOS
        /**Al presionar el botón Agregar Fotos se selecciona una carpeta (donde estarán las fotos del inmueble)
         * y esa ruta la asigna a RutaImagenes que se declaró arriba*/

        private void BtnAgregarFotos_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog AbrirFotos = new FolderBrowserDialog();
            if (AbrirFotos.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RutaImagenes = (AbrirFotos.SelectedPath);
            }
        }

    //Método para copiar los archivos de una carpeta a otra
        public void CopiarDirectorio(DirectoryInfo Origen, DirectoryInfo Destino)
        {
            if (!Destino.Exists)
                Destino.Create();

            FileInfo[] Archivos = Origen.GetFiles();

            foreach (FileInfo arc in Archivos)
            {
                arc.CopyTo(System.IO.Path.Combine(Destino.FullName, arc.Name));
            }

            //Subcarpetas

            DirectoryInfo[] dirs = Origen.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                string destinoDir = System.IO.Path.Combine(Destino.FullName, dir.Name);
                // Llamada Recursiva
                CopiarDirectorio(dir, new DirectoryInfo(destinoDir));
            }
        }

        //BOTÓN AGREGAR INMUEBLE..........
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            { //Creación de una casa o un apartamento (Según el RadioButton)
                if (RBtnCasa.IsChecked == false && RBtnApartamento.IsChecked == false)
                    System.Windows.Forms.MessageBox.Show("No está seleccionado ni casa ni apartamento");

                else
                {
                    //Si es una casa:
                    if (RBtnCasa.IsChecked == true)
                    {
                        Casa casa=new Casa(Convert.ToBoolean(ChBxAlquiler.IsChecked), Convert.ToBoolean(ChBxVenta.IsChecked),
                        Convert.ToDouble(TxtPrecio.Text), Convert.ToInt32(TxtNDormitorios.Text), Convert.ToInt32(TxtNBanios.Text),
                        Convert.ToInt32(TxtNGarajes.Text), Convert.ToInt32(TxtAnioConstruccion.Text),
                        Convert.ToDouble(TxtMetrosEdificados.Text), TxtBarrio.Text, TxtCiudad.Text,
                        CmBxEstado.Text, TxtDireccion.Text, RutaImagenes, TxtComentarios.Text, Convert.ToBoolean(ChBxDisponibilidad.IsChecked),
                        Convert.ToInt32(TxtNPlantas.Text), Convert.ToBoolean(ChBxJardin.IsChecked), Convert.ToBoolean(ChBxParrillero.IsChecked),
                        Convert.ToBoolean(ChBxPatio.IsChecked));
                        
                        //Instancia una casa y la agrega al Array de Casas
                        Contenedor.ArrayCasas.Add(casa);

                        //Luego crea una carpeta con todas las fotos de la casa, si se agregaron.

                        //Comprueba la ruta de las imágenes:
                        if (RutaImagenes != "" && RutaImagenes != null)
                        {                           
                            DirectoryInfo RutaImagenesCasa=new DirectoryInfo(RutaImagenes); //Crea un DirectoryInfo con la ruta de la carpeta con imágenes del inmueble
                            string[] archivosImagenesCasa = Directory.GetFiles(RutaImagenes); //Toma la ruta de los archivos y los pone en un Array
                            //Se define la nueva carpeta que tendrá las imágenes del inmueble
                            DirectoryInfo DirectorioCasa = new DirectoryInfo(System.IO.Path.Combine(@".\" + "Casa " + casa.IdInmueble.ToString()));

                            //Copia todos los archivos de la carpeta seleccionada a la nueva carpeta del inmueble
                            CopiarDirectorio(RutaImagenesCasa, DirectorioCasa);
                        }

                        //Si no se selecciona ninguna carpeta con el botón Agregar Fotos
                        else
                        {
                            // Crea la carpeta del inmueble pero vacía
                            DirectoryInfo Directorio = new DirectoryInfo(System.IO.Path.Combine(@".\" + "Casa " + casa.IdInmueble.ToString()));
                            
                            Directory.CreateDirectory(Directorio.ToString());

                            RutaImagenes = Directorio.FullName.ToString();
                            
                            casa.ConjuntoFotos = RutaImagenes;
                        }
                        
                    }
                    else if (RBtnApartamento.IsChecked == true)
                    {
                        //Al crear un apartamento el procedimiento es el mismo que se utilizó para Casa

                        Apartamento apto = new Apartamento(Convert.ToBoolean(ChBxAlquiler.IsChecked), Convert.ToBoolean(ChBxVenta.IsChecked),
                        Convert.ToDouble(TxtPrecio.Text), Convert.ToInt32(TxtNDormitorios.Text), Convert.ToInt32(TxtNBanios.Text),
                        Convert.ToInt32(TxtNGarajes.Text), Convert.ToInt32(TxtAnioConstruccion.Text),
                        Convert.ToDouble(TxtMetrosEdificados.Text), TxtBarrio.Text, TxtCiudad.Text,
                        CmBxEstado.Text, TxtDireccion.Text, RutaImagenes, TxtComentarios.Text, Convert.ToBoolean(ChBxDisponibilidad.IsChecked), Convert.ToInt32(TxtPiso.Text),
                        Convert.ToBoolean(ChBxPorteria.IsChecked), TxtGastosComunes.Text, Convert.ToBoolean(ChBxJardin.IsChecked), Convert.ToBoolean(ChBxParrillero.IsChecked));
                        
                        Contenedor.ArrayApartamentos.Add(apto);

                        if (RutaImagenes != "" && RutaImagenes != null)
                        {
                            DirectoryInfo RutaImagenesApto = new DirectoryInfo(RutaImagenes);
                            string[] archivosImagenesApto = Directory.GetFiles(RutaImagenes);

                            DirectoryInfo DirectorioCasa = new DirectoryInfo(System.IO.Path.Combine(@".\" + "Apto " + apto.IdInmueble.ToString()));

                            CopiarDirectorio(RutaImagenesApto, DirectorioCasa);
                        }
                        else
                        {

                            DirectoryInfo Directorio = new DirectoryInfo(System.IO.Path.Combine(@".\" + "Apto " + apto.IdInmueble.ToString()));

                            Directory.CreateDirectory(Directorio.ToString());

                            RutaImagenes = Directorio.FullName.ToString();

                            apto.ConjuntoFotos = RutaImagenes;
                        }
                    }

                    //Luego de agregar el nuevo inmueble y demás, limpia los campos para un nuevo ingreso

                    TxtBarrio.Clear();
                    TxtCiudad.Clear();
                    TxtAnioConstruccion.Clear();
                    TxtComentarios.Clear();
                    TxtDireccion.Clear();
                    TxtGastosComunes.Clear();
                    TxtMetrosEdificados.Clear();
                    TxtNBanios.Clear();
                    TxtNDormitorios.Clear();
                    TxtNGarajes.Clear();
                    TxtNPlantas.Clear();
                    TxtPiso.Clear();
                    TxtPrecio.Clear();
                    ChBxAlquiler.IsChecked = false;
                    ChBxDisponibilidad.IsChecked = false;
                    ChBxJardin.IsChecked = false;
                    ChBxParrillero.IsChecked = false;
                    ChBxPatio.IsChecked = false;
                    ChBxPorteria.IsChecked = false;
                    ChBxVenta.IsChecked = false;
                    RBtnApartamento.IsChecked = false;
                    RBtnCasa.IsChecked = false;
                    RutaImagenes = "";
                   

                    System.Windows.Forms.MessageBox.Show("Agregado/Actualizado exitosamente");

                    //Muestra cuántos inmuebles existe hasta el momento
                    System.Windows.Forms.MessageBox.Show("Casas: "+Contenedor.ArrayCasas.Count.ToString());
                    System.Windows.Forms.MessageBox.Show("Aptos: " + Contenedor.ArrayApartamentos.Count.ToString());

                    try
                    { //Graba los archivos
                        File.Exists("Casas.txt");
                        File.Delete("Casas.txt");
                        File.Exists("Apartamentos.txt");
                        File.Delete("Apartamentos.txt");
                    }
                    finally { 
                        AdministradorArchivos.EscribirCasas(@".\Casas.txt");
                        AdministradorArchivos.EscribirApartamentos(@".\Apartamentos.txt");
                    }
                }
                
            }
            catch { System.Windows.Forms.MessageBox.Show("Verifique los datos. Alguno no se ingresó correctamente"); }
            
        }


        private void RBtnApartamento_Checked(object sender, RoutedEventArgs e)
        {
            if (this.IsActive)
            {
                ChBxPatio.IsEnabled = false;
                TxtPiso.IsEnabled = true;
                ChBxPorteria.IsEnabled = true;
                TxtGastosComunes.IsEnabled = true;
                TxtPiso.IsEnabled = true;

            }
        }

        private void RBtnCasa_Checked(object sender, RoutedEventArgs e)
        {
            if (this.IsActive)
            {
                ChBxPorteria.IsEnabled = false;
                TxtPiso.IsEnabled = false;
                ChBxPatio.IsEnabled = true;
                TxtGastosComunes.IsEnabled = false;
                TxtPiso.IsEnabled = false;
            }
        }

        private void ChBxDisponibilidad_Click(object sender, RoutedEventArgs e)
        {
            if (ChBxDisponibilidad.IsChecked == true) { ChBxDisponibilidad.Content = "DISPONIBLE"; }
            else { ChBxDisponibilidad.Content = "NO DISPONIBLE"; }
        }

        //BOTÓN BUSCAR INMUEBLES
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrmBuscadorInmuebles buscadorinmuebles = new FrmBuscadorInmuebles();
            this.Close();
            buscadorinmuebles.Show();
        }


        //BOTÓN CANCELAR
        private void BtnCancelar_Click_1(object sender, RoutedEventArgs e)
        {
            frmMenu frmmenu = new frmMenu();
            this.Close();
            frmmenu.Show();
        }

        //BOTÓN ATRÁS

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            frmMenu FrmMenu = new frmMenu();
            this.Close();
            FrmMenu.Show();
        }

        private void ChBxPorteria_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
