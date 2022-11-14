using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    class AccessLangs : ConnectionToSql
    {

        public int IdUser(string user, string pass)
        {
            int id;
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT idUsuario, nameUser, password FROM Usuarios WHERE nameUser=@user AND password=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        id = reader.GetInt32(0);

                        return id;
                    }
                }
            }
        }


        public List<String> AccesoLangs(string user, string pass)
        {
            int id_user = IdUser(user, pass);

            List<String> list_id_langs = new List<String>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT idLang, idUsuario FROM AccesoLenguajes WHERE idUsuario=@idUser";
                    command.Parameters.AddWithValue("@idUser", id_user);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list_id_langs.Add(reader.GetString(0));
                        }

                        return list_id_langs;
                    }
                }
            }
        }
    }
}
