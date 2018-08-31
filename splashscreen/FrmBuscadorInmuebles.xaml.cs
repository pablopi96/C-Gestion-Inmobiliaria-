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
using System.Collections;
using System.Windows;
using Microsoft.Win32;

namespace ObligatorioInmobiliaria2014MMP
{
    /// <summary>
    /// Lógica de interacción para FrmBuscadorInmuebles.xaml
    /// </summary>
    public partial class FrmBuscadorInmuebles : Window
    {
        public FrmBuscadorInmuebles()
        {
            InitializeComponent();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {

        }

        ArrayList busquedasCasa = new ArrayList();
        ArrayList busquedasApartamento = new ArrayList();
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                busquedasCasa.Clear(); //Limpia el array de los inmuebles que se buscan
                DtgCasas.ItemsSource = null; //Limpia el DataGrid

                busquedasApartamento.Clear(); //Limpia el array de los inmuebles que se buscan
                DtgAptos.ItemsSource = null;

                //AGREGAR AL ARRAYLIST DE BUSQUEDAS

                if (TxtIDPrincipal.Text != "") //Si no está vacía la Caja de Texto compara los IDs
                {
                    int id;
                    if (int.TryParse(TxtIDPrincipal.Text, out id) == true)
                    {

                        foreach (Casa i in Contenedor.ArrayCasas)
                        {
                            if (TxtIDPrincipal.Text == i.IdInmueble.ToString())
                                busquedasCasa.Add(i);
                        }


                        foreach (Apartamento i in Contenedor.ArrayApartamentos)
                        {
                            if (TxtIDPrincipal.Text == i.IdInmueble.ToString())
                                busquedasApartamento.Add(i);
                        }

                        TxtIDPrincipal.Clear();

                    }
                    else
                        MessageBox.Show("Verifique la ID");
                }
            }

            catch
            {
                MessageBox.Show("Verifique los datos");
            }

            MessageBox.Show(busquedasCasa.Count.ToString() + " casas encontradas");
            MessageBox.Show(busquedasCasa.Count.ToString() + " aptos encontrados");

            if (RbtCasas.IsChecked == true)
            {

                DtgCasas.ItemsSource = null;
                DtgCasas.ItemsSource = busquedasCasa;
            }

            else if (RbtAptos.IsChecked == true)
            {
                DtgAptos.ItemsSource = null;
                DtgAptos.ItemsSource = busquedasApartamento;
            }
            TxtIDPrincipal.Clear();
        }

        private void TxtIDPrincipal_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtIDPrincipal_GotFocus(object sender, RoutedEventArgs e)
        {
            TxtIDPrincipal.Clear();

        }

        private void TxtIDPrincipal_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            DtgCasas.ItemsSource = null;
            DtgCasas.ItemsSource = Contenedor.ArrayCasas;

