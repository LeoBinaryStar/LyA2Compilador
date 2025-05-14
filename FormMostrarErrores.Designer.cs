namespace Latython
{
    partial class FormMostrarErrores
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
            gridError = new DataGridView();
            numero = new DataGridViewTextBoxColumn();
            err = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)gridError).BeginInit();
            SuspendLayout();
            // 
            // gridError
            // 
            gridError.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridError.Columns.AddRange(new DataGridViewColumn[] { numero, err });
            gridError.Location = new Point(-2, -2);
            gridError.Name = "gridError";
            gridError.Size = new Size(548, 278);
            gridError.TabIndex = 0;
            gridError.CellContentClick += gridError_CellContentClick;
            // 
            // numero
            // 
            numero.HeaderText = "";
            numero.Name = "numero";
            // 
            // err
            // 
            err.HeaderText = "Tienes Laty errores:";
            err.MinimumWidth = 15;
            err.Name = "err";
            err.Width = 600;
            // 
            // FormMostrarErrores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 276);
            Controls.Add(gridError);
            Name = "FormMostrarErrores";
            Text = "FormMostrarErrores";
            ((System.ComponentModel.ISupportInitialize)gridError).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView gridError;
        private DataGridViewTextBoxColumn numero;
        private DataGridViewTextBoxColumn err;
    }
}