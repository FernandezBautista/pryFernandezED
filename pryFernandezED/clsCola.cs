using System;
using System.IO;
using System.Windows.Forms;

namespace pryEDFernandezB
{
    internal class clsCola
    {
        private clsNodos primero;
        private clsNodos ultimo;

        public clsNodos Primero
        {
            get { return primero; }
            set { primero = value; }
        }

        public clsNodos Ultimo
        {
            get { return ultimo; }
            set { ultimo = value; }
        }

        public void Agregar(clsNodos Nuevo)
        {
            if (Primero == null)
            {
                Primero = Nuevo;
                Ultimo = Nuevo;
            }
            else
            {
                clsNodos aux = Ultimo;
                aux.Siguiente = Nuevo;
                Ultimo = Nuevo;
            }
        }

        public void Eliminar()
        {
            if (Primero == Ultimo)
            {
                Primero = null;
                Ultimo = null;
            }
            else
            {
                Primero = Primero.Siguiente;
            }
        }

        public void Recorrer()
        {
            clsNodos Aux = Primero;
            StreamWriter sw = new StreamWriter("Cola.txt");

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