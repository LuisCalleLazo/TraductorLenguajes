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
    /// Lógica de interacción para NuevoUsuario.xaml
    /// </summary>
    public partial class NuevoUsuario : Window
    {
        public NuevoUsuario()
        {
            InitializeComponent();
        }

        private void CrearCuenta(object sender, RoutedEventArgs e)
        {
            ModelUsers user = new ModelUsers();

            bool program;
            string password,pass_conf;

            if (MostrarOcultar.IsChecked == true)
            {
                program = true; password = txtPass.Text; pass_conf = txtPassConf.Text;
            }
            else
            {
                program = false; password = passw.Password; pass_conf = passConf.Password;
            }

            string valid_form = ValidacionForm(email.Text, password, pass_conf);

            if (valid_form == "posi")
            {
                bool validAddUser = user.AddUser(nameUser.Text, nombres.Text, apellidos.Text, passw.Password, email.Text, program);

                if (validAddUser)
                {
                    MessageBox.Show("Se agrego correctamente el usuario");
                    Window login = new Login();
                    login.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hubo un problema al agregar");
                }
            }
            else
            {
                MessageBox.Show(valid_form);
            }
        }


        private void Cancelar(object sender, RoutedEventArgs e)
        {
            Window ventana_pr = new TraductorLenguajes.MainWindow();
            ventana_pr.Show();

            this.Close();
        }
        private void MostrarContra(object sender, RoutedEventArgs e)
        {
            // Ocutando los passwordBox
            passw.Visibility = Visibility.Hidden;
            passConf.Visibility = Visibility.Hidden;

            // Asginando los valores ya ingresados en los PasswordBox a los TextBox
            txtPass.Text = passw.Password;
            txtPassConf.Text = passConf.Password;

            // Mostrando los textBox
            txtPass.Visibility = Visibility.Visible;
            txtPassConf.Visibility = Visibility.Visible;
        }
        private void OcultarContra(object sender, RoutedEventArgs e)
        {
            // Mostrando los textBox
            txtPass.Visibility = Visibility.Hidden;
            txtPassConf.Visibility = Visibility.Hidden;

            // Asginando los valores ya ingresados en los PasswordBox a los TextBox
            passw.Password = txtPass.Text;
            passConf.Password = txtPassConf.Text;


            // Ocutando los passwordBox
            passw.Visibility = Visibility.Visible;
            passConf.Visibility = Visibility.Visible;

        }
        public static string ValidacionForm(string email, string pass, string passConf)
        {
            string result_valid="posi";

            if (pass != passConf) result_valid = "Las contraseñas no son iguales";

            return result_valid;
        }
    }
}
