using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Herramientas;

namespace ControlesPersonalizados
{
    public partial class NumericTextBox2 : TextBox
    {
        public NumericTextBox2()
        {
            InitializeComponent();
            this.InicializarComponentesPersonalizados();
        }

        public NumericTextBox2(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.InicializarComponentesPersonalizados();
        }

        private void InicializarComponentesPersonalizados()
        {
            this.TextAlign = HorizontalAlignment.Right;
            this.Width = 100;
        }

        private bool isFormateando = false;
        private decimal value;
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

        public decimal Value { get => value;
            set {
                this.value = value;
                this.FormatearText(value);
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

        protected override void OnClick(EventArgs e)
        {
            this.SelectAll();
            base.OnClick(e);
        }

        public override string Text
        {
            set
            {
                if(decimal.TryParse(value, out this.value))
                {
                    base.Text = this.Formatear(value);
                }
                else
                {
                    this.value = 0;
                    base.Text = "0";
                }
                
            }
            get
            {
                return base.Text;
            }
        }


        protected override void OnTextChanged(EventArgs e)
        {
            if(!isFormateando)
            {
                if (!decimal.TryParse(this.Text, out this.value))
                {
                    this.value = 0;
                }
                else
                {
                    this.FormatearText(this.value);
                }
            }

            base.OnTextChanged(e);
        }

        private void FormatearText(decimal val) {
            this.isFormateando = true;

            int selecion_inicial = this.SelectionStart;
            int posicion = 0;

            if (selecion_inicial != - 1)
            {
                string texto_inicial = this.Text;

                while (
                    texto_inicial.Length >= 2
                    && texto_inicial.Substring(0, 1) == "0"
                    && Formateador.IsCaracterDigito(texto_inicial.Substring(1, 1))
                    )
                {
                    selecion_inicial--;
                    texto_inicial = texto_inicial.Substring(1, texto_inicial.Length - 1);
                }

                string textoInzqueirdaSeleccion = texto_inicial.Substring(0, selecion_inicial);

                int cantidadDigitos = textoInzqueirdaSeleccion.Replace(",", "").Replace(".", "").Length;

                base.Text = this.Formatear(val.ToString());

                while (cantidadDigitos > 0 && posicion < base.Text.Length)
                {
                    char c = base.Text[posicion];
                    if (Formateador.IsCaracterDigito(c))
                    {
                        cantidadDigitos--;
                    }
                    posicion++;
                }
            }

            this.SelectionStart = posicion;
            this.isFormateando = false;
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

            return "0";
        }

        private string BorraPuntos(string text)
        {
            return text.Replace(".", String.Empty);
        }
    }
}
