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

using ArquitecturaBase;



namespace Presentacion
{
    public partial class frmLogin : Form
    {
        List<Control> ctrl = new List<Control>();
        Seguridad seg = new Seguridad();
        string idioma = "espanol";
        public frmLogin()
        {
            InitializeComponent();
        
            var c = GetAll(this);
            foreach (Control control in c) {
                if (control.Tag is null)
                {
                    control.Tag = "no usado";
                }
                
                ctrl.Add(control);
            }




        }
        Bitacora bit = new Bitacora();
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            DataTable Datos = Negocio.nTrabajador.Login(this.TxtUsuario.Text, seg.encriptar(this.TxtPassword.Text));
            
            //Evaluar si existe el Usuario
            if (Datos.Rows.Count == 0)
            {
                bit.logger("Fallo un inicio de sesion", 1);
                MessageBox.Show("NO Tiene Acceso al Sistema", "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                List<String> Lista_accesos = new List<String>();

                frmPrincipal frm = new frmPrincipal();
                frm.Idtrabajador = Datos.Rows[0][0].ToString();
                frm.Apellidos = Datos.Rows[0][1].ToString();
                frm.Nombre = Datos.Rows[0][2].ToString();
                frm.Acceso = Datos.Rows[0][3].ToString();
                frm.idioma = idioma;
                accesos acc = new accesos();
                Lista_accesos = acc.list_accesps(frm.Idtrabajador);
                frm.Lista_Politicas = Lista_accesos;
              

                bit.logger("el empleado "+ Datos.Rows[0][2].ToString()+" "+ Datos.Rows[0][1].ToString() + " se logueo al sistema" , 1);
                frm.Show();
                this.Hide();

            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            LlenarComboPresentacion();
        }
        private void LlenarComboPresentacion()
        {
            Traductor trad = new Traductor();
            boxidioma.DataSource = trad.Mostrar(); 
            boxidioma.ValueMember = "IdLenguaje";
            boxidioma.DisplayMember = "Lenguaje";

        }
        public IEnumerable<Control> GetAll(Control control)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl)).Concat(controls);
        }


        private void boxidioma_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void boxidioma_Click(object sender, EventArgs e)
        {
            
        }

        private void boxidioma_TextUpdate(object sender, EventArgs e)
        {
           
        }

        private void boxidioma_SelectedValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void lenguaje(string Idioma)
        {
            ResXResourceReader rsxr = new ResXResourceReader(@".\" + Idioma + ".resx");

            // Iterate through the resources and display the contents to the console.
            foreach (DictionaryEntry d in rsxr)
            {


                foreach (Control x in ctrl)
                {

                    if (x.Tag.ToString() == d.Key.ToString())
                    {
                       
                        var ctn = this.Controls.Find(x.Name, true);

                        try
                        {
                            foreach (Control c in ctn ){
                                c.Text = d.Value.ToString();
                            }
                            

                        }
                        catch (Exception)
                        {

                            
                        }
                      



                    }

                }



            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            idioma = boxidioma.Text;
            lenguaje(boxidioma.Text);
        }
    }
}
