using System;
using RegistroDeCliente.Modelos;
using RegistroDeCliente.CapaDAL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;

namespace RegistroDeCliente.CapaDAL
{
    namespace RegistroDeCliente.CapaDAL
    {
        public class ClienteDAL
        {
            public static int AgregarCliente(Cliente cliente)
            {
                int retorno = 0;

                using (SqlConnection conexion = BDConexion.ObtenerConexion())
                {
                    string query = "INSERT INTO cliente (nombre, apellido, telefono) VALUES (@nombre, @apellido, @telefono)";
                    SqlCommand comando = new SqlCommand(query, conexion);

                    // Agregar los parámetros con los valores del cliente
                    comando.Parameters.AddWithValue("@nombre", cliente.nombre);
                    comando.Parameters.AddWithValue("@apellido", cliente.apellido);
                    comando.Parameters.AddWithValue("@telefono", cliente.telefono);

                    // Ejecutar la consulta
                    retorno = comando.ExecuteNonQuery();
                }

                return retorno;
            }

            public static List<Cliente> PresentarRegistro()
            {
                List<Cliente> lista = new List<Cliente>();

                using (SqlConnection conexion = BDConexion.ObtenerConexion())
                {
                    string query = "SELECT * FROM cliente";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    SqlDataReader reader = comando.ExecuteReader();

                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente(
                            reader.GetInt32(0), // ClienteID
                            reader.GetString(1), // nombre
                            reader.GetString(2), // apellido
                            reader.GetString(3)  // telefono
                        );

                        lista.Add(cliente);
                    }
                }

                return lista;
            }

            public static int ModificarCliente(Cliente cliente)
            {
                int result = 0;
                using (SqlConnection conexion = BDConexion.ObtenerConexion())
                {
                    string query = "UPDATE cliente SET nombre = @nombre, apellido = @apellido, telefono = @telefono WHERE ClienteID = @ClienteID";
                    SqlCommand comando = new SqlCommand(query, conexion);

                    // Agregar los parámetros con los valores del cliente
                    comando.Parameters.AddWithValue("@nombre", cliente.nombre);
                    comando.Parameters.AddWithValue("@apellido", cliente.apellido);
                    comando.Parameters.AddWithValue("@telefono", cliente.telefono);
                    comando.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);

                    result = comando.ExecuteNonQuery();
                }
                return result;
            }
            public static int EliminarCliente(int clienteID)
            {
                int result = 0;
                using (SqlConnection conexion = BDConexion.ObtenerConexion())
                {
                    string query = "DELETE FROM cliente WHERE ClienteID = @ClienteID";
                    SqlCommand comando = new SqlCommand(query, conexion);
                    comando.Parameters.AddWithValue("@ClienteID", clienteID);

                    result = comando.ExecuteNonQuery();
                }
                return result;
            }
        }
    }
}
