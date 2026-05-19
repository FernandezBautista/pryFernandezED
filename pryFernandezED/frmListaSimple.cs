using System;
using System.Windows.Forms;

namespace pryEDFernandezB
{
    public partial class frmListaSimple : Form
    {
        public frmListaSimple()
        {
            InitializeComponent();
        }

        clsListaSimple ls = new clsListaSimple();

        private void btnAgregar1_Click(object sender, EventArgs e)
        {
            bool datosCompletos =
                !string.IsNullOrWhiteSpace(txtCodigo1.Text) &&
                !string.IsNullOrWhiteSpace(txtNombre1.Text) &&
                !string.IsNullOrWhiteSpace(txtTramite1.Text);

            if (datosCompletos)
            {
                clsNodos nuevoNodo = new clsNodos();

                nuevoNodo.Codigo = Convert.ToInt32(txtCodigo1.Text);
                nuevoNodo.Nombre = txtNombre1.Text;
                nuevoNodo.Tramite = txtTramite1.Text;

                ls.Agregar(nuevoNodo);

                ls.Recorrer(dgvListaSimple1);
                ls.Recorrer(lstLista1);
                ls.Recorrer(cmbCodigo1);

                txtCodigo1.Clear();
                txtNombre1.Clear();
                txtTramite1.Clear();

                txtCodigo1.Focus();
            }
            else
            {
                MessageBox.Show(
                    "Debe completar todos los campos.",
                    "Datos faltantes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar1_Click(object sender, EventArgs e)
        {
            if (cmbCodigo1.SelectedItem == null)
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
                    Convert.ToInt32(cmbCodigo1.SelectedItem);

                ls.Eliminar(codigoSeleccionado);

                ls.Recorrer(dgvListaSimple1);
                ls.Recorrer(lstLista1);
                ls.Recorrer(cmbCodigo1);

                MessageBox.Show(
                    "El elemento fue eliminado correctamente.",
                    "Operación realizada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void txtCodigo1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool esNumero = char.IsDigit(e.KeyChar);
            bool esBorrar = e.KeyChar == (char)Keys.Back;

            if (!esNumero && !esBorrar)
            {
                e.Handled = true;
            }
        }

        private void frmListaSimple_Load(object sender, EventArgs e)
        {

        }
    }
}