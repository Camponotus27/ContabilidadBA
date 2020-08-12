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
    public partial class TextDateTimeCell : DataGridViewTextBoxCell
    {
        public TextDateTimeCell() : base() {

            this.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        public override Type EditType
        {
            get { return typeof(TextDateTimeEditingControl); }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(DateTime?);
            }
        }

        protected override void OnClick(DataGridViewCellEventArgs e)
        {
            base.OnClick(e);
        }

        public override object DefaultNewRowValue
        {
            get
            {
                object a = base.DefaultNewRowValue;

                return null;
            }

        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

            /*
            TextDateTimeEditingControl ctl = DataGridView.EditingControl as TextDateTimeEditingControl;


            try
            {
                ctl.Text = Convert.ToDateTime(this.Value);

            }
            catch (Exception)
            {
                ctl.Value = null;
            }*/

        }
    }
}
