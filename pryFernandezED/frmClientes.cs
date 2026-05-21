using System;
using System.IO;
using System.Windows.Forms;

namespace pryFernandezED
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            bool camposVacios =
                string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDeuda.Text);

            if (camposVacios)
            {
                MessageBox.Show(
                    "Debe ingresar todos los datos para poder guardar el registro.",
                    "Faltan datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                clsArchivoTexto archivoCliente = new clsArchivoTexto();

                archivoCliente.NombreArchivo = "Clientes.csv";

                archivoCliente.Guardar(
                    txtCodigo.Text,
                    txtNombre.Text,
                    txtDeuda.Text);

                archivoCliente.Recorrer(dgvClientes);

                txtCodigo.Clear();
                txtNombre.Clear();
                txtDeuda.Clear();

                txtCodigo.Focus();
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            clsArchivoTexto archivo = new clsArchivoTexto();

            archivo.NombreArchivo = "Clientes.csv";

            if (File.Exists(archivo.NombreArchivo))
            {
                archivo.Recorrer(dgvClientes);
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}