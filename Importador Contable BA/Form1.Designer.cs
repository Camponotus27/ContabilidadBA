﻿namespace Importador_Contable_BA
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAsignarAplicacion = new System.Windows.Forms.Button();
            this.btnEliminar = new ControlesPersonalizados.ButtonPitagoras();
            this.btnBuscar = new ControlesPersonalizados.ButtonPitagoras();
            this.dgvExcels = new ControlesPersonalizados.GridPitagoras();
            this.nombreDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingExcel = new System.Windows.Forms.BindingSource(this.components);
            this.lbPathAplicacion = new ControlesPersonalizados.LabelPitagoras();
            this.dgvComprobantes = new ControlesPersonalizados.GridPitagoras();
            this.numerocuentaformateadaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaformateadaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numerocomprobanteformateadaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glosaFormateadaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correlativoDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ComprobantesContables = new System.Windows.Forms.BindingSource(this.components);
            this.hp = new System.Windows.Forms.HelpProvider();
            this.grInsertarDatos = new System.Windows.Forms.GroupBox();
            this.btnInsertarDatos = new ControlesPersonalizados.ButtonPitagoras();
            this.grExtraerDatos = new ControlesPersonalizados.GroupBoxPitagoras();
            this.labelPitagoras2 = new ControlesPersonalizados.LabelPitagoras();
            this.lbPrefijoNComprobante = new ControlesPersonalizados.LabelPitagoras();
            this.cmbMes = new ControlesPersonalizados.ComboBoxPitagoras();
            this.bindingCmbMeses = new System.Windows.Forms.BindingSource(this.components);
            this.btnExtraerDatos = new ControlesPersonalizados.ButtonPitagoras();
            this.cmbAnio = new ControlesPersonalizados.ComboBoxPitagoras();
            this.bindingCmbAnio = new System.Windows.Forms.BindingSource(this.components);
            this.labelPitagoras1 = new ControlesPersonalizados.LabelPitagoras();
            this.txtNComprobante = new ControlesPersonalizados.TextBoxNumeroPitagoras();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numerocuentaformateadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaformateadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numerocomprobanteformateadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glosaFormateadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.abonoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cargoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correlativoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grDatosSistema = new System.Windows.Forms.GroupBox();
            this.lpPathMovSys = new ControlesPersonalizados.LabelPitagoras();
            this.labelPitagoras3 = new ControlesPersonalizados.LabelPitagoras();
            this.btnSalvarRutEmpresa = new System.Windows.Forms.Button();
            this.labelPitagoras4 = new ControlesPersonalizados.LabelPitagoras();
            this.txtRutEmpresa = new ControlesPersonalizados.TextBoxNumeroPitagoras();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComprobantesContables)).BeginInit();
            this.grInsertarDatos.SuspendLayout();
            this.grExtraerDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingCmbMeses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingCmbAnio)).BeginInit();
            this.grDatosSistema.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAsignarAplicacion
            // 
            this.btnAsignarAplicacion.Location = new System.Drawing.Point(6, 19);
            this.btnAsignarAplicacion.Name = "btnAsignarAplicacion";
            this.btnAsignarAplicacion.Size = new System.Drawing.Size(153, 23);
            this.btnAsignarAplicacion.TabIndex = 1;
            this.btnAsignarAplicacion.Text = "Asignar Aplicacion Contable";
            this.btnAsignarAplicacion.UseVisualStyleBackColor = true;
            this.btnAsignarAplicacion.Click += new System.EventHandler(this.btnAsignarAplicacion_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(242, 44);
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
            this.btnBuscar.Location = new System.Drawing.Point(242, 15);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 23);
            this.btnBuscar.TabIndex = 8;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dgvExcels
            // 
            this.dgvExcels.AllowUserToAddRows = false;
            this.dgvExcels.AllowUserToDeleteRows = false;
            this.dgvExcels.AutoGenerateColumns = false;
            this.dgvExcels.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvExcels.CMSGridPitagotas = null;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvExcels.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvExcels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExcels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreDataGridViewTextBoxColumn1});
            this.dgvExcels.DataSource = this.bindingExcel;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExcels.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExcels.EnableHeadersVisualStyles = false;
            this.dgvExcels.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvExcels.Location = new System.Drawing.Point(12, 15);
            this.dgvExcels.MantenerPorLoMenosUnaFila = false;
            this.dgvExcels.Name = "dgvExcels";
            this.dgvExcels.RowHeadersVisible = false;
            this.dgvExcels.SePuedeCrearLieneaNuevaConEnter = true;
            this.dgvExcels.Size = new System.Drawing.Size(224, 147);
            this.dgvExcels.TabIndex = 7;
            // 
            // nombreDataGridViewTextBoxColumn1
            // 
            this.nombreDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreDataGridViewTextBoxColumn1.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn1.Name = "nombreDataGridViewTextBoxColumn1";
            this.nombreDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // bindingExcel
            // 
            this.bindingExcel.DataSource = typeof(Entidades.EPath_Excel);
            // 
            // lbPathAplicacion
            // 
            this.lbPathAplicacion.AutoSize = true;
            this.lbPathAplicacion.ForeColor = System.Drawing.Color.Black;
            this.lbPathAplicacion.Location = new System.Drawing.Point(179, 24);
            this.lbPathAplicacion.Name = "lbPathAplicacion";
            this.lbPathAplicacion.Size = new System.Drawing.Size(13, 13);
            this.lbPathAplicacion.TabIndex = 0;
            this.lbPathAplicacion.Text = "--";
            this.lbPathAplicacion.TipoLabel = ControlesPersonalizados.LabelTipo.Normal;
            this.lbPathAplicacion.Click += new System.EventHandler(this.lbPathAplicacion_Click);
            // 
            // dgvComprobantes
            // 
            this.dgvComprobantes.AllowUserToAddRows = false;
            this.dgvComprobantes.AllowUserToDeleteRows = false;
            this.dgvComprobantes.AutoGenerateColumns = false;
            this.dgvComprobantes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvComprobantes.CMSGridPitagotas = null;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComprobantes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComprobantes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numerocuentaformateadaDataGridViewTextBoxColumn1,
            this.fechaformateadaDataGridViewTextBoxColumn1,
            this.numerocomprobanteformateadaDataGridViewTextBoxColumn1,
            this.glosaFormateadaDataGridViewTextBoxColumn1,
            this.abonoDataGridViewTextBoxColumn1,
            this.cargoDataGridViewTextBoxColumn1,
            this.correlativoDataGridViewTextBoxColumn1,
            this.mesDataGridViewTextBoxColumn1});
            this.dgvComprobantes.DataSource = this.ComprobantesContables;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComprobantes.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvComprobantes.EnableHeadersVisualStyles = false;
            this.dgvComprobantes.GridColor = System.Drawing.Color.Gainsboro;
            this.dgvComprobantes.Location = new System.Drawing.Point(12, 264);
            this.dgvComprobantes.MantenerPorLoMenosUnaFila = false;
            this.dgvComprobantes.Name = "dgvComprobantes";
            this.dgvComprobantes.RowHeadersVisible = false;
            this.dgvComprobantes.SePuedeCrearLieneaNuevaConEnter = true;
            this.dgvComprobantes.Size = new System.Drawing.Size(776, 174);
            this.dgvComprobantes.TabIndex = 14;
            // 
            // numerocuentaformateadaDataGridViewTextBoxColumn1
            // 
            this.numerocuentaformateadaDataGridViewTextBoxColumn1.DataPropertyName = "Numero_cuenta_formateada";
            this.numerocuentaformateadaDataGridViewTextBoxColumn1.HeaderText = "N° Cuenta";
            this.numerocuentaformateadaDataGridViewTextBoxColumn1.Name = "numerocuentaformateadaDataGridViewTextBoxColumn1";
            this.numerocuentaformateadaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.numerocuentaformateadaDataGridViewTextBoxColumn1.Width = 90;
            // 
            // fechaformateadaDataGridViewTextBoxColumn1
            // 
            this.fechaformateadaDataGridViewTextBoxColumn1.DataPropertyName = "Fecha_formateada";
            this.fechaformateadaDataGridViewTextBoxColumn1.HeaderText = "Fecha";
            this.fechaformateadaDataGridViewTextBoxColumn1.Name = "fechaformateadaDataGridViewTextBoxColumn1";
            this.fechaformateadaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fechaformateadaDataGridViewTextBoxColumn1.Width = 80;
            // 
            // numerocomprobanteformateadaDataGridViewTextBoxColumn1
            // 
            this.numerocomprobanteformateadaDataGridViewTextBoxColumn1.DataPropertyName = "Numero_comprobante_formateada";
            this.numerocomprobanteformateadaDataGridViewTextBoxColumn1.HeaderText = "N° Comp";
            this.numerocomprobanteformateadaDataGridViewTextBoxColumn1.Name = "numerocomprobanteformateadaDataGridViewTextBoxColumn1";
            this.numerocomprobanteformateadaDataGridViewTextBoxColumn1.ReadOnly = true;
            this.numerocomprobanteformateadaDataGridViewTextBoxColumn1.Width = 80;
            // 
            // glosaFormateadaDataGridViewTextBoxColumn1
            // 
            this.glosaFormateadaDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.glosaFormateadaDataGridViewTextBoxColumn1.DataPropertyName = "Glosa_Formateada";
            this.glosaFormateadaDataGridViewTextBoxColumn1.HeaderText = "Glosa";
            this.glosaFormateadaDataGridViewTextBoxColumn1.Name = "glosaFormateadaDataGridViewTextBoxColumn1";
            this.glosaFormateadaDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // abonoDataGridViewTextBoxColumn1
            // 
            this.abonoDataGridViewTextBoxColumn1.DataPropertyName = "Abono";
            this.abonoDataGridViewTextBoxColumn1.HeaderText = "Abono";
            this.abonoDataGridViewTextBoxColumn1.Name = "abonoDataGridViewTextBoxColumn1";
            this.abonoDataGridViewTextBoxColumn1.Width = 80;
            // 
            // cargoDataGridViewTextBoxColumn1
            // 
            this.cargoDataGridViewTextBoxColumn1.DataPropertyName = "Cargo";
            this.cargoDataGridViewTextBoxColumn1.HeaderText = "Cargo";
            this.cargoDataGridViewTextBoxColumn1.Name = "cargoDataGridViewTextBoxColumn1";
            this.cargoDataGridViewTextBoxColumn1.Width = 80;
            // 
            // correlativoDataGridViewTextBoxColumn1
            // 
            this.correlativoDataGridViewTextBoxColumn1.DataPropertyName = "Correlativo";
            this.correlativoDataGridViewTextBoxColumn1.HeaderText = "Correlativo";
            this.correlativoDataGridViewTextBoxColumn1.Name = "correlativoDataGridViewTextBoxColumn1";
            this.correlativoDataGridViewTextBoxColumn1.Width = 70;
            // 
            // mesDataGridViewTextBoxColumn1
            // 
            this.mesDataGridViewTextBoxColumn1.DataPropertyName = "Mes";
            this.mesDataGridViewTextBoxColumn1.HeaderText = "Mes";
            this.mesDataGridViewTextBoxColumn1.Name = "mesDataGridViewTextBoxColumn1";
            this.mesDataGridViewTextBoxColumn1.ReadOnly = true;
            this.mesDataGridViewTextBoxColumn1.Width = 60;
            // 
            // ComprobantesContables
            // 
            this.ComprobantesContables.DataSource = typeof(Entidades.EComprobante_Detalle);
            // 
            // grInsertarDatos
            // 
            this.grInsertarDatos.Controls.Add(this.btnInsertarDatos);
            this.grInsertarDatos.Enabled = false;
            this.grInsertarDatos.Location = new System.Drawing.Point(361, 168);
            this.grInsertarDatos.Name = "grInsertarDatos";
            this.grInsertarDatos.Size = new System.Drawing.Size(410, 80);
            this.grInsertarDatos.TabIndex = 20;
            this.grInsertarDatos.TabStop = false;
            this.grInsertarDatos.Text = "Insertar Datos";
            // 
            // btnInsertarDatos
            // 
            this.btnInsertarDatos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInsertarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnInsertarDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsertarDatos.Location = new System.Drawing.Point(295, 23);
            this.btnInsertarDatos.Name = "btnInsertarDatos";
            this.btnInsertarDatos.Size = new System.Drawing.Size(96, 47);
            this.btnInsertarDatos.TabIndex = 11;
            this.btnInsertarDatos.Text = "Insertar Datos";
            this.btnInsertarDatos.UseVisualStyleBackColor = true;
            this.btnInsertarDatos.Click += new System.EventHandler(this.btnInsertarDatos_Click);
            // 
            // grExtraerDatos
            // 
            this.grExtraerDatos.Controls.Add(this.labelPitagoras2);
            this.grExtraerDatos.Controls.Add(this.lbPrefijoNComprobante);
            this.grExtraerDatos.Controls.Add(this.cmbMes);
            this.grExtraerDatos.Controls.Add(this.btnExtraerDatos);
            this.grExtraerDatos.Controls.Add(this.cmbAnio);
            this.grExtraerDatos.Controls.Add(this.labelPitagoras1);
            this.grExtraerDatos.Controls.Add(this.txtNComprobante);
            this.grExtraerDatos.Location = new System.Drawing.Point(12, 168);
            this.grExtraerDatos.Name = "grExtraerDatos";
            this.grExtraerDatos.Size = new System.Drawing.Size(343, 80);
            this.grExtraerDatos.TabIndex = 19;
            this.grExtraerDatos.TabStop = false;
            this.grExtraerDatos.Text = "Extraer Datos";
            // 
            // labelPitagoras2
            // 
            this.labelPitagoras2.AutoSize = true;
            this.labelPitagoras2.ForeColor = System.Drawing.Color.Black;
            this.labelPitagoras2.Location = new System.Drawing.Point(6, 26);
            this.labelPitagoras2.Name = "labelPitagoras2";
            this.labelPitagoras2.Size = new System.Drawing.Size(43, 13);
            this.labelPitagoras2.TabIndex = 17;
            this.labelPitagoras2.Text = "Periodo";
            this.labelPitagoras2.TipoLabel = ControlesPersonalizados.LabelTipo.Normal;
            // 
            // lbPrefijoNComprobante
            // 
            this.lbPrefijoNComprobante.AutoSize = true;
            this.lbPrefijoNComprobante.ForeColor = System.Drawing.Color.Black;
            this.lbPrefijoNComprobante.Location = new System.Drawing.Point(144, 53);
            this.lbPrefijoNComprobante.Name = "lbPrefijoNComprobante";
            this.lbPrefijoNComprobante.Size = new System.Drawing.Size(31, 13);
            this.lbPrefijoNComprobante.TabIndex = 18;
            this.lbPrefijoNComprobante.Text = "0000";
            this.lbPrefijoNComprobante.TipoLabel = ControlesPersonalizados.LabelTipo.Normal;
            // 
            // cmbMes
            // 
            this.cmbMes.DataSource = this.bindingCmbMeses;
            this.cmbMes.DisplayMember = "Nombre";
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(77, 23);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(66, 21);
            this.cmbMes.TabIndex = 11;
            this.cmbMes.Value = ((uint)(0u));
            this.cmbMes.ValueMember = "Id";
            this.cmbMes.SelectedIndexChanged += new System.EventHandler(this.comboBoxPitagoras1_SelectedIndexChanged_1);
            // 
            // bindingCmbMeses
            // 
            this.bindingCmbMeses.DataSource = typeof(Entidades.EMes);
            this.bindingCmbMeses.PositionChanged += new System.EventHandler(this.cmbMeses_PositionChanged);
            // 
            // btnExtraerDatos
            // 
            this.btnExtraerDatos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExtraerDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.btnExtraerDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExtraerDatos.Location = new System.Drawing.Point(230, 23);
            this.btnExtraerDatos.Name = "btnExtraerDatos";
            this.btnExtraerDatos.Size = new System.Drawing.Size(96, 47);
            this.btnExtraerDatos.TabIndex = 10;
            this.btnExtraerDatos.Text = "Extrer Datos";
            this.btnExtraerDatos.UseVisualStyleBackColor = true;
            this.btnExtraerDatos.Click += new System.EventHandler(this.btnVerificarFormato_Click);
            // 
            // cmbAnio
            // 
            this.cmbAnio.DataSource = this.bindingCmbAnio;
            this.cmbAnio.DisplayMember = "Anio";
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(149, 23);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(64, 21);
            this.cmbAnio.TabIndex = 12;
            this.cmbAnio.Value = ((uint)(0u));
            this.cmbAnio.ValueMember = "Id";
            this.cmbAnio.SelectedIndexChanged += new System.EventHandler(this.cmbAnio2_SelectedIndexChanged);
            // 
            // bindingCmbAnio
            // 
            this.bindingCmbAnio.DataSource = typeof(Entidades.EAnio);
            // 
            // labelPitagoras1
            // 
            this.labelPitagoras1.AutoSize = true;
            this.labelPitagoras1.ForeColor = System.Drawing.Color.Black;
            this.labelPitagoras1.Location = new System.Drawing.Point(6, 53);
            this.labelPitagoras1.Name = "labelPitagoras1";
            this.labelPitagoras1.Size = new System.Drawing.Size(69, 13);
            this.labelPitagoras1.TabIndex = 16;
            this.labelPitagoras1.Text = "N° Comp. Ini.";
            this.labelPitagoras1.TipoLabel = ControlesPersonalizados.LabelTipo.Normal;
            // 
            // txtNComprobante
            // 
            this.txtNComprobante.BackColor = System.Drawing.SystemColors.Window;
            this.txtNComprobante.CantidadDecimales = 0;
            this.txtNComprobante.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNComprobante.EsBuscador = false;
            this.txtNComprobante.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNComprobante.FormatoNumerico = false;
            this.txtNComprobante.IgnorarFlujo = false;
            this.txtNComprobante.Location = new System.Drawing.Point(176, 50);
            this.txtNComprobante.MaxLength = 3;
            this.txtNComprobante.Name = "txtNComprobante";
            this.txtNComprobante.SeleccionaTodoConClick = true;
            this.txtNComprobante.Size = new System.Drawing.Size(37, 20);
            this.txtNComprobante.StringVaciaSiEsCero = false;
            this.txtNComprobante.TabIndex = 15;
            this.txtNComprobante.Text = "0";
            this.txtNComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNComprobante.ValorMaximo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtNComprobante.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numerocuentaformateadaDataGridViewTextBoxColumn
            // 
            this.numerocuentaformateadaDataGridViewTextBoxColumn.DataPropertyName = "Numero_cuenta_formateada";
            this.numerocuentaformateadaDataGridViewTextBoxColumn.HeaderText = "N° Cuenta";
            this.numerocuentaformateadaDataGridViewTextBoxColumn.Name = "numerocuentaformateadaDataGridViewTextBoxColumn";
            this.numerocuentaformateadaDataGridViewTextBoxColumn.ReadOnly = true;
            this.numerocuentaformateadaDataGridViewTextBoxColumn.Width = 85;
            // 
            // fechaformateadaDataGridViewTextBoxColumn
            // 
            this.fechaformateadaDataGridViewTextBoxColumn.DataPropertyName = "Fecha_formateada";
            this.fechaformateadaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaformateadaDataGridViewTextBoxColumn.Name = "fechaformateadaDataGridViewTextBoxColumn";
            this.fechaformateadaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaformateadaDataGridViewTextBoxColumn.Width = 70;
            // 
            // numerocomprobanteformateadaDataGridViewTextBoxColumn
            // 
            this.numerocomprobanteformateadaDataGridViewTextBoxColumn.DataPropertyName = "Numero_comprobante_formateada";
            this.numerocomprobanteformateadaDataGridViewTextBoxColumn.HeaderText = "N° Comp.";
            this.numerocomprobanteformateadaDataGridViewTextBoxColumn.Name = "numerocomprobanteformateadaDataGridViewTextBoxColumn";
            this.numerocomprobanteformateadaDataGridViewTextBoxColumn.ReadOnly = true;
            this.numerocomprobanteformateadaDataGridViewTextBoxColumn.Width = 80;
            // 
            // glosaFormateadaDataGridViewTextBoxColumn
            // 
            this.glosaFormateadaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.glosaFormateadaDataGridViewTextBoxColumn.DataPropertyName = "Glosa_Formateada";
            this.glosaFormateadaDataGridViewTextBoxColumn.HeaderText = "Glosa";
            this.glosaFormateadaDataGridViewTextBoxColumn.Name = "glosaFormateadaDataGridViewTextBoxColumn";
            this.glosaFormateadaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // abonoDataGridViewTextBoxColumn
            // 
            this.abonoDataGridViewTextBoxColumn.DataPropertyName = "Abono";
            this.abonoDataGridViewTextBoxColumn.HeaderText = "Abono";
            this.abonoDataGridViewTextBoxColumn.Name = "abonoDataGridViewTextBoxColumn";
            this.abonoDataGridViewTextBoxColumn.ReadOnly = true;
            this.abonoDataGridViewTextBoxColumn.Width = 80;
            // 
            // cargoDataGridViewTextBoxColumn
            // 
            this.cargoDataGridViewTextBoxColumn.DataPropertyName = "Cargo";
            this.cargoDataGridViewTextBoxColumn.HeaderText = "Cargo";
            this.cargoDataGridViewTextBoxColumn.Name = "cargoDataGridViewTextBoxColumn";
            this.cargoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cargoDataGridViewTextBoxColumn.Width = 80;
            // 
            // correlativoDataGridViewTextBoxColumn
            // 
            this.correlativoDataGridViewTextBoxColumn.DataPropertyName = "Correlativo";
            this.correlativoDataGridViewTextBoxColumn.HeaderText = "Fila";
            this.correlativoDataGridViewTextBoxColumn.Name = "correlativoDataGridViewTextBoxColumn";
            this.correlativoDataGridViewTextBoxColumn.ReadOnly = true;
            this.correlativoDataGridViewTextBoxColumn.Width = 30;
            // 
            // mesDataGridViewTextBoxColumn
            // 
            this.mesDataGridViewTextBoxColumn.DataPropertyName = "Mes";
            this.mesDataGridViewTextBoxColumn.HeaderText = "Mes";
            this.mesDataGridViewTextBoxColumn.Name = "mesDataGridViewTextBoxColumn";
            this.mesDataGridViewTextBoxColumn.ReadOnly = true;
            this.mesDataGridViewTextBoxColumn.Width = 30;
            // 
            // grDatosSistema
            // 
            this.grDatosSistema.Controls.Add(this.lpPathMovSys);
            this.grDatosSistema.Controls.Add(this.labelPitagoras3);
            this.grDatosSistema.Controls.Add(this.btnSalvarRutEmpresa);
            this.grDatosSistema.Controls.Add(this.labelPitagoras4);
            this.grDatosSistema.Controls.Add(this.txtRutEmpresa);
            this.grDatosSistema.Controls.Add(this.btnAsignarAplicacion);
            this.grDatosSistema.Controls.Add(this.lbPathAplicacion);
            this.grDatosSistema.Location = new System.Drawing.Point(361, 12);
            this.grDatosSistema.Name = "grDatosSistema";
            this.grDatosSistema.Size = new System.Drawing.Size(410, 150);
            this.grDatosSistema.TabIndex = 21;
            this.grDatosSistema.TabStop = false;
            this.grDatosSistema.Text = "Sistema";
            // 
            // lpPathMovSys
            // 
            this.lpPathMovSys.AutoSize = true;
            this.lpPathMovSys.ForeColor = System.Drawing.Color.Black;
            this.lpPathMovSys.Location = new System.Drawing.Point(11, 126);
            this.lpPathMovSys.Name = "lpPathMovSys";
            this.lpPathMovSys.Size = new System.Drawing.Size(13, 13);
            this.lpPathMovSys.TabIndex = 8;
            this.lpPathMovSys.Text = "--";
            this.lpPathMovSys.TipoLabel = ControlesPersonalizados.LabelTipo.Normal;
            // 
            // labelPitagoras3
            // 
            this.labelPitagoras3.AutoSize = true;
            this.labelPitagoras3.ForeColor = System.Drawing.Color.Black;
            this.labelPitagoras3.Location = new System.Drawing.Point(6, 110);
            this.labelPitagoras3.Name = "labelPitagoras3";
            this.labelPitagoras3.Size = new System.Drawing.Size(70, 13);
            this.labelPitagoras3.TabIndex = 7;
            this.labelPitagoras3.Text = "Path MovSys";
            this.labelPitagoras3.TipoLabel = ControlesPersonalizados.LabelTipo.Normal;
            // 
            // btnSalvarRutEmpresa
            // 
            this.btnSalvarRutEmpresa.Location = new System.Drawing.Point(105, 74);
            this.btnSalvarRutEmpresa.Name = "btnSalvarRutEmpresa";
            this.btnSalvarRutEmpresa.Size = new System.Drawing.Size(120, 23);
            this.btnSalvarRutEmpresa.TabIndex = 6;
            this.btnSalvarRutEmpresa.Text = "Salvar Rut Empresa";
            this.btnSalvarRutEmpresa.UseVisualStyleBackColor = true;
            this.btnSalvarRutEmpresa.Click += new System.EventHandler(this.btnSalvarRutEmpresa_Click);
            // 
            // labelPitagoras4
            // 
            this.labelPitagoras4.AutoSize = true;
            this.labelPitagoras4.ForeColor = System.Drawing.Color.Black;
            this.labelPitagoras4.Location = new System.Drawing.Point(3, 60);
            this.labelPitagoras4.Name = "labelPitagoras4";
            this.labelPitagoras4.Size = new System.Drawing.Size(68, 13);
            this.labelPitagoras4.TabIndex = 5;
            this.labelPitagoras4.Text = "Rut Empresa";
            this.labelPitagoras4.TipoLabel = ControlesPersonalizados.LabelTipo.Normal;
            // 
            // txtRutEmpresa
            // 
            this.txtRutEmpresa.BackColor = System.Drawing.SystemColors.Window;
            this.txtRutEmpresa.CantidadDecimales = 0;
            this.txtRutEmpresa.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRutEmpresa.EsBuscador = false;
            this.txtRutEmpresa.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtRutEmpresa.FormatoNumerico = true;
            this.txtRutEmpresa.IgnorarFlujo = false;
            this.txtRutEmpresa.Location = new System.Drawing.Point(6, 76);
            this.txtRutEmpresa.MaxLength = 9;
            this.txtRutEmpresa.Name = "txtRutEmpresa";
            this.txtRutEmpresa.SeleccionaTodoConClick = true;
            this.txtRutEmpresa.Size = new System.Drawing.Size(93, 20);
            this.txtRutEmpresa.StringVaciaSiEsCero = true;
            this.txtRutEmpresa.TabIndex = 2;
            this.txtRutEmpresa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtRutEmpresa.ValorMaximo = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRutEmpresa.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtRutEmpresa.Leave += new System.EventHandler(this.txtRutEmpresa_Leave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grDatosSistema);
            this.Controls.Add(this.grInsertarDatos);
            this.Controls.Add(this.grExtraerDatos);
            this.Controls.Add(this.dgvComprobantes);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvExcels);
            this.HelpButton = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExcels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprobantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComprobantesContables)).EndInit();
            this.grInsertarDatos.ResumeLayout(false);
            this.grExtraerDatos.ResumeLayout(false);
            this.grExtraerDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingCmbMeses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingCmbAnio)).EndInit();
            this.grDatosSistema.ResumeLayout(false);
            this.grDatosSistema.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ControlesPersonalizados.LabelPitagoras lbPathAplicacion;
        private System.Windows.Forms.Button btnAsignarAplicacion;
        private ControlesPersonalizados.GridPitagoras dgvExcels;
        private ControlesPersonalizados.ButtonPitagoras btnBuscar;
        private System.Windows.Forms.BindingSource bindingExcel;
        private ControlesPersonalizados.ButtonPitagoras btnEliminar;
        private ControlesPersonalizados.ButtonPitagoras btnExtraerDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private ControlesPersonalizados.ComboBoxPitagoras cmbMes;
        private System.Windows.Forms.BindingSource bindingCmbMeses;
        private ControlesPersonalizados.ComboBoxPitagoras cmbAnio;
        private System.Windows.Forms.BindingSource bindingCmbAnio;
        private ControlesPersonalizados.GridPitagoras dgvComprobantes;
        private System.Windows.Forms.BindingSource ComprobantesContables;
        private ControlesPersonalizados.TextBoxNumeroPitagoras txtNComprobante;
        private ControlesPersonalizados.LabelPitagoras labelPitagoras1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numerocuentaformateadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaformateadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numerocomprobanteformateadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn glosaFormateadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn correlativoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesDataGridViewTextBoxColumn;
        private ControlesPersonalizados.LabelPitagoras labelPitagoras2;
        private ControlesPersonalizados.LabelPitagoras lbPrefijoNComprobante;
        private ControlesPersonalizados.GroupBoxPitagoras grExtraerDatos;
        private System.Windows.Forms.HelpProvider hp;
        private System.Windows.Forms.GroupBox grInsertarDatos;
        private ControlesPersonalizados.ButtonPitagoras btnInsertarDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn numerocuentaformateadaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaformateadaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numerocomprobanteformateadaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn glosaFormateadaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn abonoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cargoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn correlativoDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mesDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn1;
        private System.Windows.Forms.GroupBox grDatosSistema;
        private ControlesPersonalizados.LabelPitagoras labelPitagoras4;
        private ControlesPersonalizados.TextBoxNumeroPitagoras txtRutEmpresa;
        private System.Windows.Forms.Button btnSalvarRutEmpresa;
        private ControlesPersonalizados.LabelPitagoras lpPathMovSys;
        private ControlesPersonalizados.LabelPitagoras labelPitagoras3;
    }
}

