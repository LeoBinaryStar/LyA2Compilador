using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Latython
{
    public partial class FormMostrarErrores : Form
    {
        public static List<string> ListaErrores = new List<string>();

        public FormMostrarErrores()
        {
            InitializeComponent();
        }

        private void gridError_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Text = "Error al compilar ";
            if (ListaErrores.Count != 0)
            {
                for (int i = 0; i < ListaErrores.Count; i++)
                {
                    gridError.Rows.Add();
                    gridError[0, i].Value = (i + 1);
                    gridError[1, i].Value = ListaErrores[i].ToString();
                }
            }
        }
    }
}
