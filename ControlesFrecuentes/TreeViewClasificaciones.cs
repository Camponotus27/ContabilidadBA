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
    public partial class TreeViewClasificaciones : TreeViewAutoLlenado
    {
        public TreeViewClasificaciones()
        {
            InitializeComponent();
            this.LabelEdit = false;
            this.PermiteCrearNodos = true;

            this.RedimencionarPicture();
        }
        public override DataTable Inicializar(Tabla tabla)
        {
            if (tabla != Tabla.Mae_Clasificaciones)
                Interacciones.Ex("El arbol de clasificaciones solo permite iniciar con la Tabla Mae_Clasificaciones");

            return base.Inicializar(tabla);
        }

        protected override Predicate<TreeNode> MarchNodo(TreeNode nodo_selecionado)
        {
            return new Predicate<TreeNode>(delegate (TreeNode node)
            {
                return ((TreeNodoClasificaciones)node).Clasificacion.Id == ((TreeNodoClasificaciones)nodo_selecionado).Clasificacion.Id ? true : false;
            });
        }
        protected override void LlenarFamilia(TreeNodeCollection nodoColl, uint id_padre)
        {
            DataRow[] familia;

            familia = this.Datos.Select(this.id_padre + "=" + id_padre);

            foreach (DataRow row in familia)
            {
                EMae_Clasificaciones clasificacion = this.ClasifiacacionDesdeRow(row);
                TreeNodoClasificaciones nuevo_nodo = new TreeNodoClasificaciones(clasificacion);
                nodoColl.Add(nuevo_nodo);
                nuevo_nodo.AsignarToolTip();
                this.LlenarFamilia(nuevo_nodo.Nodes, clasificacion.Id);

            }
        }
        protected override void MenuCrearNodoRaiz_Click(object sender, EventArgs e)
        {
            EMae_Clasificaciones clasificacion = new EMae_Clasificaciones();
            clasificacion.Nom_clasificacion = "Nuevo Nodo Raiz";
            TreeNodoClasificaciones nuevo_nodo = new TreeNodoClasificaciones(clasificacion);

            this.Nodes.Add(nuevo_nodo);
            this.SelectedNode = nuevo_nodo;
        }
        protected override void MenuCrearNodoHijo_Click(object sender, EventArgs e)
        {
            EMae_Clasificaciones clasificacion = new EMae_Clasificaciones();
            clasificacion.Nom_clasificacion = "Nuevo Nodo Hijo";
            TreeNodoClasificaciones nuevo_nodo = new TreeNodoClasificaciones(clasificacion);

            this.SelectedNode.Nodes.Add(nuevo_nodo);
            this.SelectedNode = nuevo_nodo;
        }
        private EMae_Clasificaciones ClasifiacacionDesdeRow(DataRow row)
        {
            EMae_Clasificaciones clasificacion = new EMae_Clasificaciones();

            clasificacion.Id = Formateador.ToUInt32(row["id"]);
            clasificacion.Id_padre = Formateador.ToUInt32(row["id_padre"]);
            clasificacion.Nom_clasificacion = Formateador.ToString(row["nom_clasificacion"]);
            //clasificacion.Cod_clasificacion = Formateador.ToString(row["cod_clasificacion"]);
            clasificacion.Margen = Formateador.ToDecimal(row["margen"]);

            return clasificacion;
        }

        internal void DelecionarNodo()
        {
            this.SelectedNode = null;
            this.RetraerNodos(this.Nodes);
        }

        private void RetraerNodos(TreeNodeCollection nodes)
        {
            foreach(TreeNode nodo in nodes)
            {
                nodo.Collapse();
            }
        }

        public EMae_Clasificaciones Clasificacion
        {
            get
            {
                TreeNodoClasificaciones nodo = (TreeNodoClasificaciones)this.SelectedNode;
                if (nodo == null)
                    return null;

                return nodo.Clasificacion;
            }
        }

        internal void ActualizarInformacionNodos(TreeNodeCollection nodes)
        {
            foreach(TreeNodoClasificaciones nodo in nodes)
            {
                nodo.ActualizarNombreYToopTip();
                this.ActualizarInformacionNodos(nodo.Nodes);
            }
        }

        internal void SeleccionarClasificacion(EMae_Clasificaciones clasificacion)
        {
            this.BuscarClasifiacion(this.Nodes, clasificacion);
        }

        private void BuscarClasifiacion(TreeNodeCollection nodes, EMae_Clasificaciones clasificacion)
        {
            foreach(TreeNodoClasificaciones nodo in nodes)
            {
                if (nodo.Clasificacion.Id == clasificacion.Id)
                {
                    this.SelectedNode = nodo;
                    return;
                }
                else
                {
                    this.BuscarClasifiacion(nodo.Nodes, clasificacion);
                }
                
            }
        }
    }
}
