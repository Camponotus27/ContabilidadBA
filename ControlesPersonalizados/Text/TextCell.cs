using ControlesPersonalizados;
using Herramientas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class TextCell : DataGridViewTextBoxCellPitagoras
    {

        public TextCell() : base() { }

        public override Type EditType
        {
            get { return typeof(TextEditingControl); }
        }

        public override Type ValueType
        {
            get { return typeof(decimal?); }
        }

        protected override void OnClick(DataGridViewCellEventArgs e)
        {
            DataGridView dgv = this.DataGridView;
            base.OnClick(e);
            if (!dgv.IsCurrentCellInEditMode)
            {   
                dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgv.BeginEdit(false);
            }
        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);


            TextEditingControl ctl = DataGridView.EditingControl as TextEditingControl;
            TextGridColumn col = (TextGridColumn)this.OwningColumn;

            try
            {
                ctl.Text = Formateador.ToString(this.Value).ToUpper();

            }
            catch (Exception)
            {
                ctl.Text = string.Empty;
            }
        }
        
    }
}
