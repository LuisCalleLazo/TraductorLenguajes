using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

using SecTraductor;
using Usuarios.Pages;

namespace Usuarios
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public String [] idsLangs,namesLangs;
        protected string name_user, pass;
        public MainWindow(string name_user="", string pass="")
        {
            this.name_user = name_user;
            this.pass = pass;

            InitializeComponent();
            DatosUsuario(this.name_user,this.pass);
            MostrarPaginas();


        }

        private void AbrirTraductor(object sender, RoutedEventArgs e)
        {
            SecTraductor.MainWindow ventana_traductor = new SecTraductor.MainWindow(this.name_user, this.pass);
            ventana_traductor.Show();
        }

        public void DatosUsuario(string name_user, string pass)
        {
            CampoUsuario.Content += " " + name_user;
        }

        public void MostrarPaginas()
        {
            this.DataFrame.Navigate(new Info());

            this.info.Background = Brushes.Gray;
            this.comunidad.Background = Brushes.Black;
            this.configuraciones.Background = Brushes.Black;
            this.acces_lang.Background = Brushes.Black;
        }


        // ---------------------- PAGINAS DE NAVEGACION -----------------------
        private void info_Click(object sender, RoutedEventArgs e)
        {
            this.DataFrame.Navigate(new Info());

            this.info.Background = Brushes.Gray;
            this.comunidad.Background = Brushes.Black;
            this.configuraciones.Background = Brushes.Black;
            this.acces_lang.Background = Brushes.Black;
        }

        private void acces_lang_Click(object sender, RoutedEventArgs e)
        {
            this.DataFrame.Navigate(new Lenguajes());

            this.info.Background = Brushes.Black;
            this.comunidad.Background = Brushes.Black;
            this.configuraciones.Background = Brushes.Black;
            this.acces_lang.Background = Brushes.Gray;
        }

        private void comunidad_Click(object sender, RoutedEventArgs e)
        {
            this.DataFrame.Navigate(new Pages.PagesConfs.ConfUsers(this.name_user,this.pass));

            this.info.Background = Brushes.Black;
            this.comunidad.Background = Brushes.Gray;
            this.configuraciones.Background = Brushes.Black;
            this.acces_lang.Background = Brushes.Black;
        }

        private void configuraciones_Click(object sender, RoutedEventArgs e)
        {
            this.DataFrame.Navigate(new Config(this.name_user, this.pass));

            this.info.Background = Brushes.Black;
            this.comunidad.Background = Brushes.Black;
            this.configuraciones.Background = Brushes.Gray;
            this.acces_lang.Background = Brushes.Black;
        }
    }
}
