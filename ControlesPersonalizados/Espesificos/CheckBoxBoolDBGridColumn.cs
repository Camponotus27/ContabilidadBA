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
    public partial class CheckBoxBoolDBGridColumn : DataGridViewCheckBoxColumn
    {
        public CheckBoxBoolDBGridColumn() : base()
        {
            
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
                        !value.GetType().IsAssignableFrom(typeof(CheckBoxBoolDBCell)))
                    throw new InvalidCastException("Debe especificar una instancia de TextDateTimeCell");
                base.CellTemplate = value;
            }
        }
    }
}
