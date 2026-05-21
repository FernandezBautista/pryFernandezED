using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pryFernandezED
{
    public partial class frmArbol : Form
    {
        public frmArbol()
        {
            InitializeComponent();
        }

        clsArbol arbol = new clsArbol();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCodigo.Text) &&
                !string.IsNullOrWhiteSpace(txtNombre.Text) &&
                !string.IsNullOrWhiteSpace(txtTramite.Text))
            {
                clsNodos nuevo = new clsNodos();

                nuevo.Codigo = Convert.ToInt32(txtCodigo.Text);
                nuevo.Nombre = txtNombre.Text;
                nuevo.Tramite = txtTramite.Text;

                arbol.Agregar(nuevo);

                arbol.Recorrer(treeView1);

                if (opcInOrden.Checked)
                {
                    arbol.Recorrer(dgvArbol, "InOrden");
                }

                if (opcPreOrden.Checked)
                {
                    arbol.Recorrer(dgvArbol, "PreOrden");
                }

                if (opcPostOrden.Checked)
                {
                    arbol.Recorrer(dgvArbol, "PostOrden");
                }

                txtCodigo.Clear();
                txtNombre.Clear();
                txtTramite.Clear();

                txtCodigo.Focus();
            }
            else
            {
                MessageBox.Show("Complete todos los campos");
            }
        }

        private void opcInOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (opcInOrden.Checked)
            {
                arbol.Recorrer(dgvArbol, "InOrden");
            }
        }

        private void opcPreOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (opcPreOrden.Checked)
            {
                arbol.Recorrer(dgvArbol, "PreOrden");
            }
        }

        private void opcPostOrden_CheckedChanged(object sender, EventArgs e)
        {
            if (opcPostOrden.Checked)
            {
                arbol.Recorrer(dgvArbol, "PostOrden");
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) &&
                e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void frmArbol_Load(object sender, EventArgs e)
        {
            opcInOrden.Checked = true;
        }
    }
}
