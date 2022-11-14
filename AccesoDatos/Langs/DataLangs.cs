using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class DataLangs : ConnectionToSql
    {

        public (List<String>, List<String>) IdNameLangs(string user, string pass)
        {
            // id de los lenguajes permitos que tiene el usuario
            AccessLangs acceso_langs = new AccessLangs();
            
            List<String> id_langs = new List<String>();
            foreach(String item in acceso_langs.AccesoLangs(user, pass))
            {
                id_langs.Add(item);
            }
            // haciento la consulta
            string condicion = "", or="' OR ", lang=" idLang='";
            int cont = 0, largo_list=id_langs.Count;
            foreach(String id in id_langs)
            {
                cont++;

                if (cont == largo_list) condicion += lang + id+"'";
                else condicion += lang + id + or;
            }

            List<String> lista_langs = new List<String>();
            List<String> lista_id_langs = new List<String>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT idLang, nombre FROM Lenguajes WHERE " + condicion;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista_id_langs.Add(reader.GetString(0));
                            lista_langs.Add(reader.GetString(1));
                        }

                        return (lista_langs, lista_id_langs);
                    }
                }
            }
        }

        public (List<string>,List<string>,List<string>) GetTotalLangs()
        {
            List<string> name_langs = new List<string>();
            List<string> id_langs = new List<string>();
            List<string> url_doc = new List<string>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT idLang, nombre, urlDocument FROM Lenguajes";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id_langs.Add(reader.GetString(0));
                            name_langs.Add(reader.GetString(1));
                            url_doc.Add(reader.GetString(2));
                        }

                        return (name_langs, id_langs,url_doc);
                    }
                }
            }
        }

    }
}
