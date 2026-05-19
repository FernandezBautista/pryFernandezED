using System;
using System.Windows.Forms;

namespace pryEDFernandezB
{
    public partial class frmAlumnos : Form
    {
        public frmAlumnos()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            bool datosIncompletos =
                string.IsNullOrWhiteSpace(txtCodigo.Text) ||
                string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCarrera.Text);

            if (datosIncompletos)
            {
                MessageBox.Show(
                    "Debe completar todos los datos antes de continuar.",
                    "Datos incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            else
            {
                clsArchivoTexto archivoAlumno = new clsArchivoTexto();

                archivoAlumno.NombreArchivo = "ListadoAlumnos.csv";

                archivoAlumno.Guardar(
                    txtCodigo.Text,
                    txtNombre.Text,
                    txtCarrera.Text);

                archivoAlumno.Recorrer(dgvAlumnos);

                MessageBox.Show(
                    "Los datos del alumno fueron registrados correctamente.",
                    "Registro guardado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtCodigo.Clear();
                txtNombre.Clear();
                txtCarrera.Clear();

                txtCodigo.Focus();
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void frmAlumnos_Load(object sender, EventArgs e)
        {

        }
    }
}