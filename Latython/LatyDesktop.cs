using Latython.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latython
{
    public partial class LatyDesktop : Form
    {
        public LatyDesktop()
        {
            InitializeComponent();
        }

        #region VARIABLES
        private bool EventosActivos = true;
        //private LectorSintaxis LectorSintactico;
        private Color kCommentarioColor = Color.LightGreen;
        private List<string> Tokens = new List<string>();

        private List<string> CodigoEscrito = new List<string>();
        #endregion

        #region LATYTAXIS
        struct Palabras
        {
            public string Palabra;
            public int Posicion;
            public int Longuitud;
            public override string ToString()
            {
                string str = "Word = " + Palabra + ", Position = " + Posicion + ", Length = " + Longuitud + "\n";
                return str;
            }
        };

        Palabras[] palabrasModificadas = new Palabras[4000];

        private bool TestComment(string str)
        {
            string testString = str.Trim();
            if ((testString.Length >= 2) &&
                 (testString[0] == '/') &&
                 (testString[1] == '/')
                )
                return true;

            return false;
        }

        private int ParseLine(string str)
        {
            palabrasModificadas.Initialize();
            int count = 0;
            Regex exReg = new Regex(@"\w+|[^A-Za-z0-9_ \f\t\v]", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            Match igual;

            for (igual = exReg.Match(str); igual.Success; igual = igual.NextMatch())
            {
                palabrasModificadas[count].Palabra = igual.Value;
                palabrasModificadas[count].Posicion = igual.Index;
                palabrasModificadas[count].Longuitud = igual.Length;
                count++;
            }


            return count;
        }

        private Color MostrarColor(string s, LectorSintactico lectorSintactico)
        {
            Color Color = Color.Black;

            if (lectorSintactico.IsFuncion(s))
            {
                Color = Color.Fuchsia;
            }

            if (lectorSintactico.IsLlave(s))
            {
                Color = Color.Blue;
            }

            if (lectorSintactico.IsSeparador(s))
            {
                Color = Color.DarkOrange;
            }


            return Color;
        }

        #endregion



        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void arToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private delegate void ANALIZADOR_SEMANTICO_SINTACTICO__();

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Clipboard.GetText();
            avisos.Text = "Pegando texto :D ...";
        }

        private void toolStripMenuItemCopiar_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            if (Archivos.Direccion != null) Archivos.Direccion = null;
            avisos.Text = "Bienvenido al lienzo de un nuevo codigo :0 ...";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
            avisos.Text = "Copiando texo :D ...";
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            avisos.Text = "Estamos compilando :0 ...";
            carga.Style = ProgressBarStyle.Continuous;
            carga.Overflow = ToolStripItemOverflow.Always;
            carga.Increment(100);
               //Funcion para ela analizador
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Guardar como: ",
                Filter = "Todos los archivos (*.laty) | *.laty",
                DefaultExt = "laty",
                AddExtension = true
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = saveFileDialog.FileName;
                using (StreamWriter writer = new StreamWriter(rutaArchivo))
                {
                    writer.WriteLine(richTextBox1.Text);

                }
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Guardar como: ",
                Filter = "Todos los archivos (*.laty) | *.laty",
                DefaultExt = "laty",
                AddExtension = true
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string rutaArchivo = saveFileDialog.FileName;
                using (StreamWriter writer = new StreamWriter(rutaArchivo))
                {
                    writer.WriteLine(richTextBox1.Text);

                }
            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Creditos desk = new Creditos();
            desk.Show();
            this.Hide();
        }
    }
}
