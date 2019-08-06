using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.consultas
{
    public partial class frmConsulta_Bitacora : Form
    {
        List<Control> ctrl = new List<Control>();
        List<TabPage> allItems = new List<TabPage>();
        public string idioma;
        public int Idtrabajador;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;

        public frmConsulta_Bitacora()
        {
            InitializeComponent();
        }

        private void frmConsulta_Bitacora_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Mostrar()
        {
            this.dataListado.DataSource = nDetalle_Ingreso.MostrarBitacora();
            
            lblTotal.Text = Convert.ToString(dataListado.Rows.Count);
            this.dataListado.Columns[0].Visible = false;
        }

        private void BuscarFechasBitacora()
        {
            this.dataListado.DataSource = nDetalle_Ingreso.BuscarFechasBitacora(this.dtFecha1.Value.ToString("MM/dd/yyyy"),
                this.dtFecha2.Value.ToString("MM/dd/yyyy"));
            this.dataListado.Columns[0].Visible = false;
            lblTotal.Text = Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechasBitacora();
        }
    }
}
