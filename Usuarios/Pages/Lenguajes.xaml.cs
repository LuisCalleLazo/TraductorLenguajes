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
using Dominio;

namespace Usuarios.Pages
{
    /// <summary>
    /// Lógica de interacción para Lenguajes.xaml
    /// </summary>
    public partial class Lenguajes : Page
    {

        public Lenguajes()
        {
            InitializeComponent();
            LoadListLangs();
        }

        List<string> names_langs = new List<string>();
        List<string> id_langs = new List<string>();
        List<string> url_langs = new List<string>();
        public void LoadListLangs()
        {
            ModelLangs model_langs = new ModelLangs();

            (names_langs, id_langs, url_langs) = model_langs.GetInfoLangs();

            for (int i = 0; i < id_langs.Count; i++)
            {
                ListBoxItem item = new ListBoxItem
                {
                    Height = 60,
                    Content = names_langs[i],
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Name = id_langs[i],
                    Foreground = Brushes.White,
                };

                item.MouseDoubleClick += new MouseButtonEventHandler(CargarInfoLang);
                this.ListLangsDoc.Items.Add(item);

                //Inicializando la informacion
                this.ListLangsDoc.SelectedIndex = 0;
                this.name_lang.Content = names_langs[0];
                this.url_lang.Text = url_langs[0];
            }
            LoadFrames(this.id_langs[this.ListLangsDoc.SelectedIndex]);
            LoadImgLang(this.ListLangsDoc.SelectedIndex);
        }

        private void CargarInfoLang( object sender, MouseButtonEventArgs e)
        {
            int select = this.ListLangsDoc.SelectedIndex;
            this.name_lang.Content = names_langs[select];
            this.url_lang.Text = url_langs[select];

            LoadImgLang(select);

            LoadFrames(id_langs[select]);
        }

        public void LoadImgLang(int select)
        {

            // Imagen del lenguaje
            string name_img;
            if (names_langs[select] == "C#")
            {
                name_img = "Csharp.png";
            }
            else
            {
                name_img = $"{names_langs[select]}.png";
            }

            BitmapImage conf = new BitmapImage();
            conf.BeginInit();
            conf.UriSource = new Uri(name_img, UriKind.Relative);
            conf.EndInit();
            this.ImgLang.Source = conf;
        }

        List<int> id_frames = new List<int>();
        List<string> names_frames = new List<string>();
        List<string> url_frames = new List<string>();
        public void LoadFrames(string id_lang)
        {
            ModelFrames model_frames = new ModelFrames();
            (names_frames, id_frames,url_frames) = model_frames.GetNamesFrames(id_lang);

            this.ListFrames.Items.Clear();
            for (int i = 0; i < names_frames.Count; i++)
            {
                ListBoxItem frame = new ListBoxItem
                {
                    Height = 60,
                    Content = names_frames[i],
                    VerticalContentAlignment = VerticalAlignment.Center,
                    HorizontalContentAlignment = HorizontalAlignment.Center,
                    Foreground = Brushes.White,
                };

                frame.MouseDoubleClick += new MouseButtonEventHandler(CargarInfoFrame);
                this.ListFrames.Items.Add(frame);
            }

            this.ListFrames.SelectedIndex = 0;
            LoadInfoFrame(0);
        }
        private void CargarInfoFrame(object sender, MouseButtonEventArgs e)
        {
            int select = this.ListFrames.SelectedIndex;
            LoadInfoFrame(select);
        }
        public void LoadInfoFrame(int select)
        {
            ModelFrames model_frames = new ModelFrames();
            this.desc_frame.Text = model_frames.GetInfoFrame(id_frames[select]);
            this.url_frame.Text = url_frames[select];
        }

    }
}
