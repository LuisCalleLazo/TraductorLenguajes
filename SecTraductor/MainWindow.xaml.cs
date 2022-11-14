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
using Usuarios.Traductor;
namespace SecTraductor
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public String[] idsLangs, namesLangs;
        protected string name_user, pass;
        public MainWindow(String user,String pass)
        {
            this.name_user = user;
            this.pass = pass;

            InitializeComponent();
            LoadLangs(this.name_user,this.pass);
        }
        private void TraducirLenguaje(object sender, RoutedEventArgs e)
        {
            int lang_uso = LangsUso.SelectedIndex;
            int lang_trac = LangsTrac.SelectedIndex;

            CuadroCodigo.SelectAll();
            String codigo = CuadroCodigo.Selection.Text;

            try
            {
                Traductor traductor = new Traductor(this.idsLangs[lang_uso], this.idsLangs[lang_trac], 
                                                    this.namesLangs[lang_uso], this.namesLangs[lang_trac], codigo);
                traductor.MostrarTraduccion();
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                MessageBox.Show("Hubo un error en la traducción");
            }
        }

        private void LangsTrac_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // SelectedIndex marca la posicion donde se selecciono

            int lang_uso = LangsUso.SelectedIndex;
            int lang_trac = LangsTrac.SelectedIndex;

            if (lang_trac == lang_uso)
            {
                //MessageBox.Show("Los dos lados no pueden ser iguales");
                if (lang_trac != LangsTrac.Items.Count - 1) LangsTrac.SelectedIndex = lang_trac + 1;
                else LangsTrac.SelectedIndex = lang_trac - 1;
            }

            StrucsPrs struct_principal = new StrucsPrs(idsLangs[lang_uso]);
            string estructura = struct_principal.GetStructPr();

            this.CuadroCodigo.SelectAll();
            this.CuadroCodigo.Selection.Text = "\n"+estructura;

        }

        private void CambiarLangs(object sender, RoutedEventArgs e)
        {
            int cod1 = LangsUso.SelectedIndex;
            int cod2 = LangsTrac.SelectedIndex;

            LangsUso.SelectedIndex = cod2;
            LangsTrac.SelectedIndex = cod1;
        }

        private void CuadroCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
            {
                //CuadroCodigo.CaretPosition.DeleteTextInRun(0);
                CuadroCodigo.CaretPosition.InsertTextInRun("\t");
            }
            else if (e.Key == Key.Return)
            {
                //CuadroCodigo.CaretPosition.DeleteTextInRun(0);
                CuadroCodigo.CaretPosition.InsertTextInRun("\n");
            }

        }

        public void LoadLangs(string user, string pass)
        {

            // Cargando los lenguajes
            ModelLangs data_langs = new ModelLangs();

            (List<String> lista_langs, List<String> lista_id_langs) = data_langs.IdNamelangs(user, pass);

            foreach (String item in lista_langs)
            {
                LangsTrac.Items.Add(new ComboBoxItem { Content = item });
                LangsUso.Items.Add(new ComboBoxItem { Content = item });
            }

            // Relacionando la posicion de los ComboBoxItem con las id de los lenguajes

            idsLangs = new String[lista_id_langs.Count];
            namesLangs = new string[lista_langs.Count];

            for (int i = 0; i < lista_id_langs.Count; i++)
            {
                idsLangs[i] = lista_id_langs[i];
                namesLangs[i] = lista_langs[i];
            }

            LangsUso.SelectedIndex = 0;
            LangsTrac.SelectedIndex = 1;
        }
    }
}
