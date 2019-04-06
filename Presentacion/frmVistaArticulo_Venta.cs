using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;

namespace Presentacion
{
    public partial class frmVistaArticulo_Venta : Form
    {

        List<Control> ctrl = new List<Control>();
        List<TabPage> allItems = new List<TabPage>();
        public string idioma;
        public frmVistaArticulo_Venta()
        {
            InitializeComponent();
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método BuscarNombre
        private void MostrarArticulo_Venta_Nombre()
        {
            this.dataListado.DataSource = nVenta.MostrarArticulo_Venta_Nombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text =  Convert.ToString(dataListado.Rows.Count);
        }

        private void MostrarArticulo_Venta_Codigo()
        {
            this.dataListado.DataSource = nVenta.MostrarArticulo_Venta_Codigo(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text =  Convert.ToString(dataListado.Rows.Count);
        }


        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string par1, par2;
            decimal par3, par4;
            int par5;
            DateTime par6;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["iddetalle_ingreso"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            par3 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["precio_compra"].Value);
            par4 = Convert.ToDecimal(this.dataListado.CurrentRow.Cells["precio_venta"].Value);
            par5 = Convert.ToInt32(this.dataListado.CurrentRow.Cells["stock_actual"].Value);
            par6 = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_vencimiento"].Value);
            form.setArticulo(par1, par2, par3, par4, par5, par6);
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Codigo"))
            {
                this.MostrarArticulo_Venta_Codigo();
            }
            else if (cbBuscar.Text.Equals("Nombre"))
            {
                this.MostrarArticulo_Venta_Nombre();
            }
        }

        private void Mostrar()
        {
            MostrarArticulo_Venta_Nombre();
        }

        private void frmVistaArticulo_Venta_Load(object sender, EventArgs e)
        {
             Mostrar();
            lenguaje(idioma);

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
           

            ctrl.Add(label1);
            ctrl.Add(label2);
            ctrl.Add(btnBuscar);
   

      



        }
    }
}
