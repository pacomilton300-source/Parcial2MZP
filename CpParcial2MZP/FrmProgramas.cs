using ClnParcial2MZP;
using CadParcial2MZP;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace CpParcial2MZP

{
    public partial class FrmProgramas : Form
    {


        public FrmProgramas()
        {
            InitializeComponent();
        }

        private void FrmProgramas_Load(object sender, EventArgs e)
        {
            dgvLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvLista.MultiSelect = false;

            dgvLista.DataSource = new ProgramaCln().listar();

            cargarCanales();

            cargarCategorias();

                Size = new Size(1047, 504);
        }
        private bool validar()
        {
            if (txtTitulo.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese el título");
                return false;
            }

            if (txtDuracion.Text.Trim() == "")
            {
                MessageBox.Show("Ingrese la duración");
                return false;
            }

            return true;
        }

        private void lblProductor_Click(object sender, EventArgs e)
        {

        }
        private void cargarCanales()
        {
            BoxCanal.DataSource = new CanalCln().listar();

            BoxCanal.DisplayMember = "nombre";
            BoxCanal.ValueMember = "id";
        }

        private void cargarCategorias()
        {
            BoxCategoria.DataSource = new CategoriaProgramaCln().listar();

            BoxCategoria.DisplayMember = "nombre";
            BoxCategoria.ValueMember = "id";
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var programa = new Programa()
                {
                    idCanal = (int)BoxCanal.SelectedValue,
                    idCategoriaPrograma = (int)BoxCategoria.SelectedValue,
                    titulo = txtTitulo.Text.Trim(),
                    descripcion = txtDescripcion.Text.Trim(),
                    duracion = Convert.ToInt32(txtDuracion.Text),
                    productor = txtProductor.Text.Trim(),
                    fechaEstreno = dtFechaEstreno.Value,
                    estado = 1
                };

                new ProgramaCln().insertar(programa);

                dgvLista.DataSource = new ProgramaCln().listar();

                MessageBox.Show("Programa guardado correctamente");
            }


        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)

        {
            BoxCanal.SelectedValue = dgvLista.CurrentRow.Cells["idCanal"].Value;

            BoxCategoria.SelectedValue = dgvLista.CurrentRow.Cells["idCategoriaPrograma"].Value;

            txtTitulo.Text = dgvLista.CurrentRow.Cells["titulo"].Value.ToString();

            txtDescripcion.Text = dgvLista.CurrentRow.Cells["descripcion"].Value.ToString();

            txtDuracion.Text = dgvLista.CurrentRow.Cells["duracion"].Value.ToString();

            txtProductor.Text = dgvLista.CurrentRow.Cells["productor"].Value.ToString();

            dtFechaEstreno.Value = Convert.ToDateTime(
                dgvLista.CurrentRow.Cells["fechaEstreno"].Value
            );

        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (validar())
            {
                var programa = new Programa()
                {
                    id = Convert.ToInt32(
                 dgvLista.CurrentRow.Cells["id"].Value
             ),

                    idCanal = (int)BoxCanal.SelectedValue,
                    idCategoriaPrograma = (int)BoxCategoria.SelectedValue,
                    titulo = txtTitulo.Text.Trim(),
                    descripcion = txtDescripcion.Text.Trim(),
                    duracion = Convert.ToInt32(txtDuracion.Text),
                    productor = txtProductor.Text.Trim(),
                    fechaEstreno = dtFechaEstreno.Value
                };

                new ProgramaCln().actualizar(programa);

                dgvLista.DataSource = new ProgramaCln().listar();

                MessageBox.Show("Programa actualizado correctamente");

                Size = new Size(1047, 731);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

            Size = new Size(1047, 731);

            BoxCanal.SelectedIndex = 0;

            BoxCategoria.SelectedIndex = 0;

            txtTitulo.Clear();

            txtDescripcion.Clear();

            txtDuracion.Clear();

            txtProductor.Clear();

            dtFechaEstreno.Value = DateTime.Now;

            txtTitulo.Focus();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(1047, 504);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
        
            int id = Convert.ToInt32(
                dgvLista.CurrentRow.Cells["id"].Value
            );

            DialogResult resp = MessageBox.Show(
                "¿Desea eliminar el programa?",
                "::: Parcial :::",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resp == DialogResult.Yes)
            {
                new ProgramaCln().eliminar(id);

                dgvLista.DataSource = new ProgramaCln().listar();

                MessageBox.Show("Programa eliminado correctamente");

                btnNuevo.PerformClick();
            }
        }
    
    }
    
}