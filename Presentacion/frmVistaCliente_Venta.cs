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
    public partial class frmVistaCliente_Venta : Form
    {
        List<Control> ctrl = new List<Control>();
        List<TabPage> allItems = new List<TabPage>();
        public string idioma;
        public frmVistaCliente_Venta()
        {
            InitializeComponent();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmVenta form = frmVenta.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idcliente"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value) + " " +
                Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            form.setCliente(par1, par2);
            this.Hide();
        }

        private void frmVistaCliente_Venta_Load(object sender, EventArgs e)
        {
            lenguaje(idioma);
            Mostrar();
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = nCliente.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarApellidos
        private void BuscarApellidos()
        {
            this.dataListado.DataSource = nCliente.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text =  Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNum_Documento
        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = nCliente.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text =  Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
        }
        private void ListarControles()
        {
            allItems.Add(tabPage1);
         
            
            ctrl.Add(label1);
       
            ctrl.Add(btnBuscar);
            ctrl.Add(label2);




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
    }
}
