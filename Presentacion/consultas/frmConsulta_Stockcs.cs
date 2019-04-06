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
using System.Resources;
using System.Collections;

namespace Presentacion.consultas
{
    public partial class frmConsulta_Stockcs : Form
    {

        List<Control> ctrl = new List<Control>();
        List<TabPage> allItems = new List<TabPage>();
        public string idioma;
        public frmConsulta_Stockcs()
        {
            InitializeComponent();
        }

        private void frmConsulta_Stockcs_Load(object sender, EventArgs e)
        {
            lenguaje(idioma);
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
            lblTotal.Text =  Convert.ToString(dataListado.Rows.Count);
        }
        private void ListarControles()
        {
            allItems.Add(tabPage1);
         
            ctrl.Add(label2);
            ctrl.Add(label1);
   




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
