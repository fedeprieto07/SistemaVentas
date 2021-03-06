﻿using ArquitecturaBase;
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

namespace Presentacion
{
    public partial class frmPrincipal : Form
    {
        List<Control> ctrl = new List<Control>();
        List<ToolStripMenuItem> allItems = new List<ToolStripMenuItem>();

        private int childFormNumber = 0;

        public string Idtrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";
        public string idioma = "";
        public List<String> Lista_Politicas = new List<String>();

        public frmPrincipal()
        {

            InitializeComponent();



        }




        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulo frm = frmArticulo.GetInstancia();
            frm.MdiParent = this;
            frm.idioma = idioma;
            frm.Show();
        }



        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void categoríasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategoria frm = new frmCategoria();
            frm.MdiParent = this;
            frm.idioma = idioma;
            frm.Show();

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            AgregarControles();
            GestionUsuario();
            lenguaje(idioma);





        }
        public IEnumerable<Control> GetAll(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl)).Concat(controls);
        }
        private void presentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPresentacion frm = new frmPresentacion();
            frm.MdiParent = this;
            frm.idioma = idioma;
            frm.Show();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor frm = new frmProveedor();
            frm.MdiParent = this;
            frm.idioma = idioma;
            frm.Show();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrabajador frm = new frmTrabajador();
            frm.MdiParent = this;
            frm.idioma = idioma;
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.MdiParent = this;
            frm.idioma = idioma;
            frm.Show();
        }

        private void AgregarControles()
        {
            allItems.Add(salirToolStripMenuItem);
            allItems.Add(MnuSistema);
            allItems.Add(MnuAlmacen);
            allItems.Add(artículosToolStripMenuItem);
            allItems.Add(categoríasToolStripMenuItem);
            allItems.Add(presentacionesToolStripMenuItem);
            allItems.Add(ingresosToolStripMenuItem);
            allItems.Add(proveedorToolStripMenuItem);
            allItems.Add(MnuVentas);
            allItems.Add(ventasToolStripMenuItem1);
            allItems.Add(clientesToolStripMenuItem);
            allItems.Add(MnuMantenimiento);
            allItems.Add(trabajadoresToolStripMenuItem);
            allItems.Add(MnuConsultas);
            allItems.Add(MnuCompras);
            allItems.Add(ventasPorFechasToolStripMenuItem);
            allItems.Add(comprasPorFechasToolStripMenuItem);
            allItems.Add(stockDeArtículosToolStripMenuItem);
            allItems.Add(MnuHerramientas);
            allItems.Add(optionsToolStripMenuItem);
            allItems.Add(helpMenu);
            allItems.Add(indexToolStripMenuItem);
            allItems.Add(aboutToolStripMenuItem);
            allItems.Add(comprasPorFechasToolStripMenuItem);
            allItems.Add(agregarLenguajeToolStripMenuItem1);
            allItems.Add(administrarAccesosToolStripMenuItem);

        }

        private void GestionUsuario()
        {
            this.MnuAlmacen.Enabled = false;
            this.MnuCompras.Enabled = false;
            this.MnuVentas.Enabled = false;
            this.MnuMantenimiento.Enabled = false;
            this.MnuConsultas.Enabled = false;
            this.MnuHerramientas.Enabled = false;
            this.TsCompras.Enabled = false;
            this.TsVentas.Enabled = false;
            this.MnuSistema.Enabled = false;

            foreach (var politica in Lista_Politicas)
            {
                if (politica == "politica_almacen") { this.MnuAlmacen.Enabled = true; }
                if (politica == "politica_compras") { this.MnuCompras.Enabled = true; }
                if (politica == "politica_ventas") { this.MnuVentas.Enabled = true; }
                if (politica == "politica_mantenimiento") { this.MnuMantenimiento.Enabled = true; }
                if (politica == "politica_consultas") { this.MnuConsultas.Enabled = true; }
                if (politica == "politica_ayuda") { this.helpMenu.Enabled = true; }
                if (politica == "politica_sistema") { this.MnuSistema.Enabled = true; }

            }



        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngreso frm = frmIngreso.GetInstancia();
            frm.MdiParent = this;
            frm.idioma = idioma;
            frm.Idtrabajador = Convert.ToInt32(Idtrabajador);
            frm.Show();
        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmVenta frm = frmVenta.GetInstancia();
            frm.MdiParent = this;
            frm.Idtrabajador = Convert.ToInt32(Idtrabajador);
            frm.idioma = idioma;
            frm.Show();
        }

        private void stockDeArtículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consultas.frmConsulta_Stockcs frm = new consultas.frmConsulta_Stockcs();
            frm.MdiParent = this;
            frm.idioma = idioma;
            frm.Show();
        }

        private void comprasPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consultas.frmConsultaCompras frm = new consultas.frmConsultaCompras();
            frm.MdiParent = this;
            frm.idioma = idioma;
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
            frm.Show();

        }

        private void ventasPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consultas.frmConsultaVentas frm = new consultas.frmConsultaVentas();
            frm.MdiParent = this;
            frm.idioma = idioma;
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
            frm.Show();

        }

        private void MnuVentas_Click(object sender, EventArgs e)
        {

        }

        private void lenguaje(string idioma)
        {
            ResXResourceReader rsxr = new ResXResourceReader(@".\" + idioma + ".resx");

            // Iterate through the resources and display the contents to the console.
            foreach (DictionaryEntry d in rsxr)
            {


                foreach (ToolStripMenuItem x in allItems)
                {



                    if (x.Tag.ToString() == d.Key.ToString())
                    {





                        x.Text = d.Value.ToString();



                    }





                }

            }



        }

        private void agregarLenguajeToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void agregarLenguajeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Traductor leng = new Traductor();

            string NuevoIdioma;

            NuevoIdioma = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del nuevo idioma a agregar", "Agregar Idioma", "", 100, 0);
            if (NuevoIdioma.Length == 0) {
                MessageBox.Show("se cancelo el ingreso de nuevo idioma");
                return;
            }
                

            List<String> ValueList = new List<String>();
            int count = 0;
            ResXResourceReader rsxr = new ResXResourceReader(@".\ingles.resx");

            // Iterate through the resources and display the contents to the console.
            foreach (DictionaryEntry d in rsxr)
            {

                string Value;
                Value = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la traduccion en " + NuevoIdioma + " de: " + d.Key.ToString(), "Traductor", "", 100, 0);
                ValueList.Add(Value);
                if (Value.Length == 0)
                {
                    MessageBox.Show("se cancelo el ingreso de nuevo idioma");
                    return;
                }

            }

            using (ResXResourceWriter resx = new ResXResourceWriter(@".\" + NuevoIdioma + ".resx"))
            {

                foreach (DictionaryEntry d in rsxr)
                {

                    resx.AddResource(d.Key.ToString(), ValueList[count]);
                    count = count + 1;


                }




            }

            leng.Insertar(NuevoIdioma);

            MessageBox.Show("Lenguaje creado correctamente");

        }

        private void administrarAccesosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccesos frm = new frmAccesos();
            frm.MdiParent = this;
            frm.idioma = idioma;
            frm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAcercaDe frm = new frmAcercaDe();
            frm.MdiParent = this;
          
            frm.Show();
        }
    }
   }

