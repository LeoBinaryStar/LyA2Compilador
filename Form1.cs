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
    public partial class Form1 : Form
    {

        private delegate void Run__();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loading();
        }

        private void loading()
        {

            new System.Threading.Thread(delegate ()
            {
                Random rand = new Random();
                System.Threading.Thread.Sleep(rand.Next(1500, 3000));
                Run__ des = new Run__(Running);
                this.Invoke(des);

            }).Start();
        }

        private void Running()
        {
            LatyDesktop desk = new LatyDesktop();
            desk.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
