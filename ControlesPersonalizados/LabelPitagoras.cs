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
    public enum LabelTipo
    {
        Normal,
        Titulo
    }

    public partial class LabelPitagoras : Label
    {
        private LabelTipo tipoLabel = LabelTipo.Normal;

        [
           TypeConverter(typeof(LabelTipo)),
           Description("Cambia el formato general del label")
        ]
        public LabelTipo TipoLabel { get => tipoLabel; set => tipoLabel = value; }

        public LabelPitagoras()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (this.TipoLabel == LabelTipo.Titulo)
            {
                this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            }
        }
    }
}
