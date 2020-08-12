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
    public partial class TextBoxNumeroPitagoras : TextBoxPitagoras
    {
        public TextBoxNumeroPitagoras()
        {
            InitializeComponent();
        }
        private bool isFormateando = false;
        private decimal i_value;
        private int cantidad_decimales = 0;
        private bool formato_numerico = true;
        private bool stringVaciaSiEsCero = false;
        private decimal valor_maximo = 0;

        [
           TypeConverter(typeof(bool)),
           Description("Si se aplica el formato numerico")
        ]
        public bool FormatoNumerico
        {
            get
            {
                return formato_numerico;
            }
            set
            {
                formato_numerico = value;
            }
        }

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
        [
          TypeConverter(typeof(decimal)),
          Description("numero maximo permitido por el control, si es cero el numero es ilimitado (es indepenciente a la cantidad maxima de caracteres)")
        ]
        public decimal ValorMaximo
        {
            get
            {
                return valor_maximo;
            }
            set
            {
                valor_maximo = value;
            }
        }

        protected override void PegarPitagoras()
        {
            if (Clipboard.ContainsText() && Formateador.EsUnControlFocuseable(this))
            {
                if(decimal.TryParse(Clipboard.GetText(), out decimal dec))
                    this.Value = dec;
            }
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
                if (decimal.TryParse(value, out this.i_value))
                {
                    base.Text = value;
                }
                else
                {
                    this.i_value = 0;
                }

            }
            get
            {
                return base.Text;
            }
        }

        

        [
           TypeConverter(typeof(bool)),
           Description("Si al ser el value cero muestre un string vacio en su lugar")
        ]
        public bool StringVaciaSiEsCero { get => stringVaciaSiEsCero; set => stringVaciaSiEsCero = value; }


        #region Metodos
        private void Formatear()
        {
            this.isFormateando = true;

            if (this.i_value == 0 && (this.EsBuscador || this.StringVaciaSiEsCero))
                base.Text = string.Empty;
            else
            {
                if (formato_numerico)
                {
                    base.Text = Math.Round(this.i_value, this.cantidad_decimales).ToString("N" + this.cantidad_decimales.ToString());
                }
                else
                {
                    base.Text = this.i_value.ToString();
                }
            }
            

            this.isFormateando = false;
        }

        private string BorraPuntos(string text)
        {
            return text.Replace(".", String.Empty);
        }
        private void FormatearTextDesuso(decimal val)
        {
            this.isFormateando = true;

            int selecion_inicial = this.SelectionStart;
            int posicion = 0;

            if (selecion_inicial != -1)
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

                //base.Text = this.Formatear(val.ToString());

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
        #endregion

        #region Eventos
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
    
        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
            this.seleccionoTodoPorLoMenosUnaVez = false;
            this.Formatear();
        } 
        protected override void OnTextChanged(EventArgs e)
        {
            if (this.valor_maximo != 0 && this.i_value > valor_maximo)
                this.i_value = valor_maximo;

            if (!isFormateando)
                this.Text = base.Text;

            if (this.Focused && this.Value == 0)
            {
                this.SelectAll();
            }

            base.OnTextChanged(e);
        }
        #endregion


    }
}
