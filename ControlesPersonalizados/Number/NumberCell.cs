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
    public partial class NumberCell : DataGridViewTextBoxCellPitagoras
    {

        int decimal_digits;
        public NumberCell() : base() {
            this.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public void SetDecimal(int decimal_digits)
        {
            this.decimal_digits = decimal_digits;
            this.Style.Format = "N" + decimal_digits.ToString();
        }

        public override Type EditType
        {
            get { return typeof(NumberEditingControl); }
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

        public override object DefaultNewRowValue
        {
            get
            {
                return 0;
            }

        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            NumberEditingControl ctl = DataGridView.EditingControl as NumberEditingControl;
            ctl.CantidadDecimales = decimal_digits;

            try
            {
                ctl.Value = Formateador.ToDecimal(this.Value);

            }
            catch (Exception)
            {
                ctl.Value = 0;
            }
        }
        
    }
}
