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
    public partial class frmVistaArticulo_Ingreso : Form
    {
        List<Control> ctrl = new List<Control>();
        List<TabPage> allItems = new List<TabPage>();
        public string idioma;
        public frmVistaArticulo_Ingreso()
        {
            InitializeComponent();
        }

        private void frmVistaArticulo_Ingreso_Load(object sender, EventArgs e)
        {
            lenguaje(idioma);
            this.Mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[8].Visible = false;
        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = nArticulo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text =  Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = nArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = Convert.ToString(dataListado.Rows.Count);
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            frmIngreso form = frmIngreso.GetInstancia();
            string par1, par2;
            par1 = Convert.ToString(this.dataListado.CurrentRow.Cells["idarticulo"].Value);
            par2 = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            form.setArticulo(par1, par2);
            this.Hide();
        }

        private void ListarControles()
        {
            allItems.Add(tabPage1);
         
            ctrl.Add(label1);
         
            ctrl.Add(btnBuscar);

            ctrl.Add(label3);
   

      
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
