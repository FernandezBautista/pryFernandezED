using System;
using System.IO;
using System.Windows.Forms;

namespace pryFernandezED
{
    internal class clsArchivoTexto
    {
        public string NombreArchivo = "";

        public void Guardar()
        {
            StreamWriter sw = new StreamWriter(NombreArchivo, true);
            sw.WriteLine("Rojo");
            sw.Close();
        }

        public void Guardar(string Nombre)
        {
            StreamWriter sw = new StreamWriter(NombreArchivo, true);
            sw.WriteLine(Nombre);
            sw.Close();
        }

        public void Guardar(string dato1, string dato2, string dato3)
        {
            StreamWriter sw = new StreamWriter(NombreArchivo, true);

            sw.Write(dato1);
            sw.Write(";");
            sw.Write(dato2);
            sw.Write(";");
            sw.WriteLine(dato3);

            sw.Close();
        }

        public void Recorrer(ListBox lst)
        {
            string datoLeido;

            lst.Items.Clear();

            StreamReader sr = new StreamReader(NombreArchivo);

            datoLeido = sr.ReadLine();

            while (datoLeido != null)
            {
                lst.Items.Add(datoLeido);
                datoLeido = sr.ReadLine();
            }

            sr.Close();
        }

        public void Recorrer(ComboBox lst)
        {
            string datoLeido;

            lst.Items.Clear();

            StreamReader sr = new StreamReader(NombreArchivo);

            datoLeido = sr.ReadLine();

            while (datoLeido != null)
            {
                lst.Items.Add(datoLeido);
                datoLeido = sr.ReadLine();
            }

            sr.Close();

            if (lst.Items.Count > 0)
            {
                lst.SelectedIndex = 0;
            }
        }

        public void Recorrer(DataGridView Grilla)
        {
            string datoLeido;

            Grilla.Rows.Clear();

            StreamReader sr = new StreamReader(NombreArchivo);

            datoLeido = sr.ReadLine();

            while (datoLeido != null)
            {
                Grilla.Rows.Add(datoLeido.Split(';'));
                datoLeido = sr.ReadLine();
            }

            sr.Close();
        }
    }
}