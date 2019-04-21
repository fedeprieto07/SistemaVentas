using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;
using System.Data;
using System.Resources;
using System.Collections;

namespace Presentacion.consultas
{
    public partial class frmConsultaCompras : Form
    {

        List<Control> ctrl = new List<Control>();
        List<TabPage> allItems = new List<TabPage>();
        public string idioma;
        public int Idtrabajador;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;

        public frmConsultaCompras()
        {
            InitializeComponent();
            this.txtIdproveedor.Visible = false;
            this.txtIdarticulo.Visible = false;
            this.txtProveedor.ReadOnly = true;
            this.txtSerie.ReadOnly = true;
            this.txtCorrelativo.ReadOnly = true;
            this.txtIgv.ReadOnly = true;
            this.dtFecha.Enabled = false;
            this.txtIdingreso.ReadOnly = true;
            this.cbTipo_Comprobante.Enabled = false;
        }

        private void frmConsultaCompras_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.crearTabla();
            lenguaje(idioma);

        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = nDetalle_Ingreso.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text =  Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarFechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = nDetalle_Ingreso.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"),
                this.dtFecha2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text =  Convert.ToString(dataListado.Rows.Count);
        }

        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = nDetalle_Ingreso.MostrarDetalle(this.txtIdingreso.Text);

        }
        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Impuesto", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }
        private void lenguaje(string idioma)
        {

            ResXResourceReader rsxr = new ResXResourceReader(@".\" + idioma + ".resx");
            ListarControles();
            // Iterate through the resources and display the contents to the console.
            foreach (DictionaryEntry d in rsxr)
            {

                foreach (TabPage x in allItems)
                {

                    if (x.Tag.ToString() == d.Key.ToString())
                    {





                        x.Text = d.Value.ToString();



                    }


                }


                foreach (Control x in ctrl)
                {



                    if (x.Tag.ToString() == d.Key.ToString())
                    {





                        x.Text = d.Value.ToString();



                    }





                }

            }



        }
        private void ListarControles()
        {
            allItems.Add(tabPage1);
            allItems.Add(tabPage2);
            ctrl.Add(label2);
            ctrl.Add(label1);
            ctrl.Add(label4);
         
            ctrl.Add(btnBuscar);
    

   
            ctrl.Add(label2);
            ctrl.Add(groupBox1);
            ctrl.Add(label3);

            
            ctrl.Add(label6);
            ctrl.Add(label7);
            ctrl.Add(label8);
            ctrl.Add(label9);
            ctrl.Add(label10);
            ctrl.Add(label11);

            ctrl.Add(label16);




        }

    }
}
