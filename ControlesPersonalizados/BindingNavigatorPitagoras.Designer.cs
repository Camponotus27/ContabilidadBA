namespace ControlesPersonalizados
{
    partial class BindingNavigatorPitagoras
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BindingNavigatorPitagoras));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnAgregar = new ControlesPersonalizados.ButtonPitagoras();
            this.btnBorrar = new ControlesPersonalizados.ButtonPitagoras();
            this.btnSubir = new ControlesPersonalizados.ButtonPitagoras();
            this.btnBajar = new ControlesPersonalizados.ButtonPitagoras();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "delete16.png");
            this.imageList1.Images.SetKeyName(1, "insert_row.png");
            this.imageList1.Images.SetKeyName(2, "new16.png");
            this.imageList1.Images.SetKeyName(3, "Triangle_34546.png");
            this.imageList1.Images.SetKeyName(4, "Triangle_down_34546.png");
            this.imageList1.Images.SetKeyName(5, "edit_clear24.png");
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.ImageIndex = 2;
            this.btnAgregar.ImageList = this.imageList1;
            this.btnAgregar.Location = new System.Drawing.Point(0, 0);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(80, 22);
            this.btnAgregar.TabIndex = 19;
            this.btnAgregar.Text = "  Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.FlatAppearance.BorderSize = 0;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBorrar.ImageIndex = 0;
            this.btnBorrar.ImageList = this.imageList1;
            this.btnBorrar.Location = new System.Drawing.Point(80, 0);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(80, 22);
            this.btnBorrar.TabIndex = 20;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnSubir
            // 
            this.btnSubir.FlatAppearance.BorderSize = 0;
            this.btnSubir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubir.ImageIndex = 3;
            this.btnSubir.ImageList = this.imageList1;
            this.btnSubir.Location = new System.Drawing.Point(160, 0);
            this.btnSubir.Name = "btnSubir";
            this.btnSubir.Size = new System.Drawing.Size(80, 22);
            this.btnSubir.TabIndex = 21;
            this.btnSubir.Text = "Subir";
            this.btnSubir.UseVisualStyleBackColor = true;
            this.btnSubir.Click += new System.EventHandler(this.btnSubir_Click);
            // 
            // btnBajar
            // 
            this.btnBajar.FlatAppearance.BorderSize = 0;
            this.btnBajar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBajar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBajar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBajar.ImageIndex = 4;
            this.btnBajar.ImageList = this.imageList1;
            this.btnBajar.Location = new System.Drawing.Point(240, 0);
            this.btnBajar.Name = "btnBajar";
            this.btnBajar.Size = new System.Drawing.Size(80, 22);
            this.btnBajar.TabIndex = 22;
            this.btnBajar.Text = "Bajar";
            this.btnBajar.UseVisualStyleBackColor = true;
            this.btnBajar.Click += new System.EventHandler(this.btnBajar_Click);
            // 
            // BindingNavigatorPitagoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.btnSubir);
            this.Controls.Add(this.btnBajar);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "BindingNavigatorPitagoras";
            this.Size = new System.Drawing.Size(323, 25);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private ButtonPitagoras btnAgregar;
        private ButtonPitagoras btnBorrar;
        private ButtonPitagoras btnSubir;
        private ButtonPitagoras btnBajar;
    }
}
