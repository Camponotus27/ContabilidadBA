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

namespace ControlesPersonalizados
{
    public partial class BackgroundWorkerPitagoras : BackgroundWorker, IControlInicializador
    {
        FormPitagoras form_pitagoras;
        DataTable dt;

        public BackgroundWorkerPitagoras()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Crea la isntancia con el form al cual pertenece, esto hará que aparesca en la pantalla de "cargando"
        /// </summary>
        /// <param name="form_pitagoras"></param>
        public BackgroundWorkerPitagoras(FormPitagoras form_pitagoras, string nombre = "")
        {
            InitializeComponent();

            this.form_pitagoras = form_pitagoras;
            this.nombre = nombre;
        }


        bool inicializado;
        public bool Inicializado { get => inicializado; }
        string nombre;
        public string Nombre
        {
            get
            {
                if (string.IsNullOrEmpty(nombre))
                    return "-";

;                return nombre;
            }
        }
        public DataTable Dt { get => dt; set => dt = value; }

        #region Evento
        public event EventHandler DatosCargados;

        protected virtual void OnDatosCargados(DatosCargadosEventArgs e)
        {
            EventHandler handler = DatosCargados;
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

        public Form FindForm()
        {
            if (this.form_pitagoras != null)
                return this.form_pitagoras;
            
            return new Form();
        }

        public void Inicializar(FormPitagoras form_pitagoras, DoWorkEventHandler do_work, RunWorkerCompletedEventHandler run_worked_compled)
        {
            this.form_pitagoras = form_pitagoras;

            this.DoWork += (sender1, e1) =>
            {
                this.OnInicializando(new EventArgs());
            };
            this.DoWork += do_work;

            this.RunWorkerCompleted += (sender2, e2) => {
                this.inicializado = true;
            };
            this.RunWorkerCompleted += run_worked_compled;
            this.RunWorkerCompleted += (sender2, e2) => {
                this.OnDatosCargados(new DatosCargadosEventArgs());
            };

            this.RunWorkerAsync();
        }

        public void Inicializar(Func<Res> do_work, Action<Res> run_worked_compled)
        {
            this.DoWork += (sender1, e1) =>
            {
                this.OnInicializando(new EventArgs());
            };
            this.DoWork += (sender2, e2) => {
                e2.Result = do_work();
            };

            this.RunWorkerCompleted += (sender2, e2) => {
                this.inicializado = true;
            };
            this.RunWorkerCompleted += (sender3, e3) => {
                Res res = (Res)e3.Result;

                if(res.IsCorrecto)
                    this.dt = res.ObtenerResultadoDT();

                this.OnDatosCargados(new DatosCargadosEventArgs(this.dt));

                run_worked_compled(res);
            };

            this.RunWorkerAsync();
        }

        public void Reiniciar()
        {
            this.inicializado = false;
            this.dt = null;
        }
    }
}
