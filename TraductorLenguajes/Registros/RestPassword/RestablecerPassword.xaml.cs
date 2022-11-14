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

namespace TraductorLenguajes.Registros.RestPassword
{
    /// <summary>
    /// Lógica de interacción para RestablecerPassword.xaml
    /// </summary>
    public partial class RestablecerPassword : Window
    {
        int cod_user;
        public RestablecerPassword(int cod_user)
        {
            this.cod_user = cod_user;
            InitializeComponent();
        }

        private void CambiarPassword(object sender, RoutedEventArgs e)
        {
            string new_pass = this.new_pass.Password;

            ModelUsers model_user = new ModelUsers();
            bool update=model_user.UpdatePassUser(this.cod_user, new_pass);

            if (update)
            {
                Login ventana_login = new Login();
                ventana_login.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Hubo un error al cambiar la contraseña");
            }

        }

        private void MostrarContra(object sender, RoutedEventArgs e)
        {
            string pass;
            this.new_pass.Visibility = Visibility.Hidden;
            pass = this.new_pass.Password;
            this.txtPass.Visibility = Visibility.Visible;
            this.txtPass.Text = pass;
        }

        private void OcultarContra(object sender, RoutedEventArgs e)
        {
            string pass;
            this.new_pass.Visibility = Visibility.Visible;
            pass = this.txtPass.Text;
            this.txtPass.Visibility = Visibility.Hidden;
            this.new_pass.Password = pass;
        }
    }
}
