using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class TextDateTimeGridColumn : DataGridViewColumn
    {
        public TextDateTimeGridColumn() : base(new TextDateTimeCell()) { }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null &&
                        !value.GetType().IsAssignableFrom(typeof(TextDateTimeCell)))
                    throw new InvalidCastException("Debe especificar una instancia de TextDateTimeCell");
                base.CellTemplate = value;
            }
        }
    }
}