            DtgAptos.ItemsSource = null;
            DtgAptos.ItemsSource = Contenedor.ArrayApartamentos;
        }

        private void RbtCasas_Checked(object sender, System.Windows.RoutedEventArgs e)
        {


        }

        private void RbtAptos_Checked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void RbtCasas_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void RbtAptos_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void btnGuardarCambios_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                File.Exists("Casas.txt");
                File.Delete("Casas.txt");
            }
            finally { AdministradorArchivos.EscribirCasas(@".\Casas.txt"); }

            try
            {
                File.Exists("Apartamentos.txt");
                File.Delete("Apartamentos.txt");
            }
            finally { 
                AdministradorArchivos.EscribirApartamentos(@".\Apartamentos.txt");
                MessageBox.Show("Cambios guardados exitosamente");
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            FrmAgregarInmueble frmAgragarInmueble = new FrmAgregarInmueble();
            this.Close();
            frmAgragarInmueble.Show();

        }

        private int i = 0;
        private String[] ColImagenes;
        private BitmapImage x = new BitmapImage();
        private void BtnFotoSiguiente_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (ColImagenes != null || ColImagenes.Count() != 0)
                {
                    if (i < ColImagenes.Count() - 1)
                    {
                        i += 1;
                        x = new BitmapImage();
                        x.BeginInit();
                        x.UriSource = new Uri(ColImagenes[i]);
                        x.EndInit();
                        ImgFotos.Stretch = Stretch.Uniform;
                        ImgFotos.Source = x;

                    }
                    else
                    {
                        i = 0;
                        x = new BitmapImage();
                        x.BeginInit();
                        x.UriSource = new Uri(ColImagenes[i]);
                        x.EndInit();
                        ImgFotos.Stretch = Stretch.Uniform;
                        ImgFotos.Source = x;
                    }

                }
            }
            catch
            {
                MessageBox.Show("No hay imágenes");
            }
        }

        private void BtnFotoAnterior_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                if (ColImagenes != null || ColImagenes.Count() != 0)
                {


                    if (i > 0)
                    {
                        i -= 1;
                        x = new BitmapImage();
                        x.BeginInit();
                        x.UriSource = new Uri(ColImagenes[i]);
                        x.EndInit();
                        ImgFotos.Stretch = Stretch.Uniform;
                        ImgFotos.Source = x;
                    }
                    else
                    {
                        i = ColImagenes.Count() - 1;

                        x = new BitmapImage();
                        x.BeginInit();
                        x.UriSource = new Uri(ColImagenes[i]);
                        x.EndInit();
                        ImgFotos.Stretch = Stretch.Uniform;
                        ImgFotos.Source = x;
                    }

                }
            }
            catch
            {
                MessageBox.Show("No hay imágenes");
            }
            
        }

        private void DtgCasas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DtgCasas_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            
            try
            {
                if (DtgCasas.SelectedIndex > -1)
                {
                    i = 0;

                    Casa objC = (Casa)DtgCasas.SelectedItem;
                    if (objC.ConjuntoFotos != "" && objC.ConjuntoFotos != null)
                    {
                        ColImagenes = Directory.GetFiles(objC.ConjuntoFotos, "*.jpg");

                        if (ColImagenes != null)
                        {
                            x = new BitmapImage();
                            x.BeginInit();
                            x.UriSource = new Uri(@"" + ColImagenes[i].ToString());
                            x.EndInit();
                            ImgFotos.Stretch = Stretch.Uniform;
                            ImgFotos.Source = x;
                        }

                    }
                }
                
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No se encuentra la ruta de la carpeta de imagenes");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("No se encuentra la ruta de la carpeta de imagenes");
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("El formato de los archivos de la carpeta de fotos no es el correcto");
            }
            catch
            {
                MessageBox.Show("No es posible ver las fotos del inmueble");
            }
        }

        private void DtgAptos_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            try
            {
                if (DtgAptos.SelectedIndex > -1)
                {
                    i = 0;

                    Apartamento objC = (Apartamento)DtgAptos.SelectedItem;
                    if (objC.ConjuntoFotos != "" && objC.ConjuntoFotos != null)
                    {
                        ColImagenes = Directory.GetFiles(objC.ConjuntoFotos, "*.jpg");

                        if (ColImagenes != null)
                        {
                            x = new BitmapImage();
                            x.BeginInit();
                            x.UriSource = new Uri(@"" + ColImagenes[i].ToString());
                            x.EndInit();
                            ImgFotos.Stretch = Stretch.Uniform;
                            ImgFotos.Source = x;
                        }

                    }
                }

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No se encuentra la ruta de la carpeta de imagenes");
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("No se encuentra la ruta de la carpeta de imagenes");
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("La carpeta está vacía o el formato de los archivos de la carpeta de fotos no es el correcto. Deben ser .jpg");
            }
            catch
            {
                MessageBox.Show("No es posible ver las fotos del inmueble");
            }

        }

        private void Rectangle_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            

        }

        private void RbtCasas_Checked_1(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void RbtCasas_Unchecked_1(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void TxtIDPrincipal_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtIDPrincipal_GotFocus_1(object sender, System.Windows.RoutedEventArgs e)
        {
            TxtIDPrincipal.Clear();
        }
    }
}
