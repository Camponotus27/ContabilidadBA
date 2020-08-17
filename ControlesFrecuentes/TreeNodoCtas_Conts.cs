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
    public partial class TreeNodoCtas_Conts : TreeNode
    {
        public TreeNodoCtas_Conts(EContab_Ctas_Conts ctas_cont)
        {
            this.ctas_cont = ctas_cont;
            this.ReasignarNombre();
        }

        public void ReasignarNombre()
        {
            this.Text = this.ctas_cont.Cta_contable + " - " + this.ctas_cont.Nom_cta_cont;
        }

        public void AsignarToolTip()
        {

        }


        private EContab_Ctas_Conts ctas_cont;
        public EContab_Ctas_Conts Ctas_Cont { get => ctas_cont; set => ctas_cont = value; }
    }
}
