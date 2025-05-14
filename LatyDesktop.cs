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
using System.Reflection;
using System.Diagnostics;
using System.Media;
using Latython.Clases;

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
        private LectorSintaxis LectorSintactico;
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

        private bool TestComment(string s)
        {
            string testString = s.Trim();
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

        private Color MostrarColor(string s)
        {
            Color Color = Color.Black;

            if (LectorSintactico.IsFuncion(s))
            {
                Color = Color.Fuchsia;
            }

            if (LectorSintactico.IsLlave(s))
            {
                Color = Color.Blue;
            }

            if (LectorSintactico.IsSeparador(s))
            {
                Color = Color.DarkOrange;
            }


            return Color;
        }
        private void SintaxisLinea()
        {
            int Inicio = richTextBox1.SelectionStart;
            int Longuitud = richTextBox1.SelectionLength;


            int pos = Inicio;
            while ((pos > 0) && (richTextBox1.Text[pos - 1] != '\n'))
                pos--;

            int pos2 = Inicio;
            while ((pos2 < richTextBox1.Text.Length) &&
                    (richTextBox1.Text[pos2] != '\n'))
                pos2++;

            string s = richTextBox1.Text.Substring(pos, pos2 - pos);
            if (TestComment(s) == true)
            {
                richTextBox1.Select(pos, pos2 - pos);
                richTextBox1.SelectionColor = kCommentarioColor;
            }
            else
            {
                string previousWord = "";
                int count = ParseLine(s);
                for (int i = 0; i < count; i++)
                {
                    Palabras wp = palabrasModificadas[i];

                    if (wp.Palabra == "/" && previousWord == "/")
                    {

                        int posCommentStart = wp.Posicion - 1;
                        int posCommentEnd = pos2;
                        while (wp.Palabra != "\n" && i < count)
                        {
                            wp = palabrasModificadas[i];
                            i++;
                        }

                        i--;
                        posCommentEnd = pos2;
                        richTextBox1.Select(posCommentStart + pos, posCommentEnd - (posCommentStart + pos));
                        richTextBox1.SelectionColor = this.kCommentarioColor;

                    }
                    else
                    {

                        Color c = MostrarColor(wp.Palabra);
                        richTextBox1.Select(wp.Posicion + pos, wp.Longuitud);
                        richTextBox1.SelectionColor = c;
                    }

                    previousWord = wp.Palabra;

                }
            }

            if (Inicio >= 0)
                richTextBox1.Select(Inicio, Longuitud);


        }

        private void CrearSintaxisColorAllText(string s)
        {
            EventosActivos = true;

            int CurrentSelectionStart = richTextBox1.SelectionStart;
            int CurrentSelectionLength = richTextBox1.SelectionLength;

            int count = ParseLine(s);
            string previousWord = "";
            for (int i = 0; i < count; i++)
            {
                Palabras wp = palabrasModificadas[i];


                if (wp.Palabra == "/" && previousWord == "/")
                {

                    int posCommentStart = wp.Posicion - 1;
                    int posCommentEnd = i;
                    while (wp.Palabra != "\n" && i < count)
                    {
                        wp = palabrasModificadas[i];
                        i++;
                    }

                    i--;

                    posCommentEnd = wp.Posicion;
                    richTextBox1.Select(posCommentStart, posCommentEnd - posCommentStart);
                    richTextBox1.SelectionColor = this.kCommentarioColor;

                }
                else
                {

                    Color c = MostrarColor(wp.Palabra);
                    richTextBox1.Select(wp.Posicion, wp.Longuitud);
                    richTextBox1.SelectionColor = c;
                }

                previousWord = wp.Palabra;
            }

            if (CurrentSelectionStart >= 0)
                richTextBox1.Select(CurrentSelectionStart, CurrentSelectionLength);

            EventosActivos = false;
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

        #region Inicializadores

        private delegate void ANALIZADOR_SEMANTICO_SINTACTICO__();

        private void GetCodigoEscrito()
        {
            try
            {
                string[] data = richTextBox1.Lines;
                CodigoEscrito = new List<string>();
                CodigoEscrito.AddRange(data);
            }
            catch { }
        }

        private void CodigoInicio()
        {
            string[] codigo = new string[]
            {
                "espacio LatyDesktop",
                "{",
                "     usar sistema;",
                "     usar sistema.coleccion;",
                "     usar sistema.componentes;",

                "     publico clase laty",
                "     {",
                "       laty_inicio()",
                "       {",
                "       }",
                "     }",
                "}"
            };
            richTextBox1.Lines = codigo;
        }

        #endregion

        private void LatyDesktop_Load(object sender, EventArgs e)
        {
            LectorSintactico = new LectorSintaxis("laty.syntax");
            CodigoInicio();
            this.CrearSintaxisColorAllText(richTextBox1.Text);
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            this.Text = "LATY# V" + version;
            this.richTextBox1.AcceptsTab = true;
        }

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
            System.Threading.Thread hilo = 
                new System.Threading.Thread(delegate()
                {
                    ANALIZADOR_SEMANTICO_SINTACTICO__ analizador = new ANALIZADOR_SEMANTICO_SINTACTICO__(ANALIZAR_COMPILAR);
                    this.Invoke(analizador);
                });
            hilo.Start();
        }

        private void ANALIZAR_COMPILAR()
        {
            Compilador compilador = new Compilador();
            AnalizadorSemantico semantico = new AnalizadorSemantico();
            List<string> CodigoComputado = new List<string>();
            System.IO.Stream str = Properties.Resources.latysound;
            SoundPlayer LatySound = new SoundPlayer(str);
            LatySound.Load();
            avisos.Text = "";
            try
            {
                carga.Increment(20);
                avisos.Text = "Analizando codigo... (20%)";
                List<string> Codigo = new List<string>();
                Codigo.AddRange(richTextBox1.Lines);
                semantico.SetCodigoAnalizar(Codigo);
                semantico.Computar(out CodigoComputado);
                carga.Increment(30);
                List<string> Errores = semantico.MostrarErrores();
                if (Errores.Count != 0)
                {
                    LatySound.Play();
                    avisos.Text = "Error al compilar... ";
                    FormMostrarErrores.ListaErrores = Errores;
                    FormMostrarErrores FrmError = new FormMostrarErrores();
                    FrmError.Show();
                    avisos.Text = "sin notificaciones...";
                    carga.Increment(100);
                    return;
                }
                string direccion = Archivos.Direccion;
                if (direccion == null || direccion == "")
                {
                    GetCodigoEscrito();
                    Archivos.Guardar(CodigoEscrito);
                    direccion = Archivos.Direccion;
                }

                string[] trozo_direccion = direccion.Split(new string[] { "\\", ".laty" }, StringSplitOptions.RemoveEmptyEntries);
                string nombre = trozo_direccion[trozo_direccion.Length - 1];
                if (nombre == "" || string.IsNullOrEmpty(nombre))
                    nombre = "Chompipe";
                avisos.Text = "Compilando... (60%)";
                carga.Increment(60);

                var d = compilador.CheckCodigoAcompilar(CodigoComputado);
                var k = compilador.GenerarCodigoCsharp(d, "__IL_SISTEMA_INT");
                List<string> ILerr = new List<string>();
                bool compilado = compilador.CompilarCodigo(k, nombre + ".exe", out ILerr);

                if (compilado)
                {
                    Process p = new Process();
                    ProcessStartInfo psi = new ProcessStartInfo(System.IO.Directory.GetCurrentDirectory() + @"\" + nombre + ".exe");
                    p.StartInfo = psi;
                    p.Start();
                    avisos.Text = "UN LATY SE HA COMPILADO... ";
                    avisos.Text = "sin notificaciones...";
                }
                else
                {
                    if (ILerr.Count >= 1)
                    {
                        FormMostrarErrores.ListaErrores = ILerr;
                        FormMostrarErrores FrmError = new FormMostrarErrores();
                        FrmError.Show();
                    }
                    LatySound.Play();
                    avisos.Text = "Compilacion exitosa pero con error en IL";
                }
                carga.Increment(100);

            }
            catch (Exception ex)
            {
                LatySound.Play();
                carga.Increment(0);
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (EventosActivos)
                return;
            ColorSyntaxEditor.FlickerFreeRichEditTextBox._Paint = false;
            SintaxisLinea();
            ColorSyntaxEditor.FlickerFreeRichEditTextBox._Paint = true;
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