using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using DataSyntaxLangs;


namespace Usuarios.Traductor
{
    public class StrucsPrs
    {
        ModelLangs model_langs = new ModelLangs();
        String id_lang;
        public StrucsPrs(String id_lang)
        {
            this.id_lang = id_lang;
        }

        public String GetStructPr()
        {
            String url_struct_pr = model_langs.StructPrLang(this.id_lang);
            ReaderStructs lector_strucs = new ReaderStructs(url_struct_pr);

            String struct_pr = lector_strucs.ReadStructPrTxt();

            return struct_pr;
        }

    }
}
