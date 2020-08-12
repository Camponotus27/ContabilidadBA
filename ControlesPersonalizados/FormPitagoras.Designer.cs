namespace ControlesPersonalizados
{
    partial class FormPitagoras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPitagoras));
            this.plSuperior = new System.Windows.Forms.Panel();
            this.btnMinimizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnNormal = new System.Windows.Forms.PictureBox();
            this.plInferior = new System.Windows.Forms.Panel();
            this.lbTituloFormPitagoras = new ControlesPersonalizados.LabelPitagoras();
            this.plSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNormal)).BeginInit();
            this.plInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // plSuperior
            // 
            this.plSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.plSuperior.Controls.Add(this.btnMinimizar);
            this.plSuperior.Controls.Add(this.btnCerrar);
            this.plSuperior.Controls.Add(this.btnMaximizar);
            this.plSuperior.Controls.Add(this.btnNormal);
            this.plSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.plSuperior.Location = new System.Drawing.Point(0, 0);
            this.plSuperior.Name = "plSuperior";
            this.plSuperior.Size = new System.Drawing.Size(284, 24);
            this.plSuperior.TabIndex = 0;
            this.plSuperior.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizar.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizar.Image = global::ControlesPersonalizados.Properties.Resources.Minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(212, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(24, 24);
            this.btnMinimizar.TabIndex = 3;
            this.btnMinimizar.TabStop = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(259, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(24, 24);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.BackColor = System.Drawing.Color.Transparent;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(236, 0);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(24, 24);
            this.btnMaximizar.TabIndex = 5;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnNormal
            // 
            this.btnNormal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNormal.BackColor = System.Drawing.Color.Transparent;
            this.btnNormal.Image = global::ControlesPersonalizados.Properties.Resources.Maximizar;
            this.btnNormal.Location = new System.Drawing.Point(236, 0);
            this.btnNormal.Name = "btnNormal";
            this.btnNormal.Size = new System.Drawing.Size(24, 24);
            this.btnNormal.TabIndex = 4;
            this.btnNormal.TabStop = false;
            this.btnNormal.Click += new System.EventHandler(this.btnNormal_Click);
            // 
            // plInferior
            // 
            this.plInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(222)))), ((int)(((byte)(251)))));
            this.plInferior.Controls.Add(this.lbTituloFormPitagoras);
            this.plInferior.Dock = System.Windows.Forms.DockStyle.Top;
            this.plInferior.Location = new System.Drawing.Point(0, 24);
            this.plInferior.Name = "plInferior";
            this.plInferior.Size = new System.Drawing.Size(284, 40);
            this.plInferior.TabIndex = 1;
            // 
            // lbTituloFormPitagoras
            // 
            this.lbTituloFormPitagoras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTituloFormPitagoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTituloFormPitagoras.ForeColor = System.Drawing.Color.Black;
            this.lbTituloFormPitagoras.Location = new System.Drawing.Point(0, 0);
            this.lbTituloFormPitagoras.Name = "lbTituloFormPitagoras";
            this.lbTituloFormPitagoras.Size = new System.Drawing.Size(284, 40);
            this.lbTituloFormPitagoras.TabIndex = 0;
            this.lbTituloFormPitagoras.Text = "labelPitagoras1";
            this.lbTituloFormPitagoras.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTituloFormPitagoras.TipoLabel = ControlesPersonalizados.LabelTipo.Titulo;
            this.lbTituloFormPitagoras.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // FormPitagoras
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.plInferior);
            this.Controls.Add(this.plSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormPitagoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormPitagoras_Load);
            this.plSuperior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNormal)).EndInit();
            this.plInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnNormal;
        private System.Windows.Forms.PictureBox btnMinimizar;
        protected System.Windows.Forms.Panel plSuperior;
        protected LabelPitagoras lbTituloFormPitagoras;
        protected System.Windows.Forms.Panel plInferior;
    }
}
