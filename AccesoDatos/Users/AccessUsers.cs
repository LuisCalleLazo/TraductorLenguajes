using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class AccessUsers : ConnectionToSql
    {
        public bool Login(string user, string pass)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Usuarios WHERE nameUser = @user AND password = @pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public bool VerificGmail(string gmail)
        {

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Usuarios WHERE email = @gmail";
                    command.Parameters.AddWithValue("@gmail", gmail);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        
        public bool AgregarUsuario(string user, string nombres,string apellidos, string pass, string email, bool program)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Usuarios(nameUser, apellidos, nombres, password, email, programador) "
                                        + "VALUES(@user, @apellidos, @nombres, @pass, @email, @program)";

                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@apellidos", apellidos);
                    command.Parameters.AddWithValue("@nombres", nombres);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@program", program);
                    

                    try
                    {
                        command.ExecuteNonQuery();
                        return true;
                    }catch(Exception e)
                    {
                        Console.WriteLine(e);
                        return false;
                    }

                }
            }
        }


    }
}
