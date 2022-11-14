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
    /// Lógica de interacción para ElegirCuenta.xaml
    /// </summary>
    public partial class ElegirCuenta : Window
    {
        ModelUsers model_user = new ModelUsers();
        string gmail;
        public ElegirCuenta(string gmail)
        {
            this.gmail = gmail;
            InitializeComponent();
            LoadInfo();
        }
        int [] ids_user;
        public void LoadInfo()
        {
            // Nombre de correo electronico
            this.info_gmail.Content = this.gmail;

            // Cargando las cuentas vinculadas con el gmail
            Dictionary<int, string> cuentas_gmail = new Dictionary<int, string>();
            cuentas_gmail = this.model_user.GetNamesCuentas(this.gmail);

            ids_user = new int[cuentas_gmail.Count];
            int cont = 0;

            foreach (var cuenta in cuentas_gmail)
            {
                ListBoxItem item_cuenta = new ListBoxItem
                {
                    Height = 30,
                    Content = cuenta.Value,
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Foreground = Brushes.White,
                    Background = Brushes.DarkSlateGray,
                };

                item_cuenta.MouseDoubleClick += new MouseButtonEventHandler(CargarCambiarPass);
                this.ListCuentas.Items.Add(item_cuenta);

                ids_user[cont] = cuenta.Key; cont++;
            }
        }
        private void CargarCambiarPass(object sender, MouseButtonEventArgs e)
        {
            int id_user=ids_user[this.ListCuentas.SelectedIndex];

            RestablecerPassword ventan_rest = new RestablecerPassword(id_user);
            ventan_rest.Show();
            this.Close();
        }
    }
}
