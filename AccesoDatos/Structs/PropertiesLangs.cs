using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.Langs
{
    public class PropertiesLangs:ConnectionToSql
    {
        public String StructPrLang(String id_lang)
        {
            String url_struct_pr;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT idLang, estructuraPrincipal FROM Lenguajes WHERE idLang=@idLang";
                    command.Parameters.AddWithValue("@idLang", id_lang);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        reader.Read();
                        try
                        {
                            url_struct_pr = reader.GetString(1);
                        }catch(Exception err)
                        {
                            Console.WriteLine(err);
                            url_struct_pr = "";
                        }
                        return url_struct_pr;
                    }
                }
            }
        }
    }
}
