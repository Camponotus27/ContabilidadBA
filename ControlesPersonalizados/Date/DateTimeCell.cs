using ControlesPersonalizados;
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
    public partial class DateTimeCell : DataGridViewTextBoxCell
    {
        public DateTimeCell() : base() {

        }

        public override Type EditType
        {
            get { return typeof(DateTimeEditingControl); }
        }

        public override Type ValueType
        {
            get { return typeof(DateTime?); }
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
                object defaultValue = base.DefaultNewRowValue;
                if (defaultValue is DateTime)
                    return defaultValue;
                else
                    return null;
            }

        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            
            DateTimeEditingControl ctl = DataGridView.EditingControl as DateTimeEditingControl;

            try
            {
                if (this.Value == null)
                    ctl.AnularFecha();
                else
                    ctl.Value = (DateTime)this.Value;

            }
            catch (Exception)
            {
                ctl.AnularFecha();
            }

            if (dataGridViewCellStyle.Format.Length == 1)
            {
                string[] patterns = DateTimeFormatInfo.CurrentInfo.GetAllDateTimePatterns(dataGridViewCellStyle.Format.ToCharArray()[0]);
                if (patterns.Length > 0)
                    ctl.CustomFormat = patterns[0].ToString();
                else
                    ctl.CustomFormat = dataGridViewCellStyle.Format;
            }
            else
                ctl.CustomFormat = dataGridViewCellStyle.Format;
        }
    }
}
