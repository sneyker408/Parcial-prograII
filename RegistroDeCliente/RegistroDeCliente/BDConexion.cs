using System;
using RegistroDeCliente.CapaDAL;
using RegistroDeCliente.Modelos;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeCliente
{
    public class BDConexion
    {
        public static SqlConnection ObtenerConexion()
        {
            SqlConnection conexion = new SqlConnection("Data Source=SNEYKER;Initial Catalog=Vapesney;Integrated Security=True");
            conexion.Open();
            return conexion;
        }

    }
}
