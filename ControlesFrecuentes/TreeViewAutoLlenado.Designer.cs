namespace CapaPresentacion.ControlesFrecuentes
{
    partial class TreeViewAutoLlenado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeViewAutoLlenado));
            this.cmsGridPitagoras = new ControlesPersonalizados.CMSGridPitagoras(this.components);
            this.menuCrearNodoRaiz = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCrearNodoHijo = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.pictureCargando = new System.Windows.Forms.PictureBox();
            this.cmsGridPitagoras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCargando)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsGridPitagoras
            // 
            this.cmsGridPitagoras.IndexColumn = 0;
            this.cmsGridPitagoras.IndexRow = 0;
            this.cmsGridPitagoras.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCrearNodoRaiz,
            this.menuCrearNodoHijo});
            this.cmsGridPitagoras.Name = "cmsGridPitagoras";
            this.cmsGridPitagoras.Size = new System.Drawing.Size(161, 48);
            // 
            // menuCrearNodoRaiz
            // 
            this.menuCrearNodoRaiz.Name = "menuCrearNodoRaiz";
            this.menuCrearNodoRaiz.Size = new System.Drawing.Size(160, 22);
            this.menuCrearNodoRaiz.Text = "Crear Nodo Raiz";
            // 
            // menuCrearNodoHijo
            // 
            this.menuCrearNodoHijo.Name = "menuCrearNodoHijo";
            this.menuCrearNodoHijo.Size = new System.Drawing.Size(160, 22);
            this.menuCrearNodoHijo.Text = "Crear Nodo Hijo";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Carpeta.png");
            this.imageList.Images.SetKeyName(1, "Carpeta Abierta.png");
            this.imageList.Images.SetKeyName(2, "Hola.png");
            // 
            // pictureCargando
            // 
            this.pictureCargando.Image = global::CapaPresentacion.Properties.Resources.cargando_loading_029;
            this.pictureCargando.Location = new System.Drawing.Point(0, 0);
            this.pictureCargando.Name = "pictureCargando";
            this.pictureCargando.Size = new System.Drawing.Size(10, 10);
            this.pictureCargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureCargando.TabIndex = 0;
            this.pictureCargando.TabStop = false;
            // 
            // TreeViewAutoLlenado
            // 
            this.LineColor = System.Drawing.Color.Black;
            this.cmsGridPitagoras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureCargando)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ControlesPersonalizados.CMSGridPitagoras cmsGridPitagoras;
        private System.Windows.Forms.ToolStripMenuItem menuCrearNodoRaiz;
        private System.Windows.Forms.ToolStripMenuItem menuCrearNodoHijo;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.PictureBox pictureCargando;
    }
}
