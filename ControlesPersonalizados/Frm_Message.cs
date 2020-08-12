
using Herramientas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class Frm_Message : FormPitagoras
    {
        private LabelPitagoras lbMensaje;
        private LabelPitagoras lbTituloMensaje;
        private LabelPitagoras lbTituloError;
        private LabelPitagoras lbError;
        private ButtonPitagoras btnAceptar;

        private Res respuesta;

        public Frm_Message(Res res)
        {
            this.respuesta = res;
            InitializeComponent();



            this.lbMensaje = new LabelPitagoras();
            this.lbTituloMensaje = new LabelPitagoras();
            this.lbTituloError = new LabelPitagoras();
            this.lbError = new LabelPitagoras();
            this.btnAceptar = new ButtonPitagoras();
        }

        private void Message_Load(object sender, EventArgs e)
        {
            int ancho_form = 500;
            int ancho_real_form = ancho_form - 10;
            int margen_top = 10;
            int margen_entre_segmentos = 10;
            int padding = 10;

            //lbTituloMensaje
            //this.lbTituloMensaje.BackColor = SystemColors.GradientActiveCaption;
            this.lbTituloMensaje.Name = "lbTituloMensaje";
            this.lbTituloMensaje.Text = "Mensaje";
            this.lbTituloMensaje.Size = new Size(ancho_real_form, 30);
            this.lbTituloMensaje.TextAlign = ContentAlignment.MiddleCenter;
            if (string.IsNullOrEmpty(this.respuesta.Mensaje))
                this.lbTituloMensaje.Visible = false;
            else
            this.Controls.Add(this.lbTituloMensaje);

            //lbTituloMensaje
            this.lbMensaje.BackColor = SystemColors.GradientActiveCaption;
            this.lbMensaje.Name = "lbMensaje";
            this.lbMensaje.AutoSize = true;
            this.lbMensaje.Text = this.respuesta.Mensaje;
            this.lbMensaje.MaximumSize = new Size(ancho_form, 1000);
            this.lbMensaje.Location = new Point(0, this.lbTituloMensaje.Location.Y + this.lbTituloMensaje.Size.Height + margen_top);
            this.lbMensaje.Padding = new Padding(padding);
            if (string.IsNullOrEmpty(this.respuesta.Mensaje))
                this.lbMensaje.Visible = false;
            else
            this.Controls.Add(this.lbMensaje);

            //lbTituloError
            //this.lbTituloError.BackColor = Color.Aqua;
            this.lbTituloError.Name = "lbTituloError";
            this.lbTituloError.Text = "Error";
            this.lbTituloError.Location = new Point(0, (this.lbMensaje.Visible)? (this.lbMensaje.Location.Y + this.lbMensaje.Size.Height + margen_top + margen_entre_segmentos): 0);
            this.lbTituloError.Size = new Size(ancho_real_form, 30);
            this.lbTituloError.TextAlign = ContentAlignment.MiddleCenter;
            if (this.respuesta.IsCorrecto)
                this.lbTituloError.Visible = false;
            else
            this.Controls.Add(this.lbTituloError);

            //lbError
            this.lbError.BackColor = SystemColors.GradientActiveCaption;
            this.lbError.Name = "lbError";
            this.lbError.AutoSize = true;
            this.lbError.MaximumSize = new Size(ancho_form, 1000);
            this.lbError.Text = this.respuesta.DescripcionError;
            this.lbError.Location = new Point(0, this.lbTituloError.Location.Y + this.lbTituloError.Size.Height + margen_top);
            this.lbError.Padding = new Padding(padding);
            if (this.respuesta.IsCorrecto)
                this.lbError.Visible = false;
            else
                this.Controls.Add(this.lbError);

            int btn_locate_y = 0;
            if (this.lbError.Visible)
                btn_locate_y = this.lbError.Location.Y + this.lbError.Size.Height + margen_top;
            else
                btn_locate_y = this.lbMensaje.Location.Y + this.lbMensaje.Size.Height + margen_top;

            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.Click += BtnAceptar_Click;
            this.btnAceptar.Location = new Point(ancho_real_form / 2 - this.btnAceptar.Size.Width / 2, btn_locate_y);
            this.Controls.Add(this.btnAceptar);

       
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.MaximumSize = new Size(ancho_form, 1000);

            this.btnAceptar.Focus();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelPitagoras1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
