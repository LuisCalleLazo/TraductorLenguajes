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
using Usuarios.Traductor;

namespace Usuarios
{
    /// <summary>
    /// Lógica de interacción para LangTraducido.xaml
    /// </summary>
    public partial class LangTraducido : Window
    {
        public string name_lang_uso, name_lang_trac;
        public String codigo_trac;
        public LangTraducido(string name_lang_uso, string name_lang_trac, String codigo_trac)
        {
            this.name_lang_uso = name_lang_uso;
            this.name_lang_trac = name_lang_trac;
            this.codigo_trac = codigo_trac;

            InitializeComponent();
            CodigoTraducido();
        }


        public void CodigoTraducido()
        {
            this.tituloLang.Content = "Traducción de:\t"+this.name_lang_uso+"\tA\t"+this.name_lang_trac;
            this.CampoTrac.Selection.Text = this.codigo_trac;
        }
    }
}
