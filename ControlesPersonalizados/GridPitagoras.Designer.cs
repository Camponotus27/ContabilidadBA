namespace ControlesPersonalizados
{
    partial class GridPitagoras
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
            components = new System.ComponentModel.Container();


            System.Windows.Forms.DataGridViewCellStyle StyleColumnHeadersDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle StyleDefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle();

            StyleColumnHeadersDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            StyleColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            StyleColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            StyleColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            StyleColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            StyleColumnHeadersDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            StyleColumnHeadersDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHeadersDefaultCellStyle = StyleColumnHeadersDefaultCellStyle;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            StyleDefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            StyleDefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
            StyleDefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            StyleDefaultCellStyle.ForeColor = System.Drawing.Color.Navy;
            StyleDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Info;
            StyleDefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            StyleDefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DefaultCellStyle = StyleDefaultCellStyle;
            this.EnableHeadersVisualStyles = false;
            this.GridColor = System.Drawing.Color.Gainsboro;
            this.RowHeadersVisible = false;
            this.BackgroundColor = System.Drawing.SystemColors.Window;
        }

        #endregion
    }
}
