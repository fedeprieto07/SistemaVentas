using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Entidades;

namespace Presentacion.consultas
{
    public partial class frmConsulta_Stockcs : Form
    {
        public string idioma;
        public frmConsulta_Stockcs()
        {
            InitializeComponent();
        }

        private void frmConsulta_Stockcs_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;

        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = nArticulo.Stock_Articulos();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
    }
}
