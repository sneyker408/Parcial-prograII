using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistroDeCliente.Modelos
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }

        // Constructor con todos los parámetros
        public Cliente(int clienteID, string nombre, string apellido, string telefono)
        {
            this.ClienteID = clienteID;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
        }

        // Constructor vacío opcional
        public Cliente() { }
    }
}
