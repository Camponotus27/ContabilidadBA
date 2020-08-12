namespace Importador_Contable_BA
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAsignarAplicacion = new System.Windows.Forms.Button();
            this.btnVerificarFormato = new ControlesPersonalizados.ButtonPitagoras();
            this.btnEliminar = new ControlesPersonalizados.ButtonPitagoras();
            this.btnBuscar = new ControlesPersonalizados.ButtonPitagoras();
            this.gridPitagoras1 = new ControlesPersonalizados.GridPitagoras();
            this.Tabla = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxPitagoras2 = new ControlesPersonalizados.ComboBoxPitagoras();
            this.comboBoxPitagoras1 = new ControlesPersonalizados.ComboBoxPitagoras();
            this.lbPathAplicacion = new ControlesPersonalizados.LabelPitagoras();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero_hojas_validas = new ControlesPersonalizados.NumberGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridPitagoras1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Brujeria ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAsignarAplicacion
            // 
            this.btnAsignarAplicacion.Location = new System.Drawing.Point(32, 362);
            this.btnAsignarAplicacion.Name = "btnAsignarAplicacion";
            this.btnAsignarAplicacion.Size = new System.Drawing.Size(117, 23);
            this.btnAsignarAplicacion.TabIndex = 1;
            this.btnAsignarAplicacion.Text = "Asignar Mov Sys";
            this.btnAsignarAplicacion.UseVisualStyleBackColor = true;
            this.btnAsignarAplicacion.Click += new System.EventHandler(this.btnAsignarAplicacion_Click);
            // 
            // btnVerificarFormato
            // 
            this.btnVerificarFormato.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerificarFormato.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnVerificarFormato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerificarFormato.Location = new System.Drawing.Point(12, 168);
            this.btnVerificarFormato.Name = "btnVerificarFormato";
            this.btnVerificarFormato.Size = new System.Drawing.Size(100, 23);
            this.btnVerificarFormato.TabIndex = 10;
            this.btnVerificarFormato.Text = "Verificar Formato";
            this.btnVerificarFormato.UseVisualStyleBackColor = true;
            this.btnVerificarFormato.Click += new System.EventHandler(this.btnVerificarFormato_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(369, 50);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 23);
            this.btnEliminar.TabIndex = 9;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(369, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gridPitagoras1
            // 
            this.gridPitagoras1.AllowUserToAddRows = false;
            this.gridPitagoras1.AllowUserToDeleteRows = false;
            this.gridPitagoras1.AutoGenerateColumns = false;
            this.gridPitagoras1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridPitagoras1.CMSGridPitagotas = null;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPitagoras1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridPitagoras1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPitagoras1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn,
            this.Numero_hojas_validas});
            this.gridPitagoras1.DataSource = this.Tabla;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPitagoras1.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridPitagoras1.EnableHeadersVisualStyles = false;
            this.gridPitagoras1.GridColor = System.Drawing.Color.Gainsboro;
            this.gridPitagoras1.Location = new System.Drawing.Point(12, 12);
            this.gridPitagoras1.MantenerPorLoMenosUnaFila = false;
            this.gridPitagoras1.Name = "gridPitagoras1";
            this.gridPitagoras1.RowHeadersVisible = false;
            this.gridPitagoras1.SePuedeCrearLieneaNuevaConEnter = true;
            this.gridPitagoras1.Size = new System.Drawing.Size(326, 150);
            this.gridPitagoras1.TabIndex = 7;
            // 
            // Tabla
            // 
            this.Tabla.DataSource = typeof(Entidades.EPath_Excel);
            // 
            // comboBoxPitagoras2
            // 
            this.comboBoxPitagoras2.FormattingEnabled = true;
            this.comboBoxPitagoras2.Items.AddRange(new object[] {
            "2000",
            "2001"});
            this.comboBoxPitagoras2.Location = new System.Drawing.Point(576, 321);
            this.comboBoxPitagoras2.Name = "comboBoxPitagoras2";
            this.comboBoxPitagoras2.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPitagoras2.TabIndex = 5;
            this.comboBoxPitagoras2.Value = ((uint)(0u));
            // 
            // comboBoxPitagoras1
            // 
            this.comboBoxPitagoras1.FormattingEnabled = true;
            this.comboBoxPitagoras1.Items.AddRange(new object[] {
            "Enero",
            "marc"});
            this.comboBoxPitagoras1.Location = new System.Drawing.Point(397, 321);
            this.comboBoxPitagoras1.Name = "comboBoxPitagoras1";
            this.comboBoxPitagoras1.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPitagoras1.TabIndex = 4;
            this.comboBoxPitagoras1.Value = ((uint)(0u));
            // 
            // lbPathAplicacion
            // 
            this.lbPathAplicacion.AutoSize = true;
            this.lbPathAplicacion.ForeColor = System.Drawing.Color.Black;
            this.lbPathAplicacion.Location = new System.Drawing.Point(166, 367);
            this.lbPathAplicacion.Name = "lbPathAplicacion";
            this.lbPathAplicacion.Size = new System.Drawing.Size(13, 13);
            this.lbPathAplicacion.TabIndex = 0;
            this.lbPathAplicacion.Text = "--";
            this.lbPathAplicacion.TipoLabel = ControlesPersonalizados.LabelTipo.Normal;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Numero_hojas_validas
            // 
            this.Numero_hojas_validas.DataPropertyName = "Numero_hojas_validas";
            this.Numero_hojas_validas.DecimalDigits = 0;
            this.Numero_hojas_validas.HeaderText = "Numero_hojas_validas";
            this.Numero_hojas_validas.Name = "Numero_hojas_validas";
            this.Numero_hojas_validas.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVerificarFormato);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.gridPitagoras1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxPitagoras2);
            this.Controls.Add(this.comboBoxPitagoras1);
            this.Controls.Add(this.btnAsignarAplicacion);
            this.Controls.Add(this.lbPathAplicacion);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPitagoras1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ControlesPersonalizados.ComboBoxPitagoras comboBoxPitagoras1;
        private ControlesPersonalizados.ComboBoxPitagoras comboBoxPitagoras2;
        private System.Windows.Forms.Button button1;
        private ControlesPersonalizados.LabelPitagoras lbPathAplicacion;
        private System.Windows.Forms.Button btnAsignarAplicacion;
        private ControlesPersonalizados.GridPitagoras gridPitagoras1;
        private ControlesPersonalizados.ButtonPitagoras btnBuscar;
        private System.Windows.Forms.BindingSource Tabla;
        private ControlesPersonalizados.ButtonPitagoras btnEliminar;
        private ControlesPersonalizados.ButtonPitagoras btnVerificarFormato;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private ControlesPersonalizados.NumberGridColumn Numero_hojas_validas;
    }
}

