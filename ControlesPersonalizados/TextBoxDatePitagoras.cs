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
    public partial class TextBoxDatePitagoras : TextBoxPitagoras
    {
        private bool is_formateando = false;
        private DateTime? d_value = null;
        private bool seleccionaTodoConClick = true;
        private bool seleccionoTodoPorLoMenosUnaVez = false;
        private bool es_Buscador = false;
        private bool buscador_deja_avanzar = false;

        public TextBoxDatePitagoras()
        {
            InitializeComponent();
        }

        public bool EsBuscador { get => es_Buscador; set => es_Buscador = value; }
        public override string Text { get => base.Text; set => base.Text = value; }
        public bool SeleccionaTodoConClick { get => seleccionaTodoConClick; set => seleccionaTodoConClick = value; }
        public DateTime? Value
        {
            get => d_value;
            set
            {


                if (value == null)
                {
                    base.Text = string.Empty;
                    this.d_value = null;
                }
                else
                {
                    DateTime date = (DateTime)value;
                    base.Text = date.ToString("dd-MM-yyyy");
                    this.d_value = date.Date;
                }

            }
        }

        public DateTime ValueIfNullNow {
            get
            {
                return (this.Value == null)? Formateador.Ahora() : (DateTime)this.Value;
            }
        }

        public DateTime ValueIfNullFechaNula {
            get
            {
                return (this.Value == null) ? Parametros.FechaNula : (DateTime)this.Value;
            }

        }

        protected override void PegarPitagoras()
        {
            if (Clipboard.ContainsText() && Formateador.EsUnControlFocuseable(this))
            {
                if (DateTime.TryParse(Clipboard.GetText(), out DateTime date))
                    this.Value = date;
            }
        }

        #region Eventos
        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
        }
       
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
        protected override void OnLeave(EventArgs e)
        {
            this.seleccionoTodoPorLoMenosUnaVez = false;
            this.Formatear();
            base.OnLeave(e);
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (this.seleccionaTodoConClick && !this.seleccionoTodoPorLoMenosUnaVez)
            {
                this.SelectAll();
                this.seleccionoTodoPorLoMenosUnaVez = true;
            }
        }
        #endregion

        #region Metodos
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
        private void Formatear()
        {
            this.is_formateando = true;

            string texto_temporal = base.Text;
            if (texto_temporal.Length == 10 && texto_temporal.Substring(4, 1) == "-" && texto_temporal.Substring(7, 1) == "-")
            {
                texto_temporal = Formateador.GirarFechaConGuion(texto_temporal);
            }
            else
            {
                texto_temporal = texto_temporal.Replace("-", "").Replace("/", "");
                if (texto_temporal.Length == 8)
                {
                    texto_temporal = texto_temporal.Insert(4, "-").Insert(2, "-");
                }
                else if (texto_temporal.Length == 6)
                {
                    texto_temporal = texto_temporal.Insert(4, "20");
                    texto_temporal = texto_temporal.Insert(4, "-").Insert(2, "-");
                }
                else
                {
                    texto_temporal = string.Empty;
                }
            }

            base.Text = texto_temporal;
            if (DateTime.TryParse(texto_temporal, out DateTime date))
            {
                this.d_value = date;
            }
            else
            {
                this.d_value = null;
            }

            this.is_formateando = false;
        }
        #endregion

    }
}
