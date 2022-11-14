using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using AccesoDatos.Users;

namespace Dominio
{
    public class ModelUsers
    {
        AccessUsers userDAO = new AccessUsers();
        DataUsers data_users = new DataUsers();
        UpdateUser update_user = new UpdateUser();

        public bool LoginUser(string user, string pass)
        {
            return userDAO.Login(user, pass);
        }

        public bool AddUser(string user, string nombres, string apellidos, string pass, string email, bool program)
        {

            return userDAO.AgregarUsuario(user, nombres, apellidos, pass, email, program);
        }

        public Dictionary<string,string> GetDataUser(string user, string pass)
        {
            return data_users.DataUser(user, pass);
        }
        public bool UpdateNombres(string user, string pass, string campo_alt, string valor)
        {
            return update_user.UpdateDataUser(user,pass,campo_alt, valor);
        }

        public DataTable GetUsuarios()
        {
            return data_users.GetUsuarios();
        }

        public bool VerificGmail(string gmail)
        {
            return userDAO.VerificGmail(gmail);
        }

        public Dictionary<int,string> GetNamesCuentas(string gmail)
        {
            return data_users.GetNamesCuentas(gmail);
        }

        public bool UpdatePassUser(int id_user, string new_pass)
        {
            return update_user.UpdatePassUser(id_user, new_pass);
        }

    }
}
