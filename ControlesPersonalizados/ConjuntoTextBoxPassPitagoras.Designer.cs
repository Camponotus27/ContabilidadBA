namespace ControlesPersonalizados
{
    partial class ConjuntoTextBoxPassPitagoras
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.check_box = new System.Windows.Forms.CheckBox();
            this.txt_pass = new ControlesPersonalizados.TextBoxPassPitagoras();
            this.SuspendLayout();
            // 
            // check_box
            // 
            this.check_box.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.check_box.AutoSize = true;
            this.check_box.Location = new System.Drawing.Point(133, 3);
            this.check_box.Margin = new System.Windows.Forms.Padding(0);
            this.check_box.Name = "check_box";
            this.check_box.Size = new System.Drawing.Size(15, 14);
            this.check_box.TabIndex = 1;
            this.check_box.UseVisualStyleBackColor = true;
            // 
            // txt_pass
            // 
            this.txt_pass.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_pass.EsBuscador = false;
            this.txt_pass.IgnorarFlujo = false;
            this.txt_pass.Location = new System.Drawing.Point(2, 1);
            this.txt_pass.Margin = new System.Windows.Forms.Padding(0);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.Size = new System.Drawing.Size(123, 20);
            this.txt_pass.TabIndex = 0;
            this.txt_pass.UseSystemPasswordChar = true;
            this.txt_pass.TextChanged += new System.EventHandler(this.txt_pass_TextChanged);
            this.txt_pass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_pass_KeyDown);
            // 
            // ConjuntoTextBoxPassPitagoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.check_box);
            this.Controls.Add(this.txt_pass);
            this.MaximumSize = new System.Drawing.Size(300, 24);
            this.Name = "ConjuntoTextBoxPassPitagoras";
            this.Size = new System.Drawing.Size(152, 22);
            this.Load += new System.EventHandler(this.ConjuntoTextBoxPassPitagoras_Load);
            this.Resize += new System.EventHandler(this.ConjuntoTextBoxPassPitagoras_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBoxPassPitagoras txt_pass;
        private System.Windows.Forms.CheckBox check_box;
    }
}
