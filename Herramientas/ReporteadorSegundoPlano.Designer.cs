namespace Herramientas
{
    partial class ReporteadorSegundoPlano
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
            this.list = new System.Windows.Forms.ListBox();
            this.bsList = new System.Windows.Forms.BindingSource(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bsList)).BeginInit();
            this.SuspendLayout();
            // 
            // list
            // 
            this.list.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bsList, "Nombre", true));
            this.list.DataSource = this.bsList;
            this.list.DisplayMember = "Nombre";
            this.list.FormattingEnabled = true;
            this.list.Location = new System.Drawing.Point(3, 3);
            this.list.Name = "list";
            this.list.Size = new System.Drawing.Size(202, 43);
            this.list.TabIndex = 0;
            this.list.ValueMember = "Id";
            // 
            // bsList
            // 
            this.bsList.DataSource = typeof(Herramientas.Clases.EItemLista);
            this.bsList.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.bsList_ListChanged);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ReporteadorSegundoPlano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(217, 58);
            this.Controls.Add(this.list);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ReporteadorSegundoPlano";
            this.Opacity = 0.9D;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Notificador";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ReporteadorSegundoPlano_Load);
            this.MouseLeave += new System.EventHandler(this.ReporteadorSegundoPlano_MouseLeave);
            this.MouseHover += new System.EventHandler(this.ReporteadorSegundoPlano_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.bsList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox list;
        private System.Windows.Forms.BindingSource bsList;
        private System.Windows.Forms.Timer timer;
    }
}