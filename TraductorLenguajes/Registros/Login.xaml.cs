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

using Dominio;

namespace TraductorLenguajes.Registros
{
    /// <summary>
    /// Lógica de interacción para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void IngresarLogin(object sender, RoutedEventArgs e)
        {

            ModelUsers user = new ModelUsers();

            
            string pass;
            if (MostrarOcultar.IsChecked==true) pass = txtPass.Text;
            else pass = txtpassword.Password;

            var validLogin = user.LoginUser(txtusuario.Text, pass);
            
            if (validLogin == true)
            {
                MessageBox.Show("Usuario correcto ingresado");
                
                // Habriendo la ventana de Usuarios
                Window ventana_usuario = new Usuarios.MainWindow(txtusuario.Text, pass);
                ventana_usuario.Show();

                // Cerrando ventana Login
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos incorrectos ingresados \nPor favor intente de nuevo");
                txtpassword.Password = "";
                txtusuario.Focus();
            }
        }

        private void MostrarContra(object sender, RoutedEventArgs e)
        {
            string pass;
            txtpassword.Visibility = Visibility.Hidden;
            pass = txtpassword.Password;
            txtPass.Visibility = Visibility.Visible;
            txtPass.Text = pass;
        }

        private void OcultarContra(object sender, RoutedEventArgs e)
        {
            string pass;
            txtpassword.Visibility = Visibility.Visible;
            pass = txtPass.Text;
            txtPass.Visibility = Visibility.Hidden;
            txtpassword.Password = pass;
        }

        private void OlvidoContra(object sender, RoutedEventArgs e)
        {
            OlvidoContra ventana_olv_contra = new OlvidoContra();
            ventana_olv_contra.Show();
            this.Close();
        }
        
        private void Cancelar(object sender, RoutedEventArgs e)
        {
            // Volviendo a crear el Mainwindow principal
            Window ventana_princ = new TraductorLenguajes.MainWindow();
            ventana_princ.Show();

            // Estamos cerrando la ventana Login
            this.Close();
        }
    }
}
