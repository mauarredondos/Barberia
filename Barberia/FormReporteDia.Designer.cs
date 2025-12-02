using System.Windows.Forms;

namespace Barberia
{
    partial class FormReporteDia
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblFecha;
        private DateTimePicker dtpFecha;
        private Button btnGenerar;
        private Label lblVentas;
        private Label lblCortes;
        private Label lblObservaciones;
        private TextBox txtVentas;
        private TextBox txtCortes;
        private TextBox txtObservaciones;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.lblVentas = new System.Windows.Forms.Label();
            this.lblCortes = new System.Windows.Forms.Label();
            this.lblObservaciones = new System.Windows.Forms.Label();
            this.txtVentas = new System.Windows.Forms.TextBox();
            this.txtCortes = new System.Windows.Forms.TextBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            
            this.lblFecha.Location = new System.Drawing.Point(20, 20);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(54, 23);
            this.lblFecha.TabIndex = 0;
            this.lblFecha.Text = "Fecha:";
            
            this.dtpFecha.Location = new System.Drawing.Point(80, 18);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 22);
            this.dtpFecha.TabIndex = 1;
            
            this.btnGenerar.Location = new System.Drawing.Point(280, 18);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
             
            this.lblVentas.Location = new System.Drawing.Point(20, 70);
            this.lblVentas.Name = "lblVentas";
            this.lblVentas.Size = new System.Drawing.Size(94, 23);
            this.lblVentas.TabIndex = 3;
            this.lblVentas.Text = "Total ventas:";
            
            this.lblCortes.Location = new System.Drawing.Point(20, 110);
            this.lblCortes.Name = "lblCortes";
            this.lblCortes.Size = new System.Drawing.Size(94, 23);
            this.lblCortes.TabIndex = 5;
            this.lblCortes.Text = "Total cortes:";
             
            this.lblObservaciones.Location = new System.Drawing.Point(20, 150);
            this.lblObservaciones.Name = "lblObservaciones";
            this.lblObservaciones.Size = new System.Drawing.Size(100, 23);
            this.lblObservaciones.TabIndex = 7;
            this.lblObservaciones.Text = "Observaciones:";
            
            this.txtVentas.Location = new System.Drawing.Point(120, 68);
            this.txtVentas.Name = "txtVentas";
            this.txtVentas.Size = new System.Drawing.Size(100, 22);
            this.txtVentas.TabIndex = 4;
            
            this.txtCortes.Location = new System.Drawing.Point(120, 108);
            this.txtCortes.Name = "txtCortes";
            this.txtCortes.Size = new System.Drawing.Size(100, 22);
            this.txtCortes.TabIndex = 6;
             
            this.txtObservaciones.Location = new System.Drawing.Point(20, 175);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.ReadOnly = true;
            this.txtObservaciones.Size = new System.Drawing.Size(350, 150);
            this.txtObservaciones.TabIndex = 8;
             
            this.ClientSize = new System.Drawing.Size(880, 373);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.lblVentas);
            this.Controls.Add(this.txtVentas);
            this.Controls.Add(this.lblCortes);
            this.Controls.Add(this.txtCortes);
            this.Controls.Add(this.lblObservaciones);
            this.Controls.Add(this.txtObservaciones);
            this.Name = "FormReporteDia";
            this.Text = "Reporte del día";
            this.Load += new System.EventHandler(this.FormReporteDia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
