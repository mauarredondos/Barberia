using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Barberia
{
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                MySqlConnection conn = Conexion.ObtenerConexion();
                conn.Open();

                string query = "SELECT id_cliente, nombre, telefono, fecha_registro FROM clientes";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvClientes.DataSource = dt;

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn = Conexion.ObtenerConexion();
                conn.Open();

                string query = "INSERT INTO clientes (nombre, telefono) VALUES (@nombre, @telefono)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Cliente agregado.");

                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar: " + ex.Message);
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtId.Text = dgvClientes.Rows[e.RowIndex].Cells["id_cliente"].Value.ToString();
                txtNombre.Text = dgvClientes.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                txtTelefono.Text = dgvClientes.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
            }
        }

        private void False(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Selecciona un cliente primero.");
                return;
            }

            try
            {
                using (MySqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();

                    string query = "UPDATE clientes SET nombre=@nombre, telefono=@telefono WHERE id_cliente=@id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                    cmd.Parameters.AddWithValue("@id", txtId.Text.Trim());

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cliente actualizado correctamente.");
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Selecciona un cliente primero.");
                return;
            }

            try
            {
                MySqlConnection conn = Conexion.ObtenerConexion();
                conn.Open();

                string query = "DELETE FROM clientes WHERE id_cliente = @id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", txtId.Text);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Cliente eliminado correctamente.");

                CargarClientes(); 
                LimpiarCampos();  
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }
    }
}
