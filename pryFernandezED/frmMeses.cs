using System;
using System.IO;
using System.Windows.Forms;

namespace pryEDFernandezB
{
    public partial class frmMeses : Form
    {
        public frmMeses()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMeses.Text))
            {
                MessageBox.Show(
                    "Debe ingresar un mes.",
                    "Campo requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                clsArchivoTexto archivo = new clsArchivoTexto();

                archivo.NombreArchivo = "Meses.txt";
                archivo.Guardar(txtMeses.Text);

                txtMeses.Clear();

                lstMeses.Items.Clear();
                lstMeses.Items.AddRange(
                    File.ReadAllLines(archivo.NombreArchivo));

                txtMeses.Focus();
            }
        }

        private void frmMeses_Load(object sender, EventArgs e)
        {

        }
    }
}