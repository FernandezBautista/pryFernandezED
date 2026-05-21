
using pryFernandezED;
using System;
using System.IO;
using System.Windows.Forms;

namespace pryFernandezED
{
    internal class clsArbol
    {
        private clsNodos raiz;

        public clsNodos Raiz
        {
            get { return raiz; }
            set { raiz = value; }
        }

        public void Agregar(clsNodos Nuevo)
        {
            if (raiz == null)
            {
                raiz = Nuevo;
            }
            else
            {
                clsNodos aux = raiz;
                clsNodos ant = raiz;

                while (aux != null)
                {
                    ant = aux;

                    if (Nuevo.Codigo < aux.Codigo)
                    {
                        aux = aux.Anterior;
                    }
                    else
                    {
                        aux = aux.Siguiente;
                    }
                }

                if (Nuevo.Codigo < ant.Codigo)
                {
                    ant.Anterior = Nuevo;
                }
                else
                {
                    ant.Siguiente = Nuevo;
                }
            }
        }

        public clsNodos Buscar(Int32 CodigoBuscado)
        {
            return BuscarRecursivo(raiz, CodigoBuscado);
        }

        private clsNodos BuscarRecursivo(clsNodos actual,
                                         Int32 CodigoBuscado)
        {
            if (actual == null)
            {
                return null;
            }

            if (CodigoBuscado == actual.Codigo)
            {
                return actual;
            }

            if (CodigoBuscado < actual.Codigo)
            {
                return BuscarRecursivo(actual.Anterior,
                                        CodigoBuscado);
            }
            else
            {
                return BuscarRecursivo(actual.Siguiente,
                                        CodigoBuscado);
            }
        }

        public void Recorrer()
        {
            StreamWriter sw =
                new StreamWriter("Arbol.txt");

            InOrdenArchivo(raiz, sw);

            sw.Close();
        }

        private void InOrdenArchivo(clsNodos actual,
                                    StreamWriter sw)
        {
            if (actual != null)
            {
                InOrdenArchivo(actual.Anterior, sw);

                sw.WriteLine("Codigo: " + actual.Codigo);
                sw.WriteLine("Nombre: " + actual.Nombre);
                sw.WriteLine("Tramite: " + actual.Tramite);
                sw.WriteLine("");

                InOrdenArchivo(actual.Siguiente, sw);
            }
        }

        public void Recorrer(DataGridView Grilla)
        {
            Grilla.Rows.Clear();
            InOrdenGrilla(raiz, Grilla);
        }

        private void InOrdenGrilla(clsNodos actual,
                                   DataGridView Grilla)
        {
            if (actual != null)
            {
                InOrdenGrilla(actual.Anterior, Grilla);

                Grilla.Rows.Add(actual.Codigo,
                                 actual.Nombre,
                                 actual.Tramite);

                InOrdenGrilla(actual.Siguiente, Grilla);
            }
        }

        public void Recorrer(DataGridView Grilla,
                             string modo)
        {
            Grilla.Rows.Clear();

            switch (modo)
            {
                case "InOrden":
                    InOrdenGrilla(raiz, Grilla);
                    break;

                case "PreOrden":
                    PreOrden(raiz, Grilla);
                    break;

                case "PostOrden":
                    PostOrden(raiz, Grilla);
                    break;
            }
        }

        private void PreOrden(clsNodos actual,
                              DataGridView Grilla)
        {
            if (actual != null)
            {
                Grilla.Rows.Add(actual.Codigo,
                                 actual.Nombre,
                                 actual.Tramite);

                PreOrden(actual.Anterior, Grilla);
                PreOrden(actual.Siguiente, Grilla);
            }
        }

        private void PostOrden(clsNodos actual,
                               DataGridView Grilla)
        {
            if (actual != null)
            {
                PostOrden(actual.Anterior, Grilla);
                PostOrden(actual.Siguiente, Grilla);

                Grilla.Rows.Add(actual.Codigo,
                                 actual.Nombre,
                                 actual.Tramite);
            }
        }

        public void Recorrer(ListBox Lista)
        {
            Lista.Items.Clear();
            RecorrerLista(raiz, Lista);
        }

        private void RecorrerLista(clsNodos actual,
                                   ListBox Lista)
        {
            if (actual != null)
            {
                RecorrerLista(actual.Anterior, Lista);

                Lista.Items.Add(actual.Codigo);

                RecorrerLista(actual.Siguiente, Lista);
            }
        }

        public void Recorrer(ComboBox Combo)
        {
            Combo.Items.Clear();
            InOrdenCombo(raiz, Combo);
        }

        private void InOrdenCombo(clsNodos actual,
                                  ComboBox Combo)
        {
            if (actual != null)
            {
                InOrdenCombo(actual.Anterior,
                             Combo);

                Combo.Items.Add(actual.Codigo);

                InOrdenCombo(actual.Siguiente,
                             Combo);
            }
        }

        public void Recorrer(ref clsNodos[] Vector)
        {
            int posicion = 0;

            InOrdenVector(raiz,
                           ref Vector,
                           ref posicion);
        }

        private void InOrdenVector(clsNodos actual,
                                   ref clsNodos[] Vector,
                                   ref int posicion)
        {
            if (actual != null)
            {
                InOrdenVector(actual.Anterior,
                              ref Vector,
                              ref posicion);

                Vector[posicion] = actual;
                posicion++;

                InOrdenVector(actual.Siguiente,
                              ref Vector,
                              ref posicion);
            }
        }

        public void Recorrer(TreeView Arbol)
        {
            Arbol.Nodes.Clear();

            if (raiz != null)
            {
                TreeNode nodoRaiz =
                    new TreeNode(
                        raiz.Codigo.ToString());

                Arbol.Nodes.Add(nodoRaiz);

                RecorrerTreeView(raiz,
                                 nodoRaiz);

                Arbol.ExpandAll();
            }
        }

        private void RecorrerTreeView(clsNodos actual,
                                      TreeNode nodoActual)
        {
            if (actual.Anterior != null)
            {
                TreeNode nodoIzq =
                    new TreeNode(
                        actual.Anterior.Codigo
                        .ToString());

                nodoActual.Nodes.Add(nodoIzq);

                RecorrerTreeView(
                    actual.Anterior,
                    nodoIzq);
            }

            if (actual.Siguiente != null)
            {
                TreeNode nodoDer =
                    new TreeNode(
                        actual.Siguiente.Codigo
                        .ToString());

                nodoActual.Nodes.Add(nodoDer);

                RecorrerTreeView(
                    actual.Siguiente,
                    nodoDer);
            }
        }
    }
}
