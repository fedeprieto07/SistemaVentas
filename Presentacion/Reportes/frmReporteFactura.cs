using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class frmReporteFactura : Form
    {
        private int _idVenta;


        public frmReporteFactura()
        {
            InitializeComponent();
        }

        public int IdVenta { get => _idVenta; set => _idVenta = value; }

        private void frmReporteFactura_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSprincipal.spreporte_factura' table. You can move, or remove it, as needed.

            try
            {
                this.spreporte_facturaTableAdapter.Fill(this.DSprincipal.spreporte_factura, IdVenta);
                this.reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {

                this.reportViewer1.RefreshReport();
            }

        }
    }
}
