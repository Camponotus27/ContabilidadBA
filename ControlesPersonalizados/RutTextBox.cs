using Herramientas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class RutTextBox : TextBoxPitagoras
    {

        private bool es_Buscador = false;
        private bool buscador_deja_avanzar = false;

        private decimal i_value;

        public bool EsBuscador { get => es_Buscador; set => es_Buscador = value; }


        public RutTextBox()
        {
            InitializeComponent();
        }

        public decimal Value
        {
            get => i_value;
            set
            {
                this.i_value = value;
                this.Formatear();
            }
        }
        public int ValueInt
        {
            get => Formateador.ToInt32(i_value);
        }
        public uint ValueUint
        {
            get => Formateador.ToUInt32(i_value);
        }

        public override string Text
        {
            set
            {
                base.Text = this.formatearRut(value);
            }
            get
            {
                return BorraPuntos(base.Text);
            }
        }

        protected override void PegarPitagoras()
        {
            if (Clipboard.ContainsText())
            {
                if (decimal.TryParse(Clipboard.GetText(), out decimal dec))
                    this.Value = dec;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false; //permitir el caracter
            }
            else
            {
                e.Handled = true; //rechazar el caracter
            }
        }

        protected override void OnTextChanged(EventArgs e)
        {
            this.Formatear();
            this.Select(this.TextLength, 0);
            base.OnTextChanged(e);
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {    
            base.OnLeave(e);
        }

        private void Formatear()
        {
            base.Text = this.formatearRut(base.Text);
        }

        private string formatearRut(string value)
        {
            if(value != null )
            {
                if (decimal.TryParse(value, out decimal rut))
                {
                    if (rut.ToString().Length <= 3)
                        return rut.ToString();
                    else
                        return Math.Round(rut).ToString("N0");
                }
            }

            return string.Empty;
        }

        private string BorraPuntos(string text)
        {
            return text.Replace(".", String.Empty);
        }
    }
}
