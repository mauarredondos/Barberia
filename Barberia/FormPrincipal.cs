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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClientes f = new FormClientes();
            f.MdiParent = this;
            f.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVentas f = new FormVentas();
            f.MdiParent = this;
            f.Show();
        }

        private void citasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCitas f = new FormCitas();
            f.MdiParent = this;
            f.Show();
        }

        private void reporteDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReporteDia f = new FormReporteDia();
            f.MdiParent = this;
            f.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
    }
}