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
    public partial class TextDateTimeGrid : TextBox
    {
        public TextDateTimeGrid()
        {
            InitializeComponent();
            this.InicializarComponentesPersonalizados();
        }

        public TextDateTimeGrid(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.InicializarComponentesPersonalizados();
        }

        private void InicializarComponentesPersonalizados()
        {
            this.TextAlign = HorizontalAlignment.Right;
            this.MaxLength = 10;
        }

        private bool isFormateando = false;

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)this;

            if (e.KeyChar == 8 || (e.KeyChar >= 48 && e.KeyChar <= 57))
            {
                e.Handled = false;
                return;
            }

            if (e.KeyChar == '-')
            {
                if (this.ElUltimoCarecterEsUnGuion(txt))
                {
                    e.Handled = true;
                    return;
                }
                else
                {
                    e.Handled = false;
                    return;
                }
            }



            e.Handled = true;
           

        }

 
        private bool ElUltimoCarecterEsUnGuion(TextBox txt)
        {
            if (txt.Text.Length > 1)
            {
                if (txt.Text.Substring(txt.Text.Length - 1) == "-")
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            this.SelectAll();
            base.OnClick(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            /*
            if(!isFormateando)
            {
                try
                {
                    this.value = Convert.ToDateTime(this.Text);
                    //this.FormatearText(this.value);
                }
                catch
                {
                    this.value = null;
                }
            }*/

            base.OnTextChanged(e);
        }

        private void FormatearText(DateTime? val) {

            this.isFormateando = true;

            try
            {
                if(val == null)
                {
                    base.Text = null;
                }
                else
                {
                    base.Text = Convert.ToDateTime(val).ToString("dd-MM-yyyy");
                }


            }
            catch
            {
                base.Text = val.ToString();
            }

            
            /*
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

                while (cantidadDigitos > 0 || posicion > base.Text.Length)
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
            */
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
