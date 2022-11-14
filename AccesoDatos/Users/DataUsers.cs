using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Policy;

namespace AccesoDatos
{
    public class DataUsers:ConnectionToSql
    {
        SqlDataReader reader;
        DataTable tabla = new DataTable();
        public DataTable GetUsuarios()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Usuarios";

                    reader = command.ExecuteReader();
                    tabla.Load(reader);
                    return tabla;
                }
            }
        }

        public Dictionary<int,string> GetNamesCuentas(string gmail)
        {
            Dictionary<int,string> data_user = new Dictionary<int, string>();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT idUsuario, nameUser, email FROM Usuarios" +
                        " WHERE email=@email";

                    command.Parameters.AddWithValue("@email", gmail);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            data_user.Add(reader.GetInt32(0),reader.GetString(1));
                        }

                        return data_user;
                    }
                }
            }
        }

        public Dictionary<string,string> DataUser(string user, string pass)
        {
            Dictionary<string,string> data_user = new Dictionary<string,string>();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT nameUser, password, apellidos, nombres, email FROM Usuarios"+
                        " WHERE nameUser=@user AND password=@pass";

                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        data_user.Add("name_user",reader.GetString(0));
                        data_user.Add("pass",reader.GetString(1));
                        data_user.Add("apellidos",reader.GetString(2));
                        data_user.Add("nombres",reader.GetString(3));
                        data_user.Add("email",reader.GetString(4));

                        return data_user;
                    }
                }
            }

        }


    }
}
