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
    public partial class TextGridColumn : DataGridViewColumn
    {
        public TextGridColumn() : base(new TextCell()) {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                        !value.GetType().IsAssignableFrom(typeof(TextCell)))
                    throw new InvalidCastException("Debe especificar una instancia de NumericGridCell");
                base.CellTemplate = value;
            }
        }

        public override object Clone()
        {
            TextGridColumn newColumn = (TextGridColumn)base.Clone();
            return newColumn;
        }
    }
}
