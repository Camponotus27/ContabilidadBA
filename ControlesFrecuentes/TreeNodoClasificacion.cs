using Entidades;
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
    public partial class TreeNodoClasificaciones : TreeNode
    {
        public TreeNodoClasificaciones(EMae_Clasificaciones clasificacion)
        {
            this.clasificacion = clasificacion;

            this.Text = clasificacion.Nom_clasificacion;
        }

        public void AsignarToolTip()
        {
            if (this.clasificacion.Margen != 0)
            {
                this.ToolTipText = "Margen: " + this.clasificacion.Margen.ToString() + "%";
            }
            else
            {
                this.AsignarMargenHeredad(this);
            }
        }

        private void AsignarMargenHeredad(TreeNodoClasificaciones treeNodoClasificaciones)
        {
            if (treeNodoClasificaciones.Level > 0)
            {
                if (treeNodoClasificaciones.clasificacion.Margen == 0)
                {
                    this.AsignarMargenHeredad((TreeNodoClasificaciones)treeNodoClasificaciones.Parent);
                }
                else
                {
                    this.ToolTipText = "Margen Heredado: " + treeNodoClasificaciones.clasificacion.Margen.ToString() + "%";
                }
            }
            else
            {
                this.ToolTipText = "Margen Heredado: " + treeNodoClasificaciones.clasificacion.Margen.ToString() + "%";
            }
        }

        private EMae_Clasificaciones clasificacion;
        public EMae_Clasificaciones Clasificacion { get => clasificacion; set => clasificacion = value; }

        public void ActualizarNombreYToopTip()
        {
            this.Text = clasificacion.Nom_clasificacion;
            this.AsignarToolTip();
        }
    }
}
