using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using AccesoDatos.Langs;

namespace Dominio
{
    public class ModelLangs
    {
        DataLangs data_langs = new DataLangs();
        PropertiesLangs proper_langs = new PropertiesLangs();
        public (List<String> , List<String>) IdNamelangs(string user, string pass)
        {

            return data_langs.IdNameLangs(user,pass);
        }

        public String StructPrLang(String id_lang)
        {
            return proper_langs.StructPrLang(id_lang);
        }

        public (List<string>,List<string>,List<string>) GetInfoLangs()
        {
            return data_langs.GetTotalLangs();
        }

        public List<string> GetLangVariable(string id_lang)
        {
            List<string> info_lang = new List<string>();
            return info_lang;
        }

    }
}
