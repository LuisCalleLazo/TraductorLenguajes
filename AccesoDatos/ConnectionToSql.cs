using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public abstract class ConnectionToSql
    {
        private readonly string connectionstring;

        public ConnectionToSql()
        {
            connectionstring = "Server=LAPTOP-U0P8E8E4\\MSSQLSERVER2; DataBase=TraductorLenguajes; integrated security=true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionstring);
        }

    }
}
