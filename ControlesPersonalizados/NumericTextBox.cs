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
    public partial class NumericTextBox : TextBox
    {
        public NumericTextBox()
        {
            InitializeComponent();
            this.TextAlign = HorizontalAlignment.Right;
        }

        public int cantidad_decimales = 0;

        [
            TypeConverter(typeof(int)),
            Description("Indica numero decimales")
        ]
        public int CantidadDecimales
        {
            get
            {
                return cantidad_decimales;
            }
            set
            {
                cantidad_decimales = value;
            }
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {

            TextBox txt = (TextBox)this;

            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool IsDec = false;
            int ubicacion_coma = 0;
            int nroDec = 0;


            if (this.cantidad_decimales > 0)
            {
                for (int i = 0; i < txt.Text.Length; i++)
                {
                    if (txt.Text[i] == ',')
                    {
                        IsDec = true;
                        ubicacion_coma = i;
                    }


                    if (IsDec && nroDec++ >= this.cantidad_decimales)
                    {
                        if (txt.SelectionStart > ubicacion_coma)
                        {
                            e.Handled = true;
                            return;
                        }
                    }
                }
            }
            else
            {
                IsDec = true;
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == ',')
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }

        protected override void OnEnter(EventArgs e)
        {
            //base.Text = this.BorraPuntos(base.Text);
            base.OnEnter(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            //base.Text = this.formatearRut(base.Text);
            base.OnLeave(e);
        }

        protected override void OnClick(EventArgs e)
        {
            this.SelectAll();
            base.OnClick(e);

        }

        public override string Text
        {
            set
            {
               base.Text = this.Formatear(value);
            }
            get
            {
                return BorraPuntos(base.Text);
            }
        }

        private string Formatear(string value)
        {
            if (value != null)
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
