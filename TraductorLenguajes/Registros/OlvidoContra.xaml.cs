
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
using TraductorLenguajes.Registros.RestPassword;

namespace TraductorLenguajes.Registros
{
    /// <summary>
    /// Lógica de interacción para OlvidoContra.xaml
    /// </summary>
    public partial class OlvidoContra : Window
    {
        string gmail_envio;
        public OlvidoContra()
        {
            InitializeComponent();
        }
        public OlvidoContra(string gmail)
        {
            this.gmail_envio = gmail;
            InitializeComponent();
            EstablecerGmail();
        }

        public void EstablecerGmail()
        {
            this.correo.Text = this.gmail_envio;
        }


        private void VerificarCorreo(object sender, RoutedEventArgs e)
        {

            ModelUsers model_user = new ModelUsers();
            string email = this.correo.Text;
            if (model_user.VerificGmail(email))
            {
                // MessageBox.Show("Si existe el gmail");
                VerificCodigoGmail verific_gmail = new VerificCodigoGmail(email);
                verific_gmail.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("No existe el gmail");
            }
        }
    }
}
