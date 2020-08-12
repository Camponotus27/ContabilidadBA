using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class CMSGridPitagoras : ContextMenuStrip
    {
        private int indexRow;
        private int indexColumn;

        public CMSGridPitagoras()
        {
            InitializeComponent();

            this.InicializarComponentesPersonalizados();
        }

        private void InicializarComponentesPersonalizados()
        {
            
        }

        public CMSGridPitagoras(IContainer container)
        {

            container.Add(this);

            InitializeComponent();
            this.InicializarComponentesPersonalizados();

        }

        public int IndexRow { get => indexRow; set => indexRow = value; }
        public int IndexColumn { get => indexColumn; set => indexColumn = value; }

        Dictionary<ToolStripMenuItem, string> items_desabilitados;

        public void Desabilitar(ToolStripMenuItem cms_item, string texto)
        {
            if (items_desabilitados == null)
                items_desabilitados = new Dictionary<ToolStripMenuItem, string>();

            
            if (items_desabilitados.ContainsKey(cms_item))
            {
                this.Habilitar(cms_item);
            }
            else
            {
                cms_item.Enabled = false;
                this.items_desabilitados.Add(cms_item, "(" + texto + ")");
            }
        }

        private void Habilitar(ToolStripMenuItem cms_item)
        {
            if (items_desabilitados.ContainsKey(cms_item))
            {
                cms_item.Enabled = true;
                cms_item.Text = cms_item.Text.Replace(items_desabilitados[cms_item], string.Empty);
            }
            
        }
    }
}
