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
using Usuarios.Pages.PagesConfs;

namespace Usuarios.Pages
{
    /// <summary>
    /// Lógica de interacción para Config.xaml
    /// </summary>
    public partial class Config : Page
    {
        string user_name, pass;

        public Config(String user_name, String pass)
        {
            this.user_name = user_name;
            this.pass = pass;

            InitializeComponent();

            this.DataConf.Navigate(new ConfPantalla());
        }


        // ------------------------NAVEGACION DE CONFIGURACION----------------------
        private void ShowConfUsers(object sender, RoutedEventArgs e)
        {
            this.DataConf.Navigate(new ConfUsers(this.user_name, this.pass));
        }
        private void ShowConfAccesLangs(object sender, RoutedEventArgs e)
        {
            this.DataConf.Navigate(new ConfAccesLangs());
        }
        private void ShowConfPermisos(object sender, RoutedEventArgs e)
        {
            this.DataConf.Navigate(new ConfPermisos());
        }
    }
}
