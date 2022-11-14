using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.Users
{
    public class UpdateUser : ConnectionToSql
    {
        public bool UpdateDataUser(string user, string pass,string campo_alt, string valor)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Usuarios "
                                        + $"SET {campo_alt}=@nombres "
                                        + "WHERE nameUser=@user AND password=@pass";

                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.Parameters.AddWithValue("@nombres", valor);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        return false;
                    }

                }
            }
        }
        public bool UpdatePassUser(int id_user, string new_pass)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Usuarios "
                                        + "SET password=@newPass "
                                        + "WHERE idUsuario=@idUsu";

                    command.Parameters.AddWithValue("@newPass", new_pass);
                    command.Parameters.AddWithValue("@idUsu", id_user);

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        return false;
                    }

                }
            }
        }
    }
}
