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
    public partial class TreeViewAutoLlenado : TreeView, IControlInicializador
    {
        private uint value;
        private Tabla tabla = Tabla.Ninguna;
        private List<TreeNode> nodosBuscados;
        private bool permiteBusquedaF4 = false;
        private bool isForzarCargarDatos = false;
        private bool todos_son_carpeta = false;
        public DataTable Datos { get; set; }

        bool inicializado;
        public bool Inicializado { get => inicializado; }

        [
           TypeConverter(typeof(bool)),
           Description("Indica si todos los nodos (incluido los finales) son carpetas")
        ]
        public bool TodosSonCarpeta
        {
            get
            {
                return todos_son_carpeta;
            }
            set
            {
                todos_son_carpeta = value;
            }
        }

        public string Nombre
        {
            get
            {
                string nombre_tabla = this.tabla.ToString();

                if (nombre_tabla == "Ninguna")
                    return "No espesificado";

                return nombre_tabla.Replace("_", " ");
            }

        }
        public uint Value {
            get
            {
                if(this.SelectNodeHijo)
                {
                    TreeNodePitagoras nodo = (TreeNodePitagoras)this.SelectedNode;
                    return nodo.ID;
                }

                return 0;
            }
        }
        public bool SelectNodeHijo
        {
            get
            {
                TreeNode nodo = this.SelectedNode;

                return this.EsNodoHijo(nodo);
            }
        }

        public bool EsNodoHijo(TreeNode nodo)
        {
            if (nodo != null)
            {
                // Valida que no tenga hijos
                if (nodo.Nodes.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }
        public bool PermiteBusquedaF4 { get => permiteBusquedaF4; set => permiteBusquedaF4 = value; }

        private bool permite_crear_nodos = false;
        public bool PermiteCrearNodos { get => permite_crear_nodos; set => permite_crear_nodos = value; }
        private bool permite_editar_nodos = false;
        public bool PermitirEditarNodos { get => permite_editar_nodos; set => permite_editar_nodos = value; }

        public TextBoxTextoPitagoras txtBusqueda;

        protected string id = "id";
        protected string id_padre = "id_padre";

        public void Reiniciar()
        {
            this.inicializado = false;

        }
        public TreeViewAutoLlenado()
        {
            InitializeComponent();

            this.ImageList = this.imageList;

            this.nodosBuscados = new List<TreeNode>();

            #region TextBox de la busqueda
            this.txtBusqueda = new TextBoxTextoPitagoras();
            this.txtBusqueda.Visible = false;
            this.txtBusqueda.Size = new Size(this.Width + 20, this.txtBusqueda.Size.Height);
            this.txtBusqueda.Location = this.Location;

            this.txtBusqueda.Leave += TxtBusqueda_Leave;
            this.txtBusqueda.KeyDown += TxtBusqueda_KeyDown;

            this.Controls.Add(this.txtBusqueda);
            #endregion

            this.menuCrearNodoRaiz.Click += MenuCrearNodoRaiz_Click;
            this.menuCrearNodoHijo.Click += MenuCrearNodoHijo_Click;

            this.pictureCargando.Visible = true;
            this.RedimencionarPicture();
            this.Controls.Add(this.pictureCargando);
        }


        #region Evento
        public event EventHandler DatosCargados;

        protected virtual void OnDatosCargados(DatosCargadosEventArgs e)
        {
            EventHandler handler = DatosCargados;
            //this.pictureCargando.Visible = false;
            this.inicializado = true;
            handler?.Invoke(this, e);
        }

        public delegate void DatosCargadosEventHandler(object sender, DatosCargadosEventArgs e);

        public event EventHandler Inicializando;

        protected virtual void OnInicializando(EventArgs e)
        {
            EventHandler handler = Inicializando;
            handler?.Invoke(this, e);
        }

        public delegate void InicializandoEventHandler(object sender, EventArgs e);
        #endregion
        protected void RedimencionarPicture()
        {
            this.pictureCargando.Location = new Point(this.Location.X + 2, this.Location.Y + 2);
            this.pictureCargando.Size = new Size(this.Size.Width - 4, this.Size.Height - 4);
        }

        protected virtual void MenuCrearNodoRaiz_Click(object sender, EventArgs e)
        {
            this.SelectedNode = this.Nodes.Add("Nuevo Nodo Raiz");
            this.SelectedNode.BeginEdit();
        }


        protected virtual void MenuCrearNodoHijo_Click(object sender, EventArgs e)
        {
            this.SelectedNode = this.SelectedNode.Nodes.Add("Nuevo Nodo Hijo");
            this.SelectedNode.BeginEdit();
        }

        #region Metodos
        public void ForzarCargaDatos()
        {
            this.isForzarCargarDatos = true;
            this.CargarLista();
        }
        private void BuscarNodos()
        {
            this.txtBusqueda.Visible = false;
            this.nodosBuscados.Clear();
            this.BuscarYGuardarNodos(this.txtBusqueda.Text, this.Nodes);
            //this.EliminarNodosEncontradosNodosConHijos();
            this.SeleccionarSiguienteNodosEncontrados();
        }
        private void CargarLista()
        {

            this.OnInicializando(new EventArgs());
            Res res = new Res();
            this.pictureCargando.Visible = true;

            BackgroundWorker BW = new BackgroundWorker();
            BW.DoWork += (sender1, e1) => {
                if (this.Datos == null || this.isForzarCargarDatos)
                {
                    res = NBuscador.BuscarCompleto(tabla.ToString());

                    if (res.IsCorrecto)
                    {
                        this.Datos = res.ObtenerResultadoDT();
                    }
                    else
                    {
                        Interacciones.MessajeBoxAviso("Error cargando arbol: " + res.DescripcionError);
                    }

                    this.isForzarCargarDatos = false;
                }
            };
            BW.RunWorkerCompleted += (sender2, e2) =>
            {
                if (this.Datos != null ) //&& this.Datos.Rows.Count > 0)
                {
                    this.Nodes.Clear();
                    this.LlenarFamilia(this.Nodes, 0);

                    this.AsignarIconos();

                    if (res.IsCorrecto)
                        this.OnDatosCargados(new DatosCargadosEventArgs(this.Datos));
                }
                else
                {
                    Interacciones.MessajeBoxAviso("No se tienen datos para cargar el arbol");
                }

                this.pictureCargando.Visible = false;
            };

            BW.RunWorkerAsync();

  
        }
        public void AsignarIconos()
        {
            this.AsignarIconosColeccion(this.Nodes);
        }

        private void AsignarIconosColeccion(TreeNodeCollection nodes)
        {
            foreach(TreeNode nodo in nodes)
            {
                if (this.EsNodoHijo(nodo) && !this.todos_son_carpeta)
                {
                    nodo.SelectedImageIndex = 2;
                    nodo.ImageIndex = 2;
                }
                else
                {
                    nodo.SelectedImageIndex = 1;
                    nodo.ImageIndex = 0;
                }

                this.AsignarIconosColeccion(nodo.Nodes);
            }
        }

        private void EliminarNodosEncontradosNodosConHijos()
        {
            List<TreeNode> nodos_a_eliminar = new List<TreeNode>();
            foreach (TreeNode nodo in this.nodosBuscados)
            {
                if (nodo.Nodes.Count > 0)
                    nodos_a_eliminar.Add(nodo);
            }

            foreach (TreeNode nodo in nodos_a_eliminar)
            {
                this.nodosBuscados.Remove(nodo);
            }
        }
        protected virtual void LlenarFamilia(TreeNodeCollection nodoColl, uint id_padre)
        {
            DataRow[] familia;

            familia = Datos.Select(this.id_padre + "=" + id_padre);

            foreach (DataRow row in familia)
            {
                uint id_nodo = Formateador.ToUInt32(row[this.id]);
                string nombre_visible = this.TextoVisible(row);
                TreeNodePitagoras nuevo_nodo = new TreeNodePitagoras(
                                        id_nodo,
                                        nombre_visible
                                        );

                nodoColl.Add(nuevo_nodo);
                this.LlenarFamilia(nuevo_nodo.Nodes, id_nodo);

            }
        }
        protected virtual void SeleccionarSiguienteNodosEncontrados()
        {
            if (this.nodosBuscados.Count == 0)
            {
                this.txtBusqueda.Focus();
                return;
            }

            this.Focus();

            TreeNode nodo_selecionado = this.SelectedNode;

            Predicate<TreeNode> match = this.MarchNodo(nodo_selecionado);

            int index_actual = this.nodosBuscados.FindIndex(match);

            if(index_actual == -1)
            {
                this.SelectedNode = this.nodosBuscados[0];
                this.SelectedNode.EnsureVisible();
            }
            else
            {
                int index_siguiente = index_actual + 1;

                if(index_siguiente < this.nodosBuscados.Count)
                {
                    this.SelectedNode = this.nodosBuscados[index_siguiente];
                }
                else
                {
                    this.SelectedNode = this.nodosBuscados[0];
                }
            }

            this.SelectedNode.EnsureVisible();
        }

        protected virtual Predicate<TreeNode> MarchNodo(TreeNode nodo_selecionado)
        {
            return new Predicate<TreeNode>(delegate (TreeNode node)
            {
                return node.ImageIndex == nodo_selecionado.ImageIndex ? true : false;
            });
        }

        private void SeleccionarAnteriorNodosEncontrados()
        {
            if (this.nodosBuscados.Count == 0)
            {
                this.txtBusqueda.Focus();
                return;
            }

            this.Focus();

            TreeNode nodo_selecionado = this.SelectedNode;

            Predicate<TreeNode> match = this.MarchNodo(nodo_selecionado);

            int index_actual = this.nodosBuscados.FindIndex(match);

            if (index_actual == -1)
            {
                this.SelectedNode = this.nodosBuscados[this.nodosBuscados.Count - 1];
                this.SelectedNode.EnsureVisible();
            }
            else
            {
                int index_anterior = index_actual - 1;

                if (index_anterior >= 0)
                {
                    this.SelectedNode = this.nodosBuscados[index_anterior];
                }
                else
                {
                    this.SelectedNode = this.nodosBuscados[this.nodosBuscados.Count - 1];
                }
            }

            this.SelectedNode.EnsureVisible();
        }
        private string TextoVisible(DataRow row)
        {
            if(this.tabla == Tabla.Mae_Clasificaciones)
            {
                //return Formateador.ToString(row["cod_clasificacion"]) + " - " + Formateador.ToString(row["nom_clasificacion"]);
                return Formateador.ToString(row["nom_clasificacion"]);
            }
            else if (this.tabla == Tabla.Contab_Ctas_Conts)
            {
                return Formateador.ToString(row["cta_contable"]) + " - " + Formateador.ToString(row["nom_cta_cont"]);
            }

            return Formateador.ToString(row[this.id]);
        }
        public void Buscar(string texto_buscar)
        {
            this.txtBusqueda.Text = texto_buscar;
            this.BuscarNodos();
        }
        public void BuscarYGuardarNodos(string texto_buscar, TreeNodeCollection nodos)
        {
            foreach (TreeNode nodo in nodos)
            {
                if (this.txtBusqueda.Text != "" && nodo.Text.ToUpper().Contains(texto_buscar.ToUpper()))
                {
                    this.nodosBuscados.Add(nodo);
                }
                this.BuscarYGuardarNodos(texto_buscar, nodo.Nodes);
            }
        }
        public virtual DataTable Inicializar(Tabla tabla)
        {
            this.tabla = tabla;
            if (
                tabla == Tabla.Mae_Clasificaciones
                || tabla == Tabla.Contab_Ctas_Conts)
                this.CargarLista();
            else
                Interacciones.Ex("Tabla no implementada");

            return this.Datos;
        }
        #endregion

        #region Eventos
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if(e.KeyCode == Keys.F4)
            {
                if (this.PermiteBusquedaF4)
                {
                    e.SuppressKeyPress = true;
                    this.txtBusqueda.Visible = true;
                    this.txtBusqueda.Focus();
                }
            }else if(e.KeyCode == Keys.Next)
            {
                e.SuppressKeyPress = true;
                this.SeleccionarSiguienteNodosEncontrados();
            }else if(e.KeyCode == Keys.PageUp)
            {
                e.SuppressKeyPress = true;
                this.SeleccionarAnteriorNodosEncontrados();
            }
        }
        protected override void OnDoubleClick(EventArgs e)
        {
            TreeNode nodo = this.SelectedNode;
            if (nodo != null)
            {
                if (nodo.Nodes.Count == 0 && this.permite_editar_nodos)
                {
                    //this.LabelEdit = true;
                    //nodo.BeginEdit();
                }
                else
                {
                    //nodo.ToolTipText = "No es un nodo hoja";
                }
            }
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            TreeNode nodo = this.GetNodeAt(e.X, e.Y);
            if (nodo != null)
            {
                this.SelectedNode = nodo;
                if(e.Button == MouseButtons.Right)
                {
                    if(this.permite_crear_nodos)
                    {
                        this.cmsGridPitagoras.Show(MousePosition);
                    }
                }
            }

            base.OnMouseDown(e);
        }
        private void TxtBusqueda_Leave(object sender, EventArgs e)
        {
            this.txtBusqueda.Visible = false;
        }
        private void TxtBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BuscarNodos();
            }
        }
        #endregion

    }
}
