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

namespace ObligatorioInmobiliaria2014MMP
{
    /// <summary>
    /// Lógica de interacción para Visita.xaml
    /// </summary>
    public partial class FrmAgregarVisita : Window
    {
        public FrmAgregarVisita()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtIdInmueble_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void TxtIdInmueble_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        public bool VerificarIDCliente(string ID)
        {
            int xID;
            if (int.TryParse(ID, out xID) == true)
            {
                ArrayList ids = new ArrayList();
                foreach (Persona i in Contenedor.ArrayPersonas)
                {
                    ids.Add(i.IdPersona);
                }

                if (ids.Contains(xID))
                {
                    return true;
                }
                else return false;
            }
            else
                return false;
        }
        public bool VerificarIDCasa(string ID)
        {
            int xID;
            if (int.TryParse(ID, out xID) == true)
            {
                ArrayList ids = new ArrayList();
                foreach (Casa i in Contenedor.ArrayCasas)
                {
                    ids.Add(i.IdInmueble);
                }

                if (ids.Contains(xID))
                {
                    return true;
                }
                else return false;
            }
            else
                return false;
        }

        public bool VerificarIDApto(string ID)
        {
            int xID;
            if (int.TryParse(ID, out xID) == true)
            {
                ArrayList ids = new ArrayList();
                foreach (Casa i in Contenedor.ArrayApartamentos)
                {
                    ids.Add(i.IdInmueble);
                }

                if (ids.Contains(xID))
                {
                    return true;
                }
                else return false;
            }
            else
                return false;
        }
        
        private void BtnCoordinarVisita_Click(object sender, RoutedEventArgs e)
        {

            try
            { //Verifica la fecha
                if (Convert.ToDateTime(DateFecha.Text) < DateTime.Now.Date)
                {
                    MessageBox.Show("Verifique la fecha");
                }
                //Si está bien la fecha...
                else
                { //Verifica la ID del cliente
                    if (VerificarIDCliente(TxtIdCliente.Text) == false)
                        throw new FormatException();
                    //Si está bien la ID del cliente...
                    else
                    {//Verifica si está algún check tildado
                        if (ChkCasa.IsChecked == false && ChkApto.IsChecked == false)
                        {
                            MessageBox.Show("Debe seleccionar casa o apartamento");
                        }
                        else//Si hay alguno tildado
                        {//Si es casa verifica la ID de la casa
                            if (ChkCasa.IsChecked == true)
                            {//Si no es un id válido lanza excecpción
                                if (VerificarIDCasa(TxtIdInmueble.Text) == false)
                                    throw new InvalidDataException();
                                //Si es un id válido agrega la visita
                                else
                                {
                                    Contenedor.ArrayVisitas.Add(FábricaDeObjetos.getVisita(TxtComentarios.Text, DateFecha.Text, Convert.ToInt32(TxtIdCliente.Text), Convert.ToInt32(TxtIdInmueble.Text)));
                                    TxtIdInmueble.Clear();
                                    TxtIdCliente.Clear();
                                    TxtComentarios.Clear();

                                    MessageBox.Show("Visita guardada exitosamente");
                                }
                            }//Si es apto verifica la ID del apto
                            else if (ChkApto.IsChecked == true)
                            {
                                {//Si no es un id válido lanza excecpción
                                    if (VerificarIDCasa(TxtIdInmueble.Text) == false)
                                        throw new InvalidDataException();
                                    //Si es un id válido agrega la visita
                                    else
                                    {
                                        Contenedor.ArrayVisitas.Add(FábricaDeObjetos.getVisita(TxtComentarios.Text, DateFecha.Text, Convert.ToInt32(TxtIdCliente.Text), Convert.ToInt32(TxtIdInmueble.Text)));
                                        TxtIdInmueble.Clear();
                                        TxtIdCliente.Clear();
                                        TxtComentarios.Clear();

                                        MessageBox.Show("Visita guardada exitosamente");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("No existe el cliente");
            }
            catch (InvalidDataException)
            {
                MessageBox.Show("No existe el inmueble");
            }
            catch
            {
                MessageBox.Show("Verifique los datos");
            }

            try
            {
                File.Exists("Visitas.txt");
                File.Delete("Visitas.txt");
            }
            finally { AdministradorArchivos.EscribirVisitas(@".\Visitas.txt"); }
        }

        private void TxtIdCliente_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void TxtComentarios_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TxtComentarios_MouseEnter(object sender, MouseEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrmBuscadorVisitas buscadorVisitas = new FrmBuscadorVisitas();
            this.Close();
            buscadorVisitas.Show();

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            frmMenu FrmMenu = new frmMenu();
            this.Close();
            FrmMenu.Show();
        }

        private void ChkCasa_Checked(object sender, RoutedEventArgs e)
        {
            ChkApto.IsEnabled = false;
        }

        private void ChkCasa_Unchecked(object sender, RoutedEventArgs e)
        {
            ChkApto.IsEnabled = true;
        }

        private void ChkApto_Unchecked(object sender, RoutedEventArgs e)
        {
            ChkCasa.IsEnabled = true;
        }

        private void ChkApto_Checked(object sender, RoutedEventArgs e)
        {
            ChkCasa.IsEnabled = false;
        }
    }
}
