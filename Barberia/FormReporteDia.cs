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
    public partial class FormReporteDia : Form
    {
        public FormReporteDia()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            DateTime fecha = dtpFecha.Value.Date;

            try
            {
                using (MySqlConnection conn = Conexion.ObtenerConexion())
                {
                    conn.Open();


                    string queryVentas = @"SELECT SUM(precio) 
                                   FROM ventas 
                                   WHERE DATE(fecha_venta) = @fecha";

                    MySqlCommand cmdVentas = new MySqlCommand(queryVentas, conn);
                    cmdVentas.Parameters.AddWithValue("@fecha", fecha);

                    object resultadoVentas = cmdVentas.ExecuteScalar();
                    decimal totalVentas = resultadoVentas != DBNull.Value ? Convert.ToDecimal(resultadoVentas) : 0;

                    txtVentas.Text = totalVentas.ToString("0.00");


                    string queryCortes = @"SELECT COUNT(*) 
                                   FROM ventas 
                                   WHERE DATE(fecha_venta) = @fecha 
                                   AND servicio LIKE '%corte%'";

                    MySqlCommand cmdCortes = new MySqlCommand(queryCortes, conn);
                    cmdCortes.Parameters.AddWithValue("@fecha", fecha);

                    int totalCortes = Convert.ToInt32(cmdCortes.ExecuteScalar());
                    txtCortes.Text = totalCortes.ToString();


                    txtObservaciones.Text = $"Reporte generado el {fecha.ToShortDateString()}.\r\n" +
                                             $"Ventas totales: {totalVentas:0.00}\r\n" +
                                             $"Total cortes: {totalCortes}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message);
            }
        }

        private void FormReporteDia_Load(object sender, EventArgs e)
        {

        }
    }
}