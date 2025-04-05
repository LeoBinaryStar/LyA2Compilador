namespace Latython
{
    partial class Creditos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Creditos));
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Britannic Bold", 21F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(156, 73);
            label1.Name = "label1";
            label1.Size = new Size(528, 31);
            label1.TabIndex = 0;
            label1.Text = "Instituto Tecnológico de San Juan del Río";
            label1.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Britannic Bold", 21F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(264, 119);
            label3.Name = "label3";
            label3.Size = new Size(324, 31);
            label3.TabIndex = 2;
            label3.Text = "Lenguajes y automátas II";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Britannic Bold", 21F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(335, 164);
            label2.Name = "label2";
            label2.Size = new Size(157, 31);
            label2.TabIndex = 3;
            label2.Text = "Compilador";
            label2.Click += label2_Click_1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft JhengHei", 21F);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(286, 281);
            label4.Name = "label4";
            label4.Size = new Size(254, 35);
            label4.TabIndex = 4;
            label4.Text = "Santos Rojas Isaac";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Microsoft JhengHei", 21F);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(200, 213);
            label5.Name = "label5";
            label5.Size = new Size(438, 35);
            label5.TabIndex = 5;
            label5.Text = "Montes Barajas Leonardo Daniel";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Microsoft JhengHei", 21F);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(349, 316);
            label6.Name = "label6";
            label6.Size = new Size(143, 35);
            label6.TabIndex = 6;
            label6.Text = "22590359";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Microsoft JhengHei", 21F);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(349, 248);
            label7.Name = "label7";
            label7.Size = new Size(143, 35);
            label7.TabIndex = 7;
            label7.Text = "21590293";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Microsoft JhengHei", 21F);
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(277, 365);
            label8.Name = "label8";
            label8.Size = new Size(275, 35);
            label8.TabIndex = 8;
            label8.Text = "Feregrino Luz María";
            // 
            // button1
            // 
            button1.BackColor = Color.Maroon;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(380, 403);
            button1.Name = "button1";
            button1.Size = new Size(75, 30);
            button1.TabIndex = 9;
            button1.Text = "Salir";
            button1.UseVisualStyleBackColor = false;
            // 
            // Creditos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            BackgroundImage = Properties.Resources.azulrosatriangulos;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Creditos";
            Text = "Creditos";
            Load += Creditos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button button1;
    }
}