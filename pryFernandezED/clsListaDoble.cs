using System;
using System.IO;
using System.Windows.Forms;

namespace pryEDFernandezB
{
    internal class clsListaDoble
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
            if (primero == null)
            {
                primero = Nuevo;
                ultimo = Nuevo;
            }
            else
            {
                if (Nuevo.Codigo <= primero.Codigo)
                {
                    Nuevo.Siguiente = primero;
                    primero.Anterior = Nuevo;
                    primero = Nuevo;
                }
                else
                {
                    if (Nuevo.Codigo >= ultimo.Codigo)
                    {
                        ultimo.Siguiente = Nuevo;
                        Nuevo.Anterior = ultimo;
                        ultimo = Nuevo;
                    }
                    else
                    {
                        clsNodos aux = primero;
                        clsNodos anterior = primero;

                        while (aux.Codigo < Nuevo.Codigo)
                        {
                            anterior = aux;
                            aux = aux.Siguiente;
                        }

                        anterior.Siguiente = Nuevo;
                        Nuevo.Siguiente = aux;
                        aux.Anterior = Nuevo;
                        Nuevo.Anterior = anterior;
                    }
                }
            }
        }

        public void Recorrer()
        {
            clsNodos Aux = Primero;
            StreamWriter sw = new StreamWriter("ListaDoble.txt");

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

        public void RecorrerDesc()
        {
            clsNodos Aux = Ultimo;

            StreamWriter sw = new StreamWriter("ListaDobleDesc.txt");

            while (Aux != null)
            {
                sw.WriteLine("Codigo: " + Aux.Codigo);
                sw.WriteLine("Nombre: " + Aux.Nombre);
                sw.WriteLine("Tramite: " + Aux.Tramite);
                sw.WriteLine("");

                Aux = Aux.Anterior;
            }

            sw.Close();
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

        public void Eliminar(Int32 Codigo)
        {
            if (primero.Codigo == Codigo && primero == ultimo)
            {
                primero = null;
                ultimo = null;
            }
            else
            {
                if (primero.Codigo == Codigo)
                {
                    primero = primero.Siguiente;
                    primero.Anterior = null;
                }
                else
                {
                    if (ultimo.Codigo == Codigo)
                    {
                        ultimo = ultimo.Anterior;
                        ultimo.Siguiente = null;
                    }
                    else
                    {
                        clsNodos aux = primero;
                        clsNodos anterior = primero;

                        while (aux.Codigo != Codigo)
                        {
                            anterior = aux;
                            aux = aux.Siguiente;
                        }

                        aux = aux.Siguiente;
                        aux.Anterior = anterior;
                        anterior.Siguiente = aux;
                    }
                }
            }
        }

        public void RecorrerDesc(DataGridView Grilla)
        {
            clsNodos Aux = Ultimo;

            Grilla.Rows.Clear();

            while (Aux != null)
            {
                Grilla.Rows.Add(Aux.Codigo, Aux.Nombre, Aux.Tramite);
                Aux = Aux.Anterior;
            }
        }

        public void RecorrerDesc(ListBox Lista)
        {
            clsNodos Aux = Ultimo;

            Lista.Items.Clear();

            while (Aux != null)
            {
                Lista.Items.Add(Aux.Codigo);
                Aux = Aux.Anterior;
            }
        }

        public void RecorrerDesc(ComboBox Combo)
        {
            clsNodos Aux = Ultimo;

            Combo.Items.Clear();

            while (Aux != null)
            {
                Combo.Items.Add(Aux.Codigo);
                Aux = Aux.Anterior;
            }
        }
    }
}