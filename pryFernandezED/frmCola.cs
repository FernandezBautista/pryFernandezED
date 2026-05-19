using System;
using System.Windows.Forms;

namespace pryEDFernandezB
{
    public partial class frmCola : Form
    {
        public frmCola()
        {
            InitializeComponent();
        }

        clsCola fila = new clsCola();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool datosCompletos =
                !string.IsNullOrWhiteSpace(txtCodigo.Text) &&
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtTramite.Text);

            if (datosCompletos)
            {
                clsNodos nuevoNodo = new clsNodos();

                nuevoNodo.Codigo = Convert.ToInt32(txtCodigo.Text);
                nuevoNodo.Nombre = txtNombre.Text;
                nuevoNodo.Tramite = txtTramite.Text;

                fila.Agregar(nuevoNodo);

                fila.Recorrer(dgvCola);
                fila.Recorrer(lstCola);

                txtCodigo.Clear();
                txtNombre.Clear();
                txtTramite.Clear();

                txtCodigo.Focus();
            }
            else
            {
                MessageBox.Show(
                    "Debe completar todos los campos.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (fila.Primero == null)
            {
                MessageBox.Show(
                    "No existen elementos para eliminar.",
                    "Cola vacía",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                fila.Eliminar();

                fila.Recorrer(dgvCola);
                fila.Recorrer(lstCola);
                fila.Recorrer();
            }
        }

        private void pnlEliminado_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool esNumero = char.IsDigit(e.KeyChar);
            bool esBorrar = e.KeyChar == (char)Keys.Back;

            if (!esNumero && !esBorrar)
            {
                e.Handled = true;
            }
        }

        private void frmCola_Load(object sender, EventArgs e)
        {

        }
    }
}