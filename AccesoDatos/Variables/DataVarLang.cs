using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace AccesoDatos.Variables
{
    public class DataVarLang:ConnectionToSql
    {
        public (int, int) GetIdsIniFormatVar(string id_lang)
        {
            int idIniVar, idFormatVar;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT idLang, idIniVar, idFomatVar "+
                                          "FROM VariablesLenguajes "+
                                          "WHERE idLang=@idLang";

                    command.Parameters.AddWithValue("@idLang", id_lang);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        idIniVar = reader.GetInt32(1);
                        idFormatVar = reader.GetInt32(2);
                        
                        return (idIniVar,idFormatVar);
                    }
                }
            }
        }

        public (int, int) GetVariable(string id_lang)
        {
            string ini_var, format_var;
            int idIniVar, idFormatVar;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT idLang, idIniVar, idFomatVar " +
                                          "FROM InicializacionVariables " +
                                          "WHERE idLang=@idLang";

                    command.Parameters.AddWithValue("@idLang", id_lang);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        idIniVar = reader.GetInt32(1);
                        idFormatVar = reader.GetInt32(2);

                        return (idIniVar, idFormatVar);
                    }
                }
            }
        }

    }
}
