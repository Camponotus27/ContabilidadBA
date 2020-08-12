using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class PintureBoxEstadosPitagoras : PictureBox
    {
        private Estado estado;
        private ToolTip tt;

        public PintureBoxEstadosPitagoras()
        {
            InitializeComponent();
            this.InicializarComponenesPersonalizados();
        }

        private void InicializarComponenesPersonalizados()
        {
            this.tt = new ToolTip();
            this.tt.IsBalloon = true;

            this.SetEstado(Estado.Defecto);
            this.Width = 20;
            this.Height = 20;
            this.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void SetEstado(Estado estado, string glosa = "")
        {
            this.estado = estado;
            this.tt.SetToolTip(this, glosa);

            if (this.estado == Estado.Aprobado)
                this.Image = Image.FromFile(@"Recursos\Imagenes\PictureBoxEstadosPitagoras\aprobado.png");
            else if(this.estado == Estado.Rechazado)
                this.Image = Image.FromFile(@"Recursos\Imagenes\PictureBoxEstadosPitagoras\reprobado.png");
            else
                this.Image = null;

        }
    }

    public enum Estado
    {
        Defecto = 0,
        Aprobado = 1,
        Rechazado = 2
    }
}
