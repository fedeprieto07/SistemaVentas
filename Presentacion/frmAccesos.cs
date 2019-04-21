using ArquitecturaBase;
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
    public partial class frmAccesos : Form
    {

        List<Control> ctrl = new List<Control>();
        List<TabPage> allItems = new List<TabPage>();
        private bool IsNuevo = false;
        public string idioma;
        private bool IsEditar = false;
        accesos acc = new accesos();
        private void Mostrar()
        {
            this.dataListado.DataSource = acc.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = Convert.ToString(dataListado.Rows.Count);
        }

        private void mostrar_todas_politiacas() {

            this.dataGridView3.DataSource = acc.Mostrar_politicas();
            this.OcultarColumnas3();

        }
        
        private void Mostrar_politicas(int id_acceso)
        {
            this.dataGridView2.DataSource = acc.Mostrar_Accesos_politicas(id_acceso);
            
            
        }
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
        }
        private void OcultarColumnas3()
        {
            this.dataGridView3.Columns[0].Visible = false;
            this.dataGridView3.Columns[1].Visible = false;
            

        }

        private void OcultarColumnas2()
        {
            this.dataGridView2.Columns[0].Visible = false;
            this.dataGridView2.Columns[1].Visible = false;
            this.dataGridView2.Columns[2].Visible = false;
        }


        public frmAccesos()
        {
            InitializeComponent();
        }

        private void frmAccesos_Load(object sender, EventArgs e)
        {
            lenguaje(idioma);
            Mostrar();
            this.Habilitar(false);
            this.Botones();
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdcategoria.Text = string.Empty;
        }

        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.txtIdcategoria.ReadOnly = !valor;
        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) //Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {

            this.txtIdcategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["id_acceso"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre_acceso"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
            Mostrar_politicas(Convert.ToInt32( this.dataListado.CurrentRow.Cells["id_acceso"].Value));
            this.tabControl1.SelectedIndex = 1;
            OcultarColumnas2();
            mostrar_todas_politiacas();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.dataGridView2.Columns[0].Visible = true;
            }
            else
            {
                this.dataGridView2.Columns[0].Visible = false;
            }
        }
        private void ListarControles()
        {
            allItems.Add(tabPage1);
            allItems.Add(tabPage2);
            allItems.Add(tabPage3);
            allItems.Add(tabPage4);
            ctrl.Add(label1);
            ctrl.Add(chkEliminar);
            ctrl.Add(checkBox2);
            ctrl.Add(checkBox1);
            ctrl.Add(btnBuscar);
            ctrl.Add(btnEliminar);

            ctrl.Add(btnGuardar);
            ctrl.Add(btnEditar);
            ctrl.Add(btnCancelar);
            ctrl.Add(btnNuevo);
            ctrl.Add(label2);
            ctrl.Add(groupBox1);
            ctrl.Add(label3);
            ctrl.Add(label6);
            ctrl.Add(label5);

            ctrl.Add(label4);



        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["Eliminar1"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataGridView2.Rows[e.RowIndex].Cells["Eliminar1"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    int id_acceso;
                    int id_politica;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataGridView2.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            id_acceso = Convert.ToInt32(row.Cells[1].Value);
                            id_politica = Convert.ToInt32(row.Cells[2].Value);




                            Rpta = acc.Eliminar_acceso_politica(id_acceso,id_politica);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Eliminó Correctamente el registro");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.Mostrar_politicas(Convert.ToInt32( txtIdcategoria.Text));
                    this.dataGridView2.Columns[0].Visible = false;
                    checkBox1.Checked = false;  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView3.Columns["agregarchk"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataGridView3.Rows[e.RowIndex].Cells["agregarchk"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                this.dataGridView3.Columns[0].Visible = true;
            }
            else
            {
                this.dataGridView3.Columns[0].Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Agregar los Registros", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    int id_acceso;
                    int id_politica;
                    string Rpta = "";
                    bool Rpta_check;
                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            id_acceso =Convert.ToInt32( txtIdcategoria.Text);
                            id_politica = Convert.ToInt32(row.Cells[1].Value);

                            

                          //  if (Rpta_check == true)
                        //    {
                              Rpta = acc.Agregar_acceso_politica(id_acceso, id_politica);
                        //    }
                         //   else if (Rpta_check == false) {
                         //       Rpta = "Exists";
                        //    }

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Agrego Correctamente el registro");
                            }
                            else if (Rpta.Equals("Exists"))
                            {
                                this.MensajeError("El acceso ya tiene la politica seleccionada");
                            }
                            else {

                                this.MensajeError(Rpta);
                            }

                        }
                    }
                    this.dataGridView3.Columns[0].Visible = false;
                    checkBox2.Checked = false;
                    this.Mostrar_politicas(Convert.ToInt32(txtIdcategoria.Text));
                    this.tabControl2.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!this.txtIdcategoria.Text.Equals(""))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    errorIcono.SetError(txtNombre, "Ingrese un Nombre");
                }
                else
                {
                    
                    if (this.IsNuevo)
                    {
                        rpta = acc.Insertar_acceso(this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim());

                    }
                    else
                    {
                        rpta = acc.Editar_acceso(Convert.ToInt32(this.txtIdcategoria.Text),
                            this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim());
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
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
