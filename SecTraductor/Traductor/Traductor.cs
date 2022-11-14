using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios.Traductor
{
    class Traductor
    {
        public string id_lang_uso,id_lang_trac,codigo, name_lang_uso, name_lang_trac;
        public Traductor(string id_lang_uso, string id_lang_trac, string name_lang_uso, string name_lang_trac, String codigo)
        {
            this.id_lang_uso = id_lang_uso;
            this.id_lang_trac = id_lang_trac;
            this.codigo = codigo;
            this.name_lang_uso = name_lang_uso;
            this.name_lang_trac = name_lang_trac;
        }

        public String GetContPrincipal(String codigo)
        {
            String estructura;

            int punto_ini, punto_final, struct_final, p = 0;
            string struct_i = "", struct_f = "";
            string identado = "";
            switch (this.id_lang_uso)
            {
                case "CS":
                    identado = "\t\t";
                    struct_i = identado+"{";
                    struct_f = identado+"}";
                    p = 3;
                    break;
                case "JAVA":
                    identado = "\t";
                    struct_i = identado+"{";
                    struct_f = identado+"}";
                    p = 2;
                    break;
            }

            if(struct_i == "" || struct_f == "")
            {
                punto_ini = 0;
                punto_final = codigo.Length - 1;
            }
            else
            {
                punto_ini = codigo.IndexOf(struct_i) + p;
                struct_final = codigo.IndexOf(struct_f);
                punto_final = struct_final - punto_ini;
                identado += "\t";
            }

            // Agarrando el contenido principal
            estructura = codigo.Substring(punto_ini, punto_final);
            string ident_trac = "";
            switch (this.id_lang_trac)
            {
                case "CS":
                    ident_trac = "\n\t\t\t";
                    break;
                case "JAVA":
                    ident_trac = "\n\t\t";
                    break;
            }

            estructura = estructura.Replace("\n"+identado, ident_trac);
            return estructura;
        }

        public String GetTracVariables(String codigo)
        {
            switch (this.id_lang_uso)
            {
                case "PY":
                    break;
                case "CS":
                    break;
                case "JS":
                    break;
                case "JAVA":
                    break;
            }
            return "";
        }

        public String GetFunciones(String codigo)
        {
            return "";
        }
        public String GetClases(String codigo)
        {
            return "";
        }

        public String Traducir(String codigo)
        {
            StrucsPrs struct_princ = new StrucsPrs(this.id_lang_trac);
            String estructura = struct_princ.GetStructPr();

            String codigo_traducido;
            string ident = "";
            if (estructura != "")
            {
                switch (this.id_lang_trac)
                {
                    case "CS":
                        ident = "\t\t\t";
                        break;
                    case "JAVA":
                        ident = "\t\t";
                        break;
                }
                codigo_traducido = estructura.Replace(ident,GetContPrincipal(codigo));
            }
            else
            {
                codigo_traducido = GetContPrincipal(codigo);
            }

            return codigo_traducido;
        }


        public void MostrarTraduccion()
        {
            String cod_traducido = Traducir(this.codigo);
            LangTraducido ventana_traduccion = new LangTraducido(this.name_lang_uso,this.name_lang_trac,cod_traducido);
            ventana_traduccion.Show();
        }


    }
}
