using System;
using System.IO;
using System.Windows.Forms;

namespace pryEDFernandezB
{
    internal class clsPila
    {
        private clsNodos primero;

        public clsNodos Primero
        {
            get { return primero; }
            set { primero = value; }
        }

        public void Agregar(clsNodos Nuevo)
        {
            if (primero == null)
            {
                primero = Nuevo;
            }
            else
            {
                clsNodos aux = primero;
                Nuevo.Siguiente = aux;
                primero = Nuevo;
            }
        }

        public void Eliminar()
        {
            if (primero != null)
            {
                primero = Primero.Siguiente;
            }
        }

        public void Recorrer()
        {
            clsNodos Aux = Primero;

            StreamWriter sw = new StreamWriter("Pila.txt");

            while (Aux != null)
            {
                sw.WriteLine("Codigo: " + Aux.Codigo);
                sw.WriteLine("Nombre: " + Aux.Nombre);
                sw.WriteLine("Tramite: " + Aux.Tramite);
                sw.WriteLine("");

                Aux = Aux.Siguiente;
            }

            sw.Close();
        }

        public void Recorrer(DataGridView Grilla)
        {
            clsNodos Aux = Primero;

            Grilla.Rows.Clear();

            while (Aux != null)
            {
                Grilla.Rows.Add(Aux.Codigo, Aux.Nombre, Aux.Tramite);
                Aux = Aux.Siguiente;
            }
        }

        public void Recorrer(ListBox Lista)
        {
            clsNodos Aux = Primero;

            Lista.Items.Clear();

            while (Aux != null)
            {
                Lista.Items.Add(Aux.Codigo);
                Aux = Aux.Siguiente;
            }
        }

        public void Recorrer(ComboBox Combo)
        {
            clsNodos Aux = Primero;

            Combo.Items.Clear();

            while (Aux != null)
            {
                Combo.Items.Add(Aux.Codigo);
                Aux = Aux.Siguiente;
            }
        }
    }
}