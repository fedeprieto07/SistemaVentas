﻿using System;
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

        public frmPrincipal()
        {

            InitializeComponent();
            var c = GetAll(this);

   


            foreach (Control control in c)
            {
                if (control.Tag is null)
                {
                    control.Tag = "no usado";
                }

               
                    ctrl.Add(control);
                    MessageBox.Show(control.Tag.ToString());
                



                  
                
            }


        }

      


        private void artículosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulo frm = frmArticulo.GetInstancia();
            frm.MdiParent = this;
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
            frm.Show();

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            GestionUsuario();
            lenguaje(idioma);
            MessageBox.Show(idioma);
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
            frm.Show();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedor frm = new frmProveedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTrabajador frm = new frmTrabajador();
            frm.MdiParent = this;
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.MdiParent = this;
            frm.Show();
        }


        private void GestionUsuario()
        {
            //COntrolar los accesos
            if (Acceso == "Administrador")
            {
                this.MnuAlmacen.Enabled = true;
                this.MnuCompras.Enabled = true;
                this.MnuVentas.Enabled = true;
                this.MnuMantenimiento.Enabled = true;
                this.MnuConsultas.Enabled = true;
                this.MnuHerramientas.Enabled = true;
                this.TsCompras.Enabled = true;
                this.TsVentas.Enabled = true;

            }
            else if (Acceso == "Vendedor")
            {
                this.MnuAlmacen.Enabled = false;
                this.MnuCompras.Enabled = false;
                this.MnuVentas.Enabled = true;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = true;
                this.MnuHerramientas.Enabled = true;
                this.TsCompras.Enabled = false;
                this.TsVentas.Enabled = true;

            }
            else if (Acceso == "Almacenero")
            {
                this.MnuAlmacen.Enabled = true;
                this.MnuCompras.Enabled = true;
                this.MnuVentas.Enabled = false;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = true;
                this.MnuHerramientas.Enabled = true;
                this.TsCompras.Enabled = true;
                this.TsVentas.Enabled = false;

            }
            else
            {
                this.MnuAlmacen.Enabled = false;
                this.MnuCompras.Enabled = false;
                this.MnuVentas.Enabled = false;
                this.MnuMantenimiento.Enabled = false;
                this.MnuConsultas.Enabled = false;
                this.MnuHerramientas.Enabled = false;
                this.TsCompras.Enabled = false;
                this.TsVentas.Enabled = false;

            }
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIngreso frm =  frmIngreso.GetInstancia();
            frm.MdiParent = this;
            frm.Idtrabajador = Convert.ToInt32( Idtrabajador);
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
            frm.Show();
        }

        private void comprasPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consultas.frmConsultaCompras frm = new consultas.frmConsultaCompras();
            frm.MdiParent = this;
            frm.Show();
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void ventasPorFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            consultas.frmConsultaVentas frm = new consultas.frmConsultaVentas();
            frm.MdiParent = this;
            frm.Show();
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
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


                foreach (Control x in ctrl)
                {

                    if (x.Tag.ToString() == d.Key.ToString())
                    {

                        var ctn = this.Controls.Find(x.Name, true);

                        
                            foreach (Control c in ctn)
                            {
                                c.Text = d.Value.ToString();
                            }


                        }
                    




                    }

                }



            }
        }
   }
