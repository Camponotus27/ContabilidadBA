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
    public partial class TextBoxPitagoras : TextBox
    {
        protected bool ignorar_flujo = false;
        protected bool buscador_deja_avanzar = false;
        protected bool es_Buscador = false;
        protected bool seleccionaTodoConClick = true;
        protected bool seleccionoTodoPorLoMenosUnaVez = false;
        protected bool impedir_avanzar = false;

        Color fore_color_inicial;
        Color back_color_inicial;

        Color fore_color_read_only = Color.FromArgb(55, 55, 55);
        Color back_color_read_only = Color.FromArgb(245, 245, 245);

        [
           TypeConverter(typeof(bool)),
           Description("Indica si es gobernado por el flujo de la apliacion")
        ]
        public bool IgnorarFlujo { get => ignorar_flujo; set => ignorar_flujo = value; }

        [
         TypeConverter(typeof(bool)),
         Description("Si es verdadero seguira el flujo solo si se encuentra el valor a buscar")
        ]
        public bool EsBuscador { get => es_Buscador; set => es_Buscador = value; }




        /// <summary>
        /// Si esta activado seleccionara todo el contenido del textBox al Entrar en el 
        /// </summary>
        public bool SeleccionaTodoConClick { get => seleccionaTodoConClick; set => seleccionaTodoConClick = value; }


        public TextBoxPitagoras()
        {
            InitializeComponent();

            // se guardan los colores iniciales del control por si este los cambio
            this.fore_color_inicial = this.ForeColor;
            this.back_color_inicial = this.BackColor;
            //this.ShortcutsEnabled = false;


            // Se ejecuta el evendo para que se apliquen los cambios causados por el readonly
            this.OnReadOnlyChanged(new EventArgs());
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (this.seleccionaTodoConClick && this.ReadOnly)
            {
                this.SelectAll();
            }
            else if (this.seleccionaTodoConClick && !this.seleccionoTodoPorLoMenosUnaVez)
            {
                this.SelectAll();
                this.seleccionoTodoPorLoMenosUnaVez = true;
            }
        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        public void DejarAvanzarSiguiente()
        {
            this.buscador_deja_avanzar = true;
        }
        public void BusquedaCorrecta()
        {
            this.buscador_deja_avanzar = true;
        }
        public bool FocusPitagoras()
        {
            if (!this.ReadOnly && this.Enabled)
            {
                return this.Focus();
            }

            return false;
        }

        public void DejarAvanzarSiguienteBuscador()
        {
            this.buscador_deja_avanzar = true;
        }
        public void ImpedirAvanzarSiguiente()
        {
            this.impedir_avanzar = true;
        }

        protected override void OnLeave(EventArgs e)
        {
            this.seleccionoTodoPorLoMenosUnaVez = false;
            base.OnLeave(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Enter && !this.ignorar_flujo)
            {
                e.SuppressKeyPress = true;
                this.AvanzarSigueitneSiCorresponde();
            }
            else if(e.Control)
            {
                if (e.KeyCode == Keys.V && Formateador.EsUnControlFocuseable(this))
                {
                    e.SuppressKeyPress = true;
                    this.PegarPitagoras();
                }
                else if (e.KeyCode == Keys.C)
                {
                    e.SuppressKeyPress = true;
                    this.Copy();
                }
                else if (e.KeyCode == Keys.X)
                {
                    e.SuppressKeyPress = true;
                    this.Cut();
                }
            }
            else if(e.KeyCode == Keys.Escape && Formateador.EsUnControlFocuseable(this))
            {
                e.SuppressKeyPress = true;
                this.Undo();
            }
        }

        private void AvanzarSigueitneSiCorresponde()
        {
            object frm_ob = this.FindForm();

            Type tipo = frm_ob.GetType().BaseType;

            if (tipo == typeof(FormPitagoras))
            {
                FormPitagoras frmP = (FormPitagoras)frm_ob;


               
                if (!this.es_Buscador || this.buscador_deja_avanzar)
                {
                    this.buscador_deja_avanzar = false;
                    if (!this.impedir_avanzar)
                    {
                        frmP.Flujo.SiguienteControl();
                    }
                    else
                    {
                        this.impedir_avanzar = false;
                    }
                }

            }
        }

        protected override void OnReadOnlyChanged(EventArgs e)
        {
            this.AplicarEstiloReadOnly();
            this.AplicarCursor();
            base.OnReadOnlyChanged(e);
        }

        private void AplicarCursor()
        {
            if (this.ReadOnly)
            {
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Cursor = Cursors.IBeam;
            }
        }

        private void AplicarEstiloReadOnly()
        {
            if (this.ReadOnly)
            {
                this.ForeColor = this.fore_color_read_only;
                this.BackColor = this.back_color_read_only;
            }
            else
            {
                this.ForeColor = this.fore_color_inicial;
                this.BackColor = this.back_color_inicial;
            }
        }

        protected virtual void PegarPitagoras()
        {
            if (Clipboard.ContainsText() && Formateador.EsUnControlFocuseable(this) && this is TextBoxTextoPitagoras)
            {
                this.Text = Clipboard.GetText();
            }
        }

        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        private const int WM_NCPAINT = 0x85;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCPAINT && this.Focused && Parametros.anchoBorde != 0)
            {
                var dc = GetWindowDC(Handle);
                using (Graphics g = Graphics.FromHdc(dc))
                {
                    g.DrawRectangle(new Pen(Parametros.colorBorde, Parametros.anchoBorde), 0, 0, Width - 0, Height - 0);
                }
            }
        }
    }
}
