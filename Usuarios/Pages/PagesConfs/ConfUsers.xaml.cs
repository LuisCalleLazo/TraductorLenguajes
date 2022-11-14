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

using Dominio;
namespace Usuarios.Pages.PagesConfs
{
    /// <summary>
    /// Lógica de interacción para ConfUsers.xaml
    /// </summary>
    public partial class ConfUsers : Page
    {
        string user_name, pass;
        public ConfUsers(string user_name, string pass)
        {
            this.user_name = user_name;
            this.pass = pass;
            InitializeComponent();
            CargarDataUser(this.user_name, this.pass);
        }
        public void CargarDataUser(string user_name, string pass)
        {
            ModelUsers model_user = new ModelUsers();
            Dictionary<string,string> data_user=model_user.GetDataUser(user_name, pass);
            /*
             * name_user
             * pass
             * apellidos
             * nombres
             * email
             */
            this.usu_nombres_txt.Text = data_user["nombres"];
            this.usu_apellidos_txt.Text = data_user["apellidos"];
            this.usu_gmail_txt.Text = data_user["email"];
            //this.usu_password.Text = data_user["pass"];
            this.usu_nombre_txt.Text = data_user["name_user"];

        }
        private void MostrarOcultarContra(object sender, RoutedEventArgs e)
        {

            if (this.usu_pass.Visibility == Visibility.Hidden)
            {
                this.usu_password.Visibility = Visibility.Hidden;
                this.usu_pass.Password = this.usu_password.Text;
                this.usu_pass.Visibility = Visibility.Visible;
                this.cambiar_contra.Content = "Ver contraseña";
            }
            else
            {
                this.usu_pass.Visibility = Visibility.Hidden;
                this.usu_password.Text = this.usu_pass.Password;
                this.usu_password.Visibility = Visibility.Visible;
                this.cambiar_contra.Content = "Ocultar contraseña";
            }
        }

        private void CambiarNombresUser(object sender, RoutedEventArgs e)
        {
            Verification window_verific = new Verification("nombres", this.usu_nombres.Text, this.user_name, this.pass);
            window_verific.Show();
        }
        private void CambiarApellidosUser(object sender, RoutedEventArgs e)
        {
            Verification window_verific = new Verification("apellidos", this.usu_apellidos.Text, this.user_name, this.pass);
            window_verific.Show();
        }
        private void CambiarNameUser(object sender, RoutedEventArgs e)
        {
            Verification window_verific = new Verification("nameUser", this.usu_nombre.Text, this.user_name, this.pass);
            window_verific.Show();
        }
        private void CambiarPasswordUser(object sender, RoutedEventArgs e)
        {
            string pass;
            if (this.usu_pass.Visibility == Visibility.Hidden)
            {
                pass = this.usu_password.Text;
            }
            else
            {
                pass = this.usu_pass.Password;
            }
            Verification window_verific = new Verification("password", pass, this.user_name, this.pass);
            window_verific.Show();
        }
        private void CambiarGmailUser(object sender, RoutedEventArgs e)
        {
            Verification window_verific = new Verification("email", this.usu_gmail.Text, this.user_name, this.pass);
            window_verific.Show();
        }

    }
}
