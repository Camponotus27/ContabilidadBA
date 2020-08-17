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
    public partial class TreeViewCuentasContables : TreeViewAutoLlenado
    {
        public TreeViewCuentasContables()
        {
            InitializeComponent();
            this.LabelEdit = false;
            this.PermiteCrearNodos = true;

            this.RedimencionarPicture();
        }
        public override DataTable Inicializar(Tabla tabla)
        {
            if ( tabla != Tabla.Contab_Ctas_Conts)
                Interacciones.Ex("El arbol de cuentas contables solo permite iniciar con la Tabla Contab_Ctas_Conts");
            
            return base.Inicializar(tabla);
        }
        protected override void LlenarFamilia(TreeNodeCollection nodoColl, uint id_padre)
        {
            DataRow[] familia;

            familia = this.Datos.Select(this.id_padre + "=" + id_padre);

            foreach (DataRow row in familia)
            {
                EContab_Ctas_Conts cuenta_contable = this.Ctas_ContDesdeRow(row);
                TreeNodoCtas_Conts nuevo_nodo = new TreeNodoCtas_Conts(cuenta_contable);
                nodoColl.Add(nuevo_nodo);
                nuevo_nodo.AsignarToolTip();
                this.LlenarFamilia(nuevo_nodo.Nodes, cuenta_contable.Id);

            }
        }
        protected override void MenuCrearNodoRaiz_Click(object sender, EventArgs e)
        {
            EContab_Ctas_Conts cuenta_contable = new EContab_Ctas_Conts();
            cuenta_contable.Nom_cta_cont = "Nuevo Nodo Raiz";
            TreeNodoCtas_Conts nuevo_nodo = new TreeNodoCtas_Conts(cuenta_contable);

            this.Nodes.Add(nuevo_nodo);
            this.SelectedNode = nuevo_nodo;
        }
        protected override Predicate<TreeNode> MarchNodo(TreeNode nodo_selecionado)
        {
            return new Predicate<TreeNode>(delegate (TreeNode node)
            {
                return ((TreeNodoCtas_Conts)node).Ctas_Cont.Id == ((TreeNodoCtas_Conts)nodo_selecionado).Ctas_Cont.Id ? true : false;
            });
        }
        internal BindingList<EContab_Ctas_Conts> CuentasSelecionadas()
        {
            TreeNode nodo_actual = this.SelectedNode;

            if (this.EsNodoHijo(nodo_actual))
            {
                return new BindingList<EContab_Ctas_Conts>()
                {
                    ((TreeNodoCtas_Conts)nodo_actual).Ctas_Cont
                };
            }

            return ObtenerListadoClasificacionesDeUnNodo(nodo_actual);
        }

        private BindingList<EContab_Ctas_Conts> ObtenerListadoClasificacionesDeUnNodo(TreeNode nodo_actual)
        {
            BindingList<EContab_Ctas_Conts> listado = new BindingList<EContab_Ctas_Conts>();
            foreach (TreeNode nodo in nodo_actual.Nodes)
            {
                TreeNodoCtas_Conts nodo_cuenta_contable = (TreeNodoCtas_Conts)nodo;
                listado.Add(nodo_cuenta_contable.Ctas_Cont);
            }

            return listado;
        }

        protected override void MenuCrearNodoHijo_Click(object sender, EventArgs e)
        {
            EContab_Ctas_Conts cuenta_contable = new EContab_Ctas_Conts();
            cuenta_contable.Nom_cta_cont = "Nuevo Nodo Hijo";
            TreeNodoCtas_Conts nuevo_nodo = new TreeNodoCtas_Conts(cuenta_contable);

            this.SelectedNode.Nodes.Add(nuevo_nodo);
            this.SelectedNode = nuevo_nodo;
        }
        private EContab_Ctas_Conts Ctas_ContDesdeRow(DataRow row)
        {
            EContab_Ctas_Conts cuenta_contable = new EContab_Ctas_Conts();

            cuenta_contable.Id = Formateador.ToUInt32(row["id"]);
            cuenta_contable.Id_padre = Formateador.ToUInt32(row["id_padre"]);
            cuenta_contable.Cta_contable = Formateador.ToString(row["cta_contable"]);
            cuenta_contable.Nom_cta_cont = Formateador.ToString(row["nom_cta_cont"]);

            cuenta_contable.Habilitada = (BoolDB)Enums.ToBoolDB(row["habilitada"]);
            cuenta_contable.Imputable = (BoolDB)Enums.ToBoolDB(row["imputable"]);
            cuenta_contable.Centro_costo = (BoolDB)Enums.ToBoolDB(row["centro_costo"]);
            cuenta_contable.Conciliacion = (BoolDB)Enums.ToBoolDB(row["conciliacion"]);
            cuenta_contable.Capital_propio = (BoolDB)Enums.ToBoolDB(row["capital_propio"]);
            cuenta_contable.Flu = (BoolDB)Enums.ToBoolDB(row["flu"]);
            cuenta_contable.Ifrs = (BoolDB)Enums.ToBoolDB(row["ifrs"]);
            cuenta_contable.Analisis = (BoolDB)Enums.ToBoolDB(row["analisis"]);
            cuenta_contable.Form1847 = (BoolDB)Enums.ToBoolDB(row["form1847"]);
            cuenta_contable.Form29 = (BoolDB)Enums.ToBoolDB(row["form29"]);

            cuenta_contable.ResetearCambioNombreoCuente();

            return cuenta_contable;
        }

        internal void TodosLosPadresImputables()
        {
            this.TodoLosPagresImputablesNodos(this.Nodes);
        }

        private void TodoLosPagresImputablesNodos(TreeNodeCollection nodes)
        {
            foreach (TreeNodoCtas_Conts nodo in nodes)
            {
                if(!this.EsNodoHijo(nodo))
                    nodo.Ctas_Cont.Imputable = BoolDB.N;

                this.TodoLosPagresImputablesNodos(nodo.Nodes);
            }
        }

        public EContab_Ctas_Conts Ctas_Cont
        {
            get
            {
                TreeNodoCtas_Conts nodo = (TreeNodoCtas_Conts)this.SelectedNode;
                if (nodo == null)
                    return null;

                return nodo.Ctas_Cont;
            }
        }

        internal void ActualzarNombreNodoSelecionadoEHijos()
        {
            TreeNodoCtas_Conts nodo = (TreeNodoCtas_Conts)this.SelectedNode;
            nodo.ReasignarNombre();

            this.ActualizarNombreNodos(nodo.Nodes);
        }

        private void ActualizarNombreNodos(TreeNodeCollection nodes)
        {
            foreach(TreeNode nodo_temp in nodes)
            {
                TreeNodoCtas_Conts nodo = (TreeNodoCtas_Conts)nodo_temp;
                nodo.ReasignarNombre();

                this.ActualizarNombreNodos(nodo.Nodes);
            }
        }

        internal int CantidadAparicionesCtaContable(string cta_contable)
        {
            return this.SumarAparicionesCtaContableNodos(this.Nodes, cta_contable);
        }

        private int SumarAparicionesCtaContableNodos(TreeNodeCollection nodes, string cta_contable)
        {
            int cantidad = 0;

            foreach(TreeNodoCtas_Conts nodo in nodes)
            {
                if (nodo.Ctas_Cont.Cta_contable == cta_contable)
                    cantidad++;

                cantidad += this.SumarAparicionesCtaContableNodos(nodo.Nodes, cta_contable);
            }

            return cantidad;
        }
    }
}
