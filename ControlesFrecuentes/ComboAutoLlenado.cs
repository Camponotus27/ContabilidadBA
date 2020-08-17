using CapaNegocio;
using ControlesPersonalizados;
using Entidades;
using Herramientas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.ControlesFrecuentes
{


    public partial class ComboAutoLlenado : ComboBoxPitagoras , IControlInicializador
    {
        private bool inicializado = false;
        private bool vacio = true;
        private bool añadir_elemento_cero_vacio = false;
        private Tabla tabla = Tabla.Ninguna;
        private string campo_key;
        private string campo_value;
        private string texto_primer_elemento = "(ninguno)";

        public DataTable dt { get; private set; }
        public bool Inicializado { get => inicializado;}
        public bool Vacio { get => vacio; }

        public string Nombre
        {
            get
            {
                string nombre_tabla = this.tabla.ToString();
                string nombre_comun = this.comun.ToString();

                if (nombre_tabla != "Ninguna")
                    return nombre_tabla.Replace("_", " ");

                if (nombre_comun != "Ninguna")
                    return nombre_comun.Replace("_", " ");


                return "No espesificado";
            }
        }

        internal void setTextoPrimerElemento(string v)
        {
            this.texto_primer_elemento = v;
        }

        public ComboAutoLlenado()
        {
            InitializeComponent();

            this.pictureCargando.Visible = true;
            this.pictureCargando.Location = new Point(this.Location.X + 2, this.Location.Y + 2);
            this.pictureCargando.Size = new Size(this.Size.Width - 4, this.Size.Height - 4);
            this.Controls.Add(this.pictureCargando);
        }

        public void Reiniciar()
        {
            this.inicializado = false;
            this.dt = null;
        }

        #region Evento
        public event EventHandler DatosCargados;

        protected virtual void OnDatosCargados(DatosCargadosEventArgs e)
        {
            EventHandler handler = DatosCargados;
            this.pictureCargando.Visible = false;
            this.inicializado = true;
            e.Dt = this.dt;
            handler?.Invoke(this, e);
        }

        public delegate void DatosCargadosEventHandler(object sender, EventArgs e);

        public event EventHandler Inicializando;

        protected virtual void OnInicializando(EventArgs e)
        {
            EventHandler handler = Inicializando;
            handler?.Invoke(this, e);
        }

        public delegate void InicializandoEventHandler(object sender, EventArgs e);
        #endregion

        /// <summary>
        /// Se inicializa con el tipo de combo que se requiere
        /// </summary>
        /// <param name="tabla"></param>
        public void InicializarAsync(Tabla tabla, bool añadir_elemento_cero_vacio = false)
        {
            this.añadir_elemento_cero_vacio = añadir_elemento_cero_vacio;
            this.tabla = tabla;
            if (tabla != Tabla.Ninguna)
            {
                this.OnInicializando(new EventArgs());
                this.CargarListatablaAsync();
            }
            else
                Interacciones.Ex("Tabla no implementada");
        }

  
        internal void Inicializar(Tabla tabla, DataTable dt, bool añadir_elemento_cero_vacio = false)
        {
            this.añadir_elemento_cero_vacio = añadir_elemento_cero_vacio;
            this.tabla = tabla;
            if (tabla != Tabla.Ninguna)
            {
                this.OnInicializando(new EventArgs());
                this.setKeyValue(tabla);
                this.dt = dt;

                this.RefrescarCombo();
                this.OnDatosCargados(new DatosCargadosEventArgs(this.dt));

                this.pictureCargando.Visible = false;
            }
            else
                Interacciones.Ex("Tabla no implementada");
        }
        public void CargarListatablaAsync()
        {
            Res res = new Res();
            res.Error("No se ha selecionado una tabla a cargar");

            this.setKeyValue(this.tabla);

            BackgroundWorker BW = new BackgroundWorker();
            BW.DoWork += (sender1, e1) => {
                res = NBuscador.Busca(this.tabla.ToString());
            };
            BW.RunWorkerCompleted += (sender2, e2) =>
            {
                this.ActionWorkerCompleted(res);
            };

            BW.RunWorkerAsync();

        }

        public void CargarListatabla()
        {
            Res res = new Res();
            res.Error("No se ha selecionado una tabla a cargar");

            this.setKeyValue(this.tabla);
            res = NBuscador.Busca(this.tabla.ToString());

            this.ActionWorkerCompleted(res);

        }

        private void ActionWorkerCompleted(Res res)
        {
            if (string.IsNullOrEmpty(this.campo_key))
                res.Error("El campo de la llave no esta definida");

            if (string.IsNullOrEmpty(this.campo_value))
                res.Error("El campo del valor no esta definido");

            if (res.IsCorrecto)
            {
                this.dt = res.ObtenerResultadoDT();

                DatosCargadosEventArgs arg = new DatosCargadosEventArgs();
                arg.Dt = this.dt;
                this.RefrescarCombo();
                this.OnDatosCargados(arg);
            }
            else
            {
                Interacciones.MessajeBoxAviso("Error cargando combo " + tabla.ToString() + ": " + res.DescripcionError);
            }

            this.pictureCargando.Visible = false;
        }

        private void setKeyValue(Tabla tabla)
        {
            // Llaves por defecto esperadas desde la base de datos
            this.campo_key = "id";
            this.campo_value = "combo";

            // si se quiere llenar con otro campo se espesifica por tabla
            if (tabla == Tabla.Mae_Locales)
            {
                this.campo_key = "id";
                this.campo_value = "nom_local";
            }else if(tabla == Tabla.Mae_Doc_Tributarios)
            {
                this.campo_key = "cod";
            }

            /*
            /// Ejemplo de cargar un combo
            else if(tabla == Tabla.Mae_Locales)
            {
                this.campo_key = "id";
                this.campo_value = "nom_local";
            }
            */
        }

        public void RefrescarCombo()
        {
            this.vacio = true;

            try
            {

                Dictionary<string, string> dic = new Dictionary<string, string>()
                {
                    ["0"] = "(sin datos)"
                };

                if (this.dt.Rows.Count > 0)
                {
                    this.vacio = false;

                    dic = this.dt.AsEnumerable().ToDictionary<DataRow, string, string>(
                       row => Formateador.ToString(row[this.campo_key]),
                      row => Formateador.ToString(row[this.campo_value])
                      );

                    if (añadir_elemento_cero_vacio && !dic.ContainsKey("0"))
                    {
                        dic = Formateador.InsertarValorSuperiorSS(dic, "0", this.texto_primer_elemento);
                    }
                }
                
                this.DataSource = new BindingSource(dic, null);
                this.DisplayMember = "Value";
                this.ValueMember = "Key";
            }
            catch (Exception ex)
            {
                this.vacio = true;
                Interacciones.MessajeBoxAviso("Error refrescando combo " + this.tabla.ToString() + ": " + ex.Message);
            }
        }


        Comun comun = Comun.Ninguna;
        public void Inicializar(Comun comun)
        {
            this.DropDownStyle = ComboBoxStyle.DropDownList;

            this.comun = comun;
            if (comun != Comun.Ninguna)
            {
                this.OnInicializando(new EventArgs());

                if (comun == Comun.IngEgre)
                {
                    Dictionary<IngEgre, string> dic = new Dictionary<IngEgre, string>()
                    {
                        [IngEgre.I] = "Ingreso",
                        [IngEgre.E] = "Egreso"
                    };

                    this.DataSource = new BindingSource(dic, null);
                }
                else if(comun == Comun.CondVenta)
                {
                    Dictionary<CondVenta, string> dic = new Dictionary<CondVenta, string>()
                    {
                        [CondVenta.CONTADO] = "Contado",
                        [CondVenta.CREDITO] = "Credito"
                    };

                    this.DataSource = new BindingSource(dic, null);
                }else if (comun == Comun.CausaAnulacion)
                {
                    Dictionary<CausaAnulacion, string> dic = new Dictionary<CausaAnulacion, string>()
                    {
                        [CausaAnulacion.COMPLETA] = "Anulacion COMPLETA",
                        [CausaAnulacion.PARCIAL] = "Anulacion PARCIAL"
                    };

                    this.DataSource = new BindingSource(dic, null);
                }else if(comun == Comun.DireccionesEmpresaMenosLaPropia)
                {
                    Dictionary<EMae_Locales_Direcciones_Comuna_Ciudad, string> dic = Sesion.MiSesion.Direcciones_locales_sin_actual.ToDictionary<EMae_Locales_Direcciones_Comuna_Ciudad, EMae_Locales_Direcciones_Comuna_Ciudad, string>(
                      direccion => direccion,
                      direccion => direccion.Dir
                      );

                    this.DataSource = new BindingSource(dic, null);
                }


                this.DisplayMember = "Value";
                this.ValueMember = "Key";
            }
            else
                Interacciones.Ex("Combo comun no implementado");

            this.OnDatosCargados(new DatosCargadosEventArgs());

        }

        public IngEgre ValueIngEgre {
            get
            {
                if (!this.ValidarTipo(Comun.IngEgre))
                    return IngEgre.N;

                KeyValuePair<IngEgre, string> seleccion = (KeyValuePair<IngEgre, string>)this.SelectedItem;
                return (IngEgre)seleccion.Key;
            }
            set
            {
                if (!this.ValidarTipo(Comun.IngEgre))
                {
                    this.SelectedValue = IngEgre.N;
                    return;
                }

                this.SelectedValue = value;
            }
        }

        public CondVenta ValueCondVenta
        {
            get
            {
                if (!this.ValidarTipo(Comun.CondVenta))
                    return CondVenta.NINGUNO;

                KeyValuePair<CondVenta, string> seleccion = (KeyValuePair<CondVenta, string>)this.SelectedItem;
                return (CondVenta)seleccion.Key;
            }
            set
            {
                if (!this.ValidarTipo(Comun.CondVenta))
                {
                    this.SelectedValue = CondVenta.NINGUNO;
                    return;
                }

                this.SelectedValue = value;
            }
        }

        public EMae_Locales_Direcciones_Comuna_Ciudad ValueDireccionesEmpresaMenosLaPropia
        {
            get
            {
                if (!this.ValidarTipo(Comun.DireccionesEmpresaMenosLaPropia))
                    return null;

                KeyValuePair<EMae_Locales_Direcciones_Comuna_Ciudad, string> seleccion = (KeyValuePair<EMae_Locales_Direcciones_Comuna_Ciudad, string>)this.SelectedItem;
                return (EMae_Locales_Direcciones_Comuna_Ciudad)seleccion.Key;
            }
            set
            {
                if (!this.ValidarTipo(Comun.DireccionesEmpresaMenosLaPropia))
                {
                    this.SelectedValue = null;
                    return;
                }

                this.SelectedValue = value;
            }
        }
        public CausaAnulacion ValueCausaAnulacion
        {
            get
            {
                if (!this.ValidarTipo(Comun.CausaAnulacion))
                    return CausaAnulacion.NINGUNO;

                KeyValuePair<CausaAnulacion, string> seleccion = (KeyValuePair<CausaAnulacion, string>)this.SelectedItem;
                return (CausaAnulacion)seleccion.Key;
            }
            set
            {
                if (!this.ValidarTipo(Comun.CausaAnulacion))
                {
                    this.SelectedValue = CondVenta.NINGUNO;
                    return;
                }

                this.SelectedValue = value;
            }
        }

        private bool ValidarTipo(Comun comun)
        {
            if (this.tabla != Tabla.Ninguna || this.comun != comun)
            {
                return false;
                //Interacciones.Ex("Inicializa el combo con un tipo correcto de dato (" + comun.ToString() + ")");
            }

            return true;
        }

        internal void SelecionarPrimeroSiEsPosible()
        {
            if (this.Items != null && this.Items.Count > 0)
                this.SelectedIndex = 0;
        }

        internal void Deseleccionarse()
        {
            this.SelectedValue = -1;
        }
    }
}
