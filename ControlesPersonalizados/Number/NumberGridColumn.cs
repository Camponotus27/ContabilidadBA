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
    public partial class NumberGridColumn : DataGridViewColumn
    {
        public NumberGridColumn() : base(new NumberCell()) {
            
        }

        private NumberFormatInfo _numberFormat;
        private int _decimalDigits = 0;


        [
            Category("Appearance"),
            Description("Indica la cantidad de decimales que apareceran")
        ]
        public int DecimalDigits
        {
            get
            {
                if (_decimalDigits < 0)
                    return CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalDigits;
                else
                    return _decimalDigits;
            }
            set {

                _decimalDigits = value;

                DataGridViewCell cell_template = this.CellTemplate;

                if (cell_template is NumberCell)
                {
                    NumberCell cell_template_number = (NumberCell)cell_template;
                    cell_template_number.SetDecimal(value);
                }
            }
        }

        internal NumberFormatInfo NumberFormat
        {
            get
            {
                if (_numberFormat == null)
                    _numberFormat = new NumberFormatInfo();
                _numberFormat.NumberDecimalDigits = DecimalDigits;
                return _numberFormat;
            }
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
                        !value.GetType().IsAssignableFrom(typeof(NumberCell)))
                    throw new InvalidCastException("Debe especificar una instancia de NumericGridCell");
                base.CellTemplate = value;
            }
        }

        public override object Clone()
        {
            NumberGridColumn newColumn = (NumberGridColumn)base.Clone();
            newColumn.DecimalDigits = DecimalDigits;
            return newColumn;
        }
    }
}
