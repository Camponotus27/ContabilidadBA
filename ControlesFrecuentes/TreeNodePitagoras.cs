using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.ControlesFrecuentes
{
    public class TreeNodePitagoras : TreeNode
    {
        private uint id = 0;

        public uint ID { get => id; set => id = value; }

        public TreeNodePitagoras(uint id, string texto)
        {
            this.ID = id;
            this.Text = texto;
        }
    }
}
