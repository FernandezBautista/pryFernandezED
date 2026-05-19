using System;
using System.Windows.Forms;

namespace pryEDFernandezB
{
    public partial class frmListaDoble : Form
    {
        public frmListaDoble()
        {
            InitializeComponent();
        }

        clsListaDoble ld = new clsListaDoble();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool datosValidos =
                !string.IsNullOrWhiteSpace(txtCodigo.Text) &&
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtTramite.Text);

            if (datosValidos)
            {
                clsNodos nuevo = new clsNodos();

                nuevo.Codigo = Convert.ToInt32(txtCodigo.Text);
                nuevo.Nombre = txtNombre.Text;
                nuevo.Tramite = txtTramite.Text;

                ld.Agregar(nuevo);

                ld.Recorrer(lstListaDoble);
                ld.Recorrer(dgvListaDoble);
                ld.Recorrer(cmbCodigo);

                txtCodigo.Clear();
                txtNombre.Clear();
                txtTramite.Clear();

                txtCodigo.Focus();
            }
            else
            {
                MessageBox.Show(
                    "Debe ingresar todos los datos requeridos.",
                    "Campos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cmbCodigo.SelectedItem == null)
            {
                MessageBox.Show(
                    "Seleccione un código para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                Int32 codigoSeleccionado =
                    Convert.ToInt32(cmbCodigo.SelectedItem);

                ld.Eliminar(codigoSeleccionado);

                ld.Recorrer(dgvListaDoble);
                ld.Recorrer(lstListaDoble);
                ld.Recorrer(cmbCodigo);

                cmbCodigo.SelectedIndex = -1;
                cmbCodigo.Text = string.Empty;
            }
        }

        private void rdbDescendente_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDescendente.Checked)
            {
                ld.RecorrerDesc(dgvListaDoble);
                ld.RecorrerDesc(lstListaDoble);
            }
            else
            {
                ld.Recorrer(dgvListaDoble);
                ld.Recorrer(lstListaDoble);
            }
        }

        private void pcbPila_Click(object sender, EventArgs e)
        {

        }

        private void frmListaDoble_Load(object sender, EventArgs e)
        {

        }
    }
}