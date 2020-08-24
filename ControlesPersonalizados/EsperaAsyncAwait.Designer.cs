namespace ControlesPersonalizados
{
    partial class EsperaAsyncAwait
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EsperaAsyncAwait));
            this.pbCargando = new System.Windows.Forms.PictureBox();
            this.plSuperior = new System.Windows.Forms.Panel();
            this.flp = new System.Windows.Forms.FlowLayoutPanel();
            this.plProgreso = new System.Windows.Forms.Panel();
            this.pbPrincipal = new System.Windows.Forms.ProgressBar();
            this.lbMensaje = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.il = new System.Windows.Forms.ImageList(this.components);
            this.lbMensajeSuperior = new ControlesPersonalizados.LabelPitagoras();
            this.lbProgreso = new ControlesPersonalizados.LabelPitagoras();
            this.btnAbrirRegistro = new ControlesPersonalizados.ButtonPitagoras();
            ((System.ComponentModel.ISupportInitialize)(this.pbCargando)).BeginInit();
            this.flp.SuspendLayout();
            this.plProgreso.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbCargando
            // 
            this.pbCargando.Image = global::ControlesPersonalizados.Properties.Resources.cargando;
            this.pbCargando.Location = new System.Drawing.Point(3, 285);
            this.pbCargando.Name = "pbCargando";
            this.pbCargando.Size = new System.Drawing.Size(500, 39);
            this.pbCargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbCargando.TabIndex = 3;
            this.pbCargando.TabStop = false;
            // 
            // plSuperior
            // 
            this.plSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(202)))), ((int)(((byte)(249)))));
            this.plSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.plSuperior.Location = new System.Drawing.Point(0, 0);
            this.plSuperior.Name = "plSuperior";
            this.plSuperior.Size = new System.Drawing.Size(555, 24);
            this.plSuperior.TabIndex = 4;
            // 
            // flp
            // 
            this.flp.AutoSize = true;
            this.flp.Controls.Add(this.lbMensajeSuperior);
            this.flp.Controls.Add(this.plProgreso);
            this.flp.Controls.Add(this.lbMensaje);
            this.flp.Controls.Add(this.panel1);
            this.flp.Controls.Add(this.pbCargando);
            this.flp.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp.Location = new System.Drawing.Point(23, 43);
            this.flp.Name = "flp";
            this.flp.Size = new System.Drawing.Size(510, 327);
            this.flp.TabIndex = 6;
            // 
            // plProgreso
            // 
            this.plProgreso.Controls.Add(this.lbProgreso);
            this.plProgreso.Controls.Add(this.pbPrincipal);
            this.plProgreso.Location = new System.Drawing.Point(3, 38);
            this.plProgreso.Name = "plProgreso";
            this.plProgreso.Size = new System.Drawing.Size(500, 60);
            this.plProgreso.TabIndex = 7;
            this.plProgreso.Visible = false;
            // 
            // pbPrincipal
            // 
            this.pbPrincipal.Location = new System.Drawing.Point(4, 3);
            this.pbPrincipal.Name = "pbPrincipal";
            this.pbPrincipal.Size = new System.Drawing.Size(455, 28);
            this.pbPrincipal.TabIndex = 0;
            // 
            // lbMensaje
            // 
            this.lbMensaje.Location = new System.Drawing.Point(3, 104);
            this.lbMensaje.MaximumSize = new System.Drawing.Size(500, 300);
            this.lbMensaje.Multiline = true;
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.ReadOnly = true;
            this.lbMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.lbMensaje.Size = new System.Drawing.Size(500, 140);
            this.lbMensaje.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAbrirRegistro);
            this.panel1.Location = new System.Drawing.Point(3, 250);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 29);
            this.panel1.TabIndex = 9;
            // 
            // il
            // 
            this.il.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("il.ImageStream")));
            this.il.TransparentColor = System.Drawing.Color.Transparent;
            this.il.Images.SetKeyName(0, "check.png");
            // 
            // lbMensajeSuperior
            // 
            this.lbMensajeSuperior.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbMensajeSuperior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMensajeSuperior.ForeColor = System.Drawing.Color.Black;
            this.lbMensajeSuperior.Location = new System.Drawing.Point(3, 0);
            this.lbMensajeSuperior.Name = "lbMensajeSuperior";
            this.lbMensajeSuperior.Size = new System.Drawing.Size(500, 35);
            this.lbMensajeSuperior.TabIndex = 2;
            this.lbMensajeSuperior.Text = "Realizando la operacion...";
            this.lbMensajeSuperior.TipoLabel = ControlesPersonalizados.LabelTipo.Normal;
            // 
            // lbProgreso
            // 
            this.lbProgreso.AutoSize = true;
            this.lbProgreso.ForeColor = System.Drawing.Color.Black;
            this.lbProgreso.Location = new System.Drawing.Point(441, 43);
            this.lbProgreso.Name = "lbProgreso";
            this.lbProgreso.Size = new System.Drawing.Size(18, 13);
            this.lbProgreso.TabIndex = 1;
            this.lbProgreso.Text = "-/-";
            this.lbProgreso.TipoLabel = ControlesPersonalizados.LabelTipo.Normal;
            // 
            // btnAbrirRegistro
            // 
            this.btnAbrirRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAbrirRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnAbrirRegistro.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbrirRegistro.Location = new System.Drawing.Point(397, 3);
            this.btnAbrirRegistro.Name = "btnAbrirRegistro";
            this.btnAbrirRegistro.Size = new System.Drawing.Size(100, 23);
            this.btnAbrirRegistro.TabIndex = 0;
            this.btnAbrirRegistro.Text = "Ver Registro";
            this.btnAbrirRegistro.UseVisualStyleBackColor = true;
            this.btnAbrirRegistro.Click += new System.EventHandler(this.btnVerRegistro_Click);
            // 
            // EsperaAsyncAwait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(555, 349);
            this.Controls.Add(this.flp);
            this.Controls.Add(this.plSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EsperaAsyncAwait";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cargando";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EsperaAsyncAwait_FormClosed);
            this.Load += new System.EventHandler(this.EsperaAsyncAwait_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbCargando)).EndInit();
            this.flp.ResumeLayout(false);
            this.flp.PerformLayout();
            this.plProgreso.ResumeLayout(false);
            this.plProgreso.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelPitagoras lbMensajeSuperior;
        private System.Windows.Forms.PictureBox pbCargando;
        protected System.Windows.Forms.Panel plSuperior;
        private System.Windows.Forms.FlowLayoutPanel flp;
        private System.Windows.Forms.Panel plProgreso;
        private System.Windows.Forms.ProgressBar pbPrincipal;
        private LabelPitagoras lbProgreso;
        private System.Windows.Forms.TextBox lbMensaje;
        private System.Windows.Forms.Panel panel1;
        private ButtonPitagoras btnAbrirRegistro;
        private System.Windows.Forms.ImageList il;
    }
}