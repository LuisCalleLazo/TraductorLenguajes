using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.LibsFrams
{
    public class DataFrames:ConnectionToSql
    {
        public (List<string>,List<int>,List<string>) GetNamesFrames(string id_lang)
        {
            List<string> names_frames = new List<string>();
            List<int> id_frames = new List<int>();
            List<string> url_frames = new List<string>();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT idFrame, documentacion, nombre FROM Frameworks WHERE idLang=@idLang";
                    command.Parameters.AddWithValue("@idLang", id_lang);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id_frames.Add(reader.GetInt32(0));
                            url_frames.Add(reader.GetString(1));
                            names_frames.Add(reader.GetString(2));
                        }

                        return (names_frames,id_frames,url_frames);
                    }
                }
            }
        }

        public string GetInfoFrame(int id_frame)
        {
            using (SqlConnection connection = GetConnection())
            {
                string descripcion;
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    command.CommandText = "SELECT Fr.idFrame, Fr.idUsoFrame, Fr.idUsoFrame, Uf.descripcion "+
                                          "FROM Frameworks AS Fr, UsoFrameworks AS Uf "+
                                          "WHERE Fr.idFrame=@idFrame AND Fr.idUsoFrame=Uf.idUsoFrame";
                    
                    command.Parameters.AddWithValue("@idFrame", id_frame);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        descripcion = reader.GetString(3);

                        return descripcion;
                    }
                }
            }
        }
    }
}
