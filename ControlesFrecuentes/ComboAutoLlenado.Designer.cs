namespace CapaPresentacion.ControlesFrecuentes
{
    partial class ComboAutoLlenado
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
            this.pictureCargando = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCargando)).BeginInit();
            this.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureCargando)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureCargando;
    }
}
