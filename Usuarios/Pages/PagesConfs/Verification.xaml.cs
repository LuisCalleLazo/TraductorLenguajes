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

namespace Usuarios.Pages.PagesConfs
{
    /// <summary>
    /// Lógica de interacción para Verification.xaml
    /// </summary>
    public partial class Verification : Window
    {
        ModelUsers model_user = new ModelUsers();
        string asunto, campo_act, user, pass;

        public Verification(string asunto, string campo_act, string user, string pass)
        {
            this.asunto = asunto;
            this.campo_act = campo_act;
            this.user = user;
            this.pass = pass;
            InitializeComponent();
            DataVerification();
        }

        public void DataVerification()
        {
            string intro= "Vas a modificar:\n";
            switch (this.asunto)
            {
                case "nombres":
                    this.titulo_verific.Content = $"{intro}nombres de usuario";
                    break;
                case "apellidos":
                    this.titulo_verific.Content = $"{intro}apellidos de usuario";
                    break;
                case "email":
                    this.titulo_verific.Content = $"{intro}gmail de usuario";
                    break;
                case "password":
                    this.titulo_verific.Content = $"{intro}contraseña de usuario";
                    break;
                case "nameUser":
                    this.titulo_verific.Content = $"{intro}nombre de usuario";
                    break;
            }
        }

        private void ActualizarDatosUser(object sender, RoutedEventArgs e)
        {
            string pass;
            if (this.checked_contra.IsChecked == true) pass = this.txtPass.Text;
            else pass = this.txtpassword.Password;

            if (pass == this.pass)
            {
                if (model_user.UpdateNombres(this.user, this.pass, this.asunto, this.campo_act))
                {
                    MessageBox.Show($"Se a actulizado el campo {this.asunto} con exito");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ocurrio un error");
                }
            }
            else
            {
                MessageBox.Show("La contraseña es incorrecta");
            }
        }

        private void MostrarPass(object sender, RoutedEventArgs e)
        {
            string pass;
            txtpassword.Visibility = Visibility.Hidden;
            pass = txtpassword.Password;
            txtPass.Visibility = Visibility.Visible;
            txtPass.Text = pass;
        }

        private void OcultarPass(object sender, RoutedEventArgs e)
        {
            string pass;
            txtpassword.Visibility = Visibility.Visible;
            pass = txtPass.Text;
            txtPass.Visibility = Visibility.Hidden;
            txtpassword.Password = pass;
        }

    }
}
