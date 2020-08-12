
using Entidades;
using Entidades.Herramietas;
using Herramientas;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class FormPitagoras : Form
    {
        #region Control de flujo
        /// <summary>
        /// Administra el flujo de la pantalla al presionar enter sobre un control personalizado que admita esa funcion
        /// </summary>
        public FlujoPantalla Flujo;
        public class FlujoPantalla
        {
            private List<Control> flujo;
            /// <summary>
            /// Permite si estas en la ultima posicion del flujo volver al inicio
            /// </summary>
            public bool FlujoCircular = false;
            /// <summary>
            /// Inicializa los controles que seran parte del flujo
            /// </summary>
            /// <param name="flujo">los controles en formato de Lista, puede ser cualquiera que erede de Control, como TextBox, Combos, etc.</param>
            public void SetFlujoPantalla(List<Control> flujo)
            {
                this.flujo = flujo;
            }
            /// <summary>
            /// Pone el foco en el primer control del flujo si existe
            /// </summary>
            public void PrimerControl()
            {
                if (this.flujo.Count > 0)
                {
                    this.flujo[0].Focus();
                    this.flujo[0].Select();
                }
            }
            /// <summary>
            /// Pasa al siguiente control habilitado
            /// </summary>
            public void SiguienteControl()
            {
                if (this.flujo != null && this.flujo.Count > 0)
                {
                    bool siguiente_control_encontrado = false;
                    bool pueda_seguir_avanzado = true;
                    int largo_flujo = this.flujo.Count;
                    int contador = 0;
                    int posicion_con_el_foco = this.GetControlFoco();

                    if (posicion_con_el_foco != -1)
                    {
                        /// el nombre es porque despues será a proxima posicion
                        int posicion_proxima = posicion_con_el_foco;

                        while (
                            contador < largo_flujo // para que no de mas de una vuelta buscando el control
                            && !siguiente_control_encontrado // mietras no se haya encontrado un control valido
                            && pueda_seguir_avanzado
                            )
                        {
                            posicion_proxima = this.SiguienteIndice(posicion_proxima, out bool dio_una_vuelta);
                            if (!this.FlujoCircular && dio_una_vuelta)
                            {
                                pueda_seguir_avanzado = false;
                                return;
                            }

                            Control posible_control_valido = this.flujo[posicion_proxima];

                            if (this.EsUnControlFocuseable(posible_control_valido))
                            {
                                this.SelecionarControl(posible_control_valido);
                                return;
                            }

                            contador++;
                        }
                    }
                }
            }
            private void SelecionarControl(Control ctl)
            {
                ctl.Focus();
                ctl.Select();
            }
            private bool EsUnControlFocuseable(Control ctl)
            {
                return Formateador.EsUnControlFocuseable(ctl);
            }
            /// <summary>
            /// Retorna la posicion sigueinte entre los controles, no importa si es valida o no
            /// </summary>
            /// <param name="posicion_con_el_foco">posision del foco actual</param>
            /// <param name="dio_una_vuelta">es un parametro de salida indica si al pasar al siguiente indice este pasa de la ultima posicion la primera</param>
            /// <returns></returns>
            private int SiguienteIndice(int posicion_con_el_foco, out bool dio_una_vuelta)
            {
                dio_una_vuelta = false;

                if (posicion_con_el_foco < this.flujo.Count - 1)
                {
                    return posicion_con_el_foco + 1;
                }

                dio_una_vuelta = true;
                return 0;
            }
            private int GetControlFoco()
            {
                int contador = 0;
                foreach (Control ctl in this.flujo)
                {
                    if (ctl.Focused)
                        return contador;
                    contador++;
                }

                return -1;
            }

            public void Focus(Control ctl)
            {
                ctl.Focus();

                if(ctl is TextBox)
                {
                    ((TextBox)ctl).SelectAll();
                }
                else
                {
                    ctl.Select();
                }
            }
        }
        #endregion

        public bool TieneCambios = false;
        public bool TieneCambiosEnLaDB = false;
        public void NotificarCambiosEnLaDB()
        {
            this.TieneCambiosEnLaDB = true;
        }

        Color ColorlbTituloFormPitagoras;
        public FormPitagoras()
        {
            InitializeComponent();
            this.ColorlbTituloFormPitagoras = this.plInferior.BackColor;
            this.Flujo = new FlujoPantalla();

            /*
            // deprecate
            Sesion.MiSesion.CambioSesion += (sender, e) =>
            {
                this.OnLoad(new EventArgs());
            };*/
        }

        #region Autentificacion

        protected void ValidaRol(Res res)
        {
            if (!res.IsCorrecto)
            {
                this.CerrarConMensaje("No tienes permiso para acceder a esta pantalla");
            }
        }

        private void ValidarAutenticacion()
        {
            if (this.valida_autenticacion && Sesion.MiSesion.NacioEnElLogin && !Sesion.MiSesion.EstaAutenticado)
                this.CerrarConMensaje("No se estas autenticado");
        } 

        public void DesabilitarValidacionAutenticacion()
        {
            this.valida_autenticacion = false;
        }
        #endregion

        #region Espear Inicializacion Controles

        #region Eventos
        public event EventHandler ControlesAEsperaCargados;
        protected virtual void OnControlesAEsperaCargados(DatosCargadosEventArgs e)
        {
            EventHandler handler = ControlesAEsperaCargados;
            //this.pictureCargando.Visible = false;
            //this.inicializado = true;
            handler?.Invoke(this, e);
        }

        public delegate void ControlesAEsperaCargadosEventHandler(object sender, EventArgs e);

        EsperaAsyncAwait frm_espara_inicializar_controles;
        bool se_lanso_evento_controles_a_espera_cargados = false;
        public event EventHandler ControlesAEsperaCargadosUnicoAviso;
        protected virtual void OnControlesAEsperaCargadosUnicoAviso(DatosCargadosEventArgs e)
        {
            if (!se_lanso_evento_controles_a_espera_cargados)
            {
                se_lanso_evento_controles_a_espera_cargados = true;

                this.CerrarFormEspera();

                EventHandler handler = ControlesAEsperaCargadosUnicoAviso;
                handler?.Invoke(this, e);
            }
            
        }

        public delegate void ControlesAEsperaCargadosUnicoAvisoEventHandler(object sender, EventArgs e);
        #endregion



        Timer Timer;
        List<IControlInicializador> controles_inicializando;
        /// <summary>
        /// Crea un formulario de espera y esta al tando del incio y termino de los controles indicados
        /// PD: el progreso se debe ejecutar, este metodo no los inicia
        /// </summary>
        /// <param name="controles">Controles a los que se debe esperar, se informara de si progreso a travez de la pantalla de espera
        /// </param>
        public void EsperarInicializacionControles(List<IControlInicializador> controles)
        {
            this.controles_inicializando = controles;
            this.CrearFormularioEspera();

            foreach (IControlInicializador control in controles)
            {
                object frm_ob = control.FindForm();

                if(frm_ob != null)
                {
                    Type tipo = frm_ob.GetType().BaseType;

                    if (tipo == typeof(FormPitagoras))
                    {
                        control.DatosCargados += (sender, e) =>
                        {
                            this.SeCargonUnControlMas((IControlInicializador)sender);
                        };

                        control.Inicializando += (sender2, e2) =>
                        {
                            this.SeInicializoUnControl((IControlInicializador)sender2);
                        };
                    }
                }
            }
        }

        public void EsperarInicializacionControlesPorSegundaVez(List<IControlInicializador> controles)
        {
            this.controles_inicializando = controles;
            this.CrearFormularioEspera();

            foreach (IControlInicializador control in controles)
            {
                control.Reiniciar();
            }
        }

        private void SeInicializoUnControl(IControlInicializador sender2)
        {
            this.FrmEsperaIniciazarControlesAddMensaje("Inicializando " + sender2.Nombre);
        }

        private void SeCargonUnControlMas(IControlInicializador sender2)
        {
            this.OnControlesAEsperaCargados(new DatosCargadosEventArgs());
            this.FrmEsperaIniciazarControlesAddMensaje("Finalizado " + sender2.Nombre);

            foreach (IControlInicializador control in this.controles_inicializando)
            {
                // si un control no esta inicializado no no se dispara el evento del forlmilario
                if (!control.Inicializado)
                {
                    return;
                }
            }

            this.OnControlesAEsperaCargadosUnicoAviso(new DatosCargadosEventArgs());
            
        }

        private void FrmEsperaIniciazarControlesAddMensaje(string v)
        {
            if (this.frm_espara_inicializar_controles == null)
            {
                return;
                this.CrearFormularioEspera();
            }

            this.frm_espara_inicializar_controles.AñadirMensaje(v);
        }

        private void CrearFormularioEspera()
        {
            this.frm_espara_inicializar_controles = new EsperaAsyncAwait("Cargando datos");
            this.frm_espara_inicializar_controles.StartPosition = FormStartPosition.CenterParent;
            this.frm_espara_inicializar_controles.Show((IWin32Window)this);

            if(this.Timer == null)
            {
                this.Timer = new Timer();
                this.Timer.Interval = 500;
                this.Timer.Enabled = true;
                this.Timer.Tick += (sender, e) => {
                    if (this.controles_inicializando != null)
                    {
                        foreach (IControlInicializador control in this.controles_inicializando)
                        {
                            if (!control.Inicializado)
                                return;
                        }
                    }

                    this.CerrarFormEspera();
                };

                this.Timer.Start();
            }
        }

        private void CerrarFormEspera()
        {
            if (this.frm_espara_inicializar_controles != null)
            {
                this.frm_espara_inicializar_controles.Close();
                this.frm_espara_inicializar_controles = null;
            }


            if (this.Timer != null)
            {
                this.Timer.Stop();
                this.Timer.Enabled = false;

                this.Timer = null;
            }
        }
        #endregion

        protected override void OnActivated(EventArgs e)
        {
            if(this.frm_shown)
                this.ValidarAutenticacion();

            base.OnActivated(e);
        }

        protected void SetText(string titulo)
        {
            this.lbTituloFormPitagoras.Text = titulo;
            this.Text = titulo;
        }

        bool identificarPantallaPorAmbiente = false;

        protected override void OnLoad(EventArgs e)
        {
            this.ValidarAutenticacion();

            if (this.IdentificarPantallaPorAmbiente && Sesion.MiSesion.getAmbiente() == Ambiente.CERTIFICACION)
            {
                this.lbTituloFormPitagoras.BackColor = Color.Red;
                this.lbTituloFormPitagoras.Text = this.Text + " (CERTIFICACION)";
            }
            else
            {
                this.lbTituloFormPitagoras.BackColor = this.ColorlbTituloFormPitagoras;
                this.lbTituloFormPitagoras.Text = this.Text;
            }
            


            base.OnLoad(e);
            #region Si es que la pestaña se maximiza o no
            if (!this.cerrar_con_mensaje)
            {
                if (this.Width < this.TamañaDesdeMaximinizaAlCargar)
                {
                    this.WindowState = FormWindowState.Normal;

                    /// Desactivar el maximizar

                    Point posicion_btn_maximizar = this.btnMaximizar.Location;

                    this.Controls.Remove(this.btnMaximizar);
                    this.Controls.Remove(this.btnNormal);

                    this.btnMinimizar.Location = posicion_btn_maximizar;
                }
                else
                    this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
            #endregion
            this.ActualizarVisibiidadBotones();


            
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            #region Cerrar al cargar
            if (this.cerrar_con_mensaje)
            {
                if (this.razon_cierre != string.Empty)
                    this.Aviso(this.razon_cierre);
                this.Close();
            }
            #endregion

            this.frm_shown = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.DrawRectangle(new Pen(Color.White, Parametros.anchoBorde), 0, 0, Width - 0, Height - 0);

            /*
            var g = e.Graphics;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            g.Clear(SystemColors.Control);
            g.FillRectangle(DarkPrimaryBrushe, _statusBarBounds);
            g.FillRectangle(PrimaryBrush, _actionBarBounds);

            //Draw border
            using (var borderPen = new Pen(DIVISOR_COLOR, 1))
            {
                g.DrawLine(borderPen, new Point(0, _actionBarBounds.Bottom), new Point(0, Height - 2));
                g.DrawLine(borderPen, new Point(Width - 1, _actionBarBounds.Bottom), new Point(Width - 1, Height - 2));
                g.DrawLine(borderPen, new Point(0, Height - 1), new Point(Width - 1, Height - 1));
            }

            // Determine whether or not we even should be drawing the buttons.
            bool showMin = MinimizeBox && ControlBox;
            bool showMax = MaximizeBox && ControlBox;
            var hoverBrush = HOVER_BRUSH;
            var downBrush = DOWN_BRUSH;

            // When MaximizeButton == false, the minimize button will be painted in its place
            if (_buttonState == ButtonState.MinOver && showMin)
                g.FillRectangle(hoverBrush, showMax ? _minButtonBounds : _maxButtonBounds);

            if (_buttonState == ButtonState.MinDown && showMin)
                g.FillRectangle(downBrush, showMax ? _minButtonBounds : _maxButtonBounds);

            if (_buttonState == ButtonState.MaxOver && showMax)
                g.FillRectangle(hoverBrush, _maxButtonBounds);

            if (_buttonState == ButtonState.MaxDown && showMax)
                g.FillRectangle(downBrush, _maxButtonBounds);

            if (_buttonState == ButtonState.XOver && ControlBox)
                g.FillRectangle(hoverBrush, _xButtonBounds);

            if (_buttonState == ButtonState.XDown && ControlBox)
                g.FillRectangle(downBrush, _xButtonBounds);

            using (var formButtonsPen = new Pen(ACTION_BAR_TEXT_SECONDARY, 2))
            {
                // Minimize button.
                if (showMin)
                {
                    int x = showMax ? _minButtonBounds.X : _maxButtonBounds.X;
                    int y = showMax ? _minButtonBounds.Y : _maxButtonBounds.Y;

                    g.DrawLine(
                        formButtonsPen,
                        x + (int)(_minButtonBounds.Width * 0.33),
                        y + (int)(_minButtonBounds.Height * 0.66),
                        x + (int)(_minButtonBounds.Width * 0.66),
                        y + (int)(_minButtonBounds.Height * 0.66)
                   );
                }

                // Maximize button
                if (showMax)
                {
                    g.DrawRectangle(
                        formButtonsPen,
                        _maxButtonBounds.X + (int)(_maxButtonBounds.Width * 0.33),
                        _maxButtonBounds.Y + (int)(_maxButtonBounds.Height * 0.36),
                        (int)(_maxButtonBounds.Width * 0.39),
                        (int)(_maxButtonBounds.Height * 0.31)
                   );
                }

                // Close button
                if (ControlBox)
                {
                    g.DrawLine(
                        formButtonsPen,
                        _xButtonBounds.X + (int)(_xButtonBounds.Width * 0.33),
                        _xButtonBounds.Y + (int)(_xButtonBounds.Height * 0.33),
                        _xButtonBounds.X + (int)(_xButtonBounds.Width * 0.66),
                        _xButtonBounds.Y + (int)(_xButtonBounds.Height * 0.66)
                   );

                    g.DrawLine(
                        formButtonsPen,
                        _xButtonBounds.X + (int)(_xButtonBounds.Width * 0.66),
                        _xButtonBounds.Y + (int)(_xButtonBounds.Height * 0.33),
                        _xButtonBounds.X + (int)(_xButtonBounds.Width * 0.33),
                        _xButtonBounds.Y + (int)(_xButtonBounds.Height * 0.66));
                }
            }*/
        }

        #region Maximizar al cargar
        private uint tamaña_desde_que_se_maximiniza_al_cargar = 900;
        public uint TamañaDesdeMaximinizaAlCargar { get => tamaña_desde_que_se_maximiniza_al_cargar; set => tamaña_desde_que_se_maximiniza_al_cargar = value; } 
        #endregion

        #region Mensajes y respuestas
        /// <summary>
        /// Muesta la representacion de un mensaje como formulario, este formulario sera un hijo el principal
        /// </summary>
        /// <param name="res">Una respuesta a mostrar</param>
        public void Message(Res res)
        {
            if (res.IsCorrecto && string.IsNullOrEmpty(res.Mensaje))
                return;

            if (!res.IsCorrecto)
                this.Error(res.DescripcionError);

            if (!string.IsNullOrEmpty(res.Mensaje))
                this.Informacion(res.Mensaje);
        }
        private void I_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Enabled = true;
        }

        public void Error(string errir)
        {
            this.BringToFront();
            if (this.CanFocus && this.CanSelect)
                MessageBox.Show((IWin32Window)this, errir, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {

            }
        }
        public void Aviso(string aviso)
        {
            this.BringToFront();
            if(this.CanFocus && this.CanSelect)
                MessageBox.Show((IWin32Window)this, aviso, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            else
            {

            }
        }
        public void Informacion(string mensaje)
        {
            this.BringToFront();
            if (this.CanFocus && this.CanSelect)
                MessageBox.Show((IWin32Window)this, mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {

            }
        }
        public enum RespuestaPregunta
        {
            Si,
            No,
        }
        public bool Pregunta(string pregunta, RespuestaPregunta respuesta_por_defecto = RespuestaPregunta.No)
        {
            this.BringToFront();
            MessageBoxDefaultButton boton_por_defecto;
            if (respuesta_por_defecto == RespuestaPregunta.Si)
                boton_por_defecto = MessageBoxDefaultButton.Button1;
            else
                boton_por_defecto = MessageBoxDefaultButton.Button2;

            DialogResult d = MessageBox.Show((IWin32Window)this, pregunta, "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question, boton_por_defecto);

            if (d == DialogResult.Yes)
                return true;

            return false;
        }
        #endregion

        #region Manejo de estados, solo sirve para los mantenedores estandar
        public enum FrmEstado
        {
            Inicial,
            Cargado,
            Creando,
            Editando
        }
        public FrmEstado estado = FrmEstado.Inicial;
        private List<Control> controles_llaves = new List<Control>();
        public List<Control> Controles_llaves { get => controles_llaves; set => controles_llaves = value; }

        [
           TypeConverter(typeof(bool)),
           Description("Indica si esta pantalla muestra una señal visual en caso de estar en modo de certificacion")
        ]
        public bool IdentificarPantallaPorAmbiente { get => identificarPantallaPorAmbiente; set => identificarPantallaPorAmbiente = value; }
        public FrmEstado Estado { get => estado;}

        bool valida_autenticacion = true;
        public bool ValidaAutenticacion {
            get
            {
                return valida_autenticacion;
            }
        }

        public void SetEstado(FrmEstado estado)
        {
            this.estado = estado;
        }

        public void SetEstadoCreando()
        {
            this.estado = FrmEstado.Creando;
            this.HabilitarLLaves(true);
        }
        public void SetEstadoEditando()
        {
            this.estado = FrmEstado.Editando;

            this.HabilitarLLaves(false);
        }
        public void HabilitarLLaves(bool v)
        {
            foreach(Control ctl in this.Controles_llaves)
            {
                ctl.Enabled = v;
            }
        }
        #endregion

        #region Movel panel moviendo el mouse
        public int xClick = 0, yClick = 0;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }
        #endregion

        #region BotoneraSuperior
        Padding padding_menu_principal = new Padding(0, 0, 0, 27);
        Padding PADDING_ZERO = new Padding(0, 0, 0, 0);
        protected bool esMenuPrincipal = false;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (esMenuPrincipal)
                //this.Padding = padding_menu_principal;
            this.WindowState = FormWindowState.Maximized;
            this.ActualizarVisibiidadBotones();
        }
        private void btnNormal_Click(object sender, EventArgs e)
        {
            if (esMenuPrincipal)
                //this.Padding = PADDING_ZERO;
            this.WindowState = FormWindowState.Normal;
            this.ActualizarVisibiidadBotones();
        }
        private void ActualizarVisibiidadBotones()
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.btnMaximizar.Visible = false;
                this.btnNormal.Visible = true;
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.btnMaximizar.Visible = true;
                this.btnNormal.Visible = false;
            }
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region Cierre Automatico al abrir
        protected bool cerrar_con_mensaje = false;
        protected string razon_cierre = string.Empty;
        protected bool frm_shown = false;
        private void FormPitagoras_Load(object sender, EventArgs e)
        {
            this.ActualizarVisibiidadBotones();
        }
        public void CerrarConMensaje(string aviso = "")
        {
            this.cerrar_con_mensaje = true;
            this.razon_cierre = aviso;

            if (this.frm_shown)
            {
                if (this.razon_cierre != string.Empty)
                    this.Aviso(this.razon_cierre);
                this.Close();
            }
        }
        #endregion

        #region Async
        private BackgroundWorker bk;

        public void EjecutarAsyncBackgroudWorker(Action accion, Action accion_al_completar = null)
        {

            this.Enabled = false;
            

            bk = new BackgroundWorker();
            bk.DoWork += (sender, args) => accion();

            if(accion_al_completar != null)
            {
                bk.RunWorkerCompleted += (sender, args) => accion_al_completar();
            }

            bk.RunWorkerCompleted += (sender, args) => { this.Enabled = true; };

            bk.RunWorkerAsync();
        }

        public async Task<Res> EjecutarAsyncAwait(Func<Res> p, string mensaje = "", Reportador rep = null)
        {
            this.Enabled = false;


            EsperaAsyncAwait i = new EsperaAsyncAwait(mensaje);
            i.SetPadre(this);

            if (rep != null)
            {
                rep.Reportando += (sender, e) =>
                {
                    ReportandorEventArgs re = (ReportandorEventArgs)e;
                    i.AñadirMensaje(re.Reporte);
                };

                rep.InicializadorProgreso += (sender2, e2) =>
                {
                    i.InicializadorProgroso(e2.Inicio, e2.Final, e2.Titulo);
                };

                rep.NotificarProgreso += (sender3, e3) =>
                {
                    i.NotificarProgreso();
                };
            }

            i.Show((IWin32Window)this);

            Res res = await Task<Res>.Factory.StartNew(p);

            i.Close();
            this.Enabled = true;
            this.Focus();

            return res;
        }

        private async Task<Res> EjecutarAsyncAwait2(Func< Res> p, string mensaje)
        {
            this.Enabled = false;

            EsperaAsyncAwait i = new EsperaAsyncAwait(mensaje);
            i.SetPadre(this);
            i.Show((IWin32Window)this);

            Res res = await Task<Res>.Factory.StartNew(p);

            i.Close();
            this.Enabled = true;
            this.Focus();

            return res;
        }
        #endregion

    }
}
