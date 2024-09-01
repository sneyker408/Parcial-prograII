using RegistroDeCliente.Modelos;
using RegistroDeCliente.CapaDAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistroDeCliente.CapaDAL.RegistroDeCliente.CapaDAL;

namespace RegistroDeCliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void RefrescarPantalla()
        {
            dataGridView1.DataSource = null; // Limpiar la fuente de datos actual
            dataGridView1.DataSource = ClienteDAL.PresentarRegistro(); // Cargar los datos actualizados
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int id = 0;

            // Verificar si hay una fila seleccionada y obtener el ClienteID
            if (dataGridView1.SelectedRows.Count == 1)
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ClienteID"].Value);
            }

            // Crear una instancia del cliente con el ClienteID obtenido
            Cliente cliente = new Cliente(id, txtNombre.Text, txtApellido.Text, txtTelefono.Text);

            int result;

            if (id != 0)
            {
                // Si el ID no es 0, actualizamos el cliente existente
                result = ClienteDAL.ModificarCliente(cliente);

                if (result > 0)
                {
                    MessageBox.Show("Éxito al Modificar");
                }
                else
                {
                    MessageBox.Show("Error al Modificar");
                }
            }
            else
            {
                // Si el ID es 0, se agrega un nuevo cliente
                result = ClienteDAL.AgregarCliente(cliente);

                if (result > 0)
                {
                    MessageBox.Show("Éxito al Guardar");
                }
                else
                {
                    MessageBox.Show("Error al Guardar");
                }
            }

            RefrescarPantalla(); // Refrescar la pantalla después de la operación
            btnLimpiar_Click(sender, e); // Limpiar los campos después de la operación
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            RefrescarPantalla(); // Cargar los datos cuando se carga el formulario
            btnLimpiar_Click(sender, e); // Limpiar los campos al iniciar el formulario
            txtClienteID.Enabled = false; // Desactivar la edición del ID del cliente
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                txtClienteID.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["ClienteID"].Value);
                txtNombre.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["nombre"].Value);
                txtApellido.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["apellido"].Value);
                txtTelefono.Text = Convert.ToString(dataGridView1.CurrentRow.Cells["telefono"].Value);
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtClienteID.Clear(); // Limpiar el campo de ID del cliente

            // Deseleccionar cualquier fila en el DataGridView
            dataGridView1.CurrentCell = null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["ClienteID"].Value);

                int result = ClienteDAL.EliminarCliente(id);

                if (result > 0)
                {
                    MessageBox.Show("Cliente eliminado con éxito");
                    RefrescarPantalla(); // Refrescar el DataGridView después de eliminar
                    btnLimpiar_Click(sender, e); // Limpiar los campos después de eliminar
                }
                else
                {
                    MessageBox.Show("Error al eliminar el cliente");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente para eliminar.");
            }
        }
    }
}
