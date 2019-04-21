using ArquitecturaBase;
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
    public partial class frmAccesos : Form
    {
       public string idioma;
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
            Mostrar();
        }
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            id_acceso =Convert.ToInt32( txtIdcategoria.Text);
                            id_politica = Convert.ToInt32(row.Cells[1].Value);

                            Rpta = acc.Agregar_acceso_politica(id_acceso, id_politica);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeOk("Se Agrego Correctamente el registro");
                            }
                            else
                            {
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
    }
}
