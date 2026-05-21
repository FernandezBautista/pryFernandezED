using System;
using System.IO;
using System.Windows.Forms;

namespace pryFernandezED
{
    public partial class frmColores : Form
    {
        public frmColores()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtColores.Text))
            {
                MessageBox.Show(
                    "Debe ingresar un color.",
                    "Dato requerido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            else
            {
                clsArchivoTexto archivo = new clsArchivoTexto();

                archivo.NombreArchivo = "Colores.txt";
                archivo.Guardar(txtColores.Text);

                txtColores.Clear();

                lstColores.Items.Clear();
                lstColores.Items.AddRange(
                    File.ReadAllLines(archivo.NombreArchivo));
            }
        }

        private void frmColores_Load(object sender, EventArgs e)
        {

        }
    }
}