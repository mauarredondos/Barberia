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
    public partial class FormCitas : Form
    {
        public FormCitas()
        {
            InitializeComponent();
            this.Load += FormCitas_Load;
        }

        private void FormCitas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarCitas();
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

        private void CargarCitas()
        {
            try
            {
                using (MySqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = @"SELECT ci.id_cita, c.nombre AS cliente, 
                                    ci.fecha_cita, ci.servicio, ci.nota
                             FROM citas ci
                             INNER JOIN clientes c ON ci.id_cliente = c.id_cliente";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvCitas.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar citas: " + ex.Message);
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "INSERT INTO citas (id_cliente, fecha_cita, servicio, nota) VALUES (@id_cliente, @fecha, @servicio, @nota)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@id_cliente", cmbCliente.SelectedValue);
                    cmd.Parameters.AddWithValue("@fecha", dtpFecha.Value);
                    cmd.Parameters.AddWithValue("@servicio", txtServicio.Text);
                    cmd.Parameters.AddWithValue("@nota", txtNota.Text);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cita registrada correctamente.");
                CargarCitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar cita: " + ex.Message);
            }
        }

        private int ObtenerIdCitaSeleccionada()
        {
            if (dgvCitas.SelectedRows.Count > 0)
            {
                return Convert.ToInt32(dgvCitas.SelectedRows[0].Cells["id_cita"].Value);
            }
            return -1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = ObtenerIdCitaSeleccionada();

            if (id == -1)
            {
                MessageBox.Show("Seleccione una cita en la tabla.");
                return;
            }

            try
            {
                using (MySqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "DELETE FROM citas WHERE id_cita = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Cita eliminada.");
                CargarCitas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar cita: " + ex.Message);
            }
        }

    }
}