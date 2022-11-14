using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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

using TraductorLenguajes.Registros;
namespace TraductorLenguajes
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login(object sender, RoutedEventArgs e)
        {
            Login ventana_login = new Login();
            ventana_login.Show();

            this.Close();
        }

        private void CrearCuenta(object sender, RoutedEventArgs e)
        {
            NuevoUsuario ventana_new_user = new NuevoUsuario();
            ventana_new_user.Show();

            this.Close();
        }
    }
}
