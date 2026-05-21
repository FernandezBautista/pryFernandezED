using System;
using System.Windows.Forms;

namespace pryFernandezED
{
    public partial class frmPila : Form
    {
        public frmPila()
        {
            InitializeComponent();
        }

        clsPila pila = new clsPila();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            bool datosIngresados =
                !string.IsNullOrWhiteSpace(txtCodigo.Text) &&
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtTramite.Text);

            if (datosIngresados)
            {
                clsNodos nuevoNodo = new clsNodos();

                nuevoNodo.Codigo = Convert.ToInt32(txtCodigo.Text);
                nuevoNodo.Nombre = txtNombre.Text;
                nuevoNodo.Tramite = txtTramite.Text;

                pila.Agregar(nuevoNodo);

                pila.Recorrer(dgvPila);
                pila.Recorrer(lstPila);

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
            if (pila.Primero != null)
            {
                pila.Eliminar();

                pila.Recorrer(dgvPila);
                pila.Recorrer(lstPila);
                pila.Recorrer();
            }
            else
            {
                MessageBox.Show(
                    "No hay elementos cargados para eliminar.",
                    "Pila vacía",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool esNumero = char.IsDigit(e.KeyChar);
            bool esRetroceso = e.KeyChar == (char)Keys.Back;

            if (!esNumero && !esRetroceso)
            {
                e.Handled = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmPila_Load(object sender, EventArgs e)
        {

        }
    }
}