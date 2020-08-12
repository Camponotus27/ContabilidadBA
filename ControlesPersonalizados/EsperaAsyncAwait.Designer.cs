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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.plSuperior = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.plMensaje = new System.Windows.Forms.Panel();
            this.plProgreso = new System.Windows.Forms.Panel();
            this.pbPrincipal = new System.Windows.Forms.ProgressBar();
            this.txtMensaje = new ControlesPersonalizados.LabelPitagoras();
            this.lbProgreso = new ControlesPersonalizados.LabelPitagoras();
            this.lbMensaje = new ControlesPersonalizados.LabelPitagoras();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.plMensaje.SuspendLayout();
            this.plProgreso.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ControlesPersonalizados.Properties.Resources.cargando;
            this.pictureBox1.Location = new System.Drawing.Point(3, 176);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.txtMensaje);
            this.flowLayoutPanel1.Controls.Add(this.plProgreso);
            this.flowLayoutPanel1.Controls.Add(this.plMensaje);
            this.flowLayoutPanel1.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(23, 43);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(510, 218);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // plMensaje
            // 
            this.plMensaje.AutoScroll = true;
            this.plMensaje.AutoSize = true;
            this.plMensaje.Controls.Add(this.lbMensaje);
            this.plMensaje.Location = new System.Drawing.Point(3, 104);
            this.plMensaje.MaximumSize = new System.Drawing.Size(1000, 200);
            this.plMensaje.MinimumSize = new System.Drawing.Size(500, 0);
            this.plMensaje.Name = "plMensaje";
            this.plMensaje.Size = new System.Drawing.Size(500, 66);
            this.plMensaje.TabIndex = 6;
            this.plMensaje.SizeChanged += new System.EventHandler(this.plMensaje_SizeChanged);
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
            // txtMensaje
            // 
            this.txtMensaje.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.ForeColor = System.Drawing.Color.Black;
            this.txtMensaje.Location = new System.Drawing.Point(3, 0);
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(500, 35);
            this.txtMensaje.TabIndex = 2;
            this.txtMensaje.Text = "Realizando la operacion...";
            this.txtMensaje.TipoLabel = ControlesPersonalizados.LabelTipo.Normal;
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
            // lbMensaje
            // 
            this.lbMensaje.AutoSize = true;
            this.lbMensaje.ForeColor = System.Drawing.Color.Black;
            this.lbMensaje.Location = new System.Drawing.Point(1, 0);
            this.lbMensaje.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.lbMensaje.MinimumSize = new System.Drawing.Size(490, 66);
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.Size = new System.Drawing.Size(490, 66);
            this.lbMensaje.TabIndex = 5;
            this.lbMensaje.TipoLabel = ControlesPersonalizados.LabelTipo.Normal;
            // 
            // EsperaAsyncAwait
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(555, 181);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.plSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EsperaAsyncAwait";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cargando";
            this.Load += new System.EventHandler(this.EsperaAsyncAwait_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.plMensaje.ResumeLayout(false);
            this.plMensaje.PerformLayout();
            this.plProgreso.ResumeLayout(false);
            this.plProgreso.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LabelPitagoras txtMensaje;
        private System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.Panel plSuperior;
        private LabelPitagoras lbMensaje;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel plMensaje;
        private System.Windows.Forms.Panel plProgreso;
        private System.Windows.Forms.ProgressBar pbPrincipal;
        private LabelPitagoras lbProgreso;
    }
}