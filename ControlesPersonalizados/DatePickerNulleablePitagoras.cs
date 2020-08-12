using ControlesPersonalizados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class DatePickerNulleablePitagoras : DateTimePicker
    {

        public bool isNulo;
        public Panel Panel;

        public void AnularFecha()
        {
            if (!this.isNulo)
            {
                this.Value = Parametros.FechaNula;
                this.MostrarPanel(true);
                this.isNulo = true;
            }
              
        }

        private void MostrarPanel(bool v)
        {
            this.Panel.Visible = v;
        }

        public DatePickerNulleablePitagoras()
        {
            InitializeComponent();
            this.InicializarComponentesPersonalizados();

            if (this.Value == null || this.Value == Parametros.FechaNula)
            {
                this.isNulo = false;
                this.AnularFecha();
            }
            else
            {
                this.isNulo = true;
                this.DesanularFecha();
            }
        }


        public DatePickerNulleablePitagoras(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.InicializarComponentesPersonalizados();
        }

        private void InicializarComponentesPersonalizados()
        {

            this.Format = DateTimePickerFormat.Custom;
            this.CustomFormat = "dd-MM-yyyy";

            Size tamaño = new Size(100, 22);

            this.MinimumSize = tamaño;
            this.Size = tamaño;

            this.InicializarPanel();
        }

        private void InicializarPanel()
        {
            this.Panel = new Panel();
            this.Panel.Left = 0;
            this.Panel.Top = 0;
            this.Panel.Size = new Size(200, 200);
            //this.Panel.BackColor = Color.Red;

            
            Label mensaje = new Label();
            mensaje.Text = "__-__-____";
            mensaje.Top = 5;

            this.Panel.Controls.Add(mensaje);
            
            this.Controls.Add(this.Panel);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                this.AnularFecha();
            }
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;
                this.DesanularFecha();
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (char.IsDigit(e.KeyChar))
            {
                this.DesanularFecha();
            }
        }

        public void DesanularFecha()
        {
            if (this.isNulo)
            {
                this.Value = DateTime.Now;
                this.MostrarPanel(false);
                this.isNulo = false;
            }
           
        }

    }
}
