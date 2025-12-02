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
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
            this.Load += FormVentas_Load;
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarVentas();
        }

        private void CargarClientes()
        {
            try
            {
                using (MySqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "SELECT id_cliente, nombre FROM clientes";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbCliente.DataSource = dt;
                    cmbCliente.DisplayMember = "nombre";
                    cmbCliente.ValueMember = "id_cliente";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar clientes: " + ex.Message);
            }
        }

        private void CargarVentas()
        {
            try
            {
                using (MySqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"SELECT v.id_venta, c.nombre AS cliente, v.servicio, v.precio, v.fecha_venta
                             FROM ventas v
                             INNER JOIN clientes c ON v.id_cliente = c.id_cliente";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvVentas.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar ventas: " + ex.Message);
            }
        }


        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "INSERT INTO ventas (id_cliente, servicio, precio) VALUES (@id_cliente, @servicio, @precio)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@id_cliente", cmbCliente.SelectedValue);
                    cmd.Parameters.AddWithValue("@servicio", txtServicio.Text);
                    cmd.Parameters.AddWithValue("@precio", numPrecio.Value);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Venta registrada correctamente.");
                CargarVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar venta: " + ex.Message);
            }
        }

        private int ObtenerIdVentaSeleccionada()
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvVentas.SelectedRows[0].Cells["id_venta"].Value);
            }
            return -1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = ObtenerIdVentaSeleccionada();

            if (id == -1)
            {
                MessageBox.Show("Seleccione una venta.");
                return;
            }

            try
            {
                using (MySqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "DELETE FROM ventas WHERE id_venta = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Venta eliminada.");
                CargarVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar venta: " + ex.Message);
            }
        }

    }
}