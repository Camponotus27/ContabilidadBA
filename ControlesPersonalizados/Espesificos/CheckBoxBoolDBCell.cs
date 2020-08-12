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

namespace ControlesPersonalizados.Espesificos
{
    public partial class CheckBoxBoolDBCell : DataGridViewTextBoxCell
    {
        public CheckBoxBoolDBCell() : base()
        {

        }

        public override Type EditType
        {
            get { return typeof(CheckBoxBoolDBEditingControl); }
        }

        public override Type ValueType
        {
            get
            {
                return typeof(BoolDB);
            }
        }


        public override object DefaultNewRowValue
        {
            get
            {
                return BoolDB.N;
            }

        }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
        }
    }
}
