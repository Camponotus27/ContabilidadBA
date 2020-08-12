using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class NumberEditingControl : TextBoxNumeroPitagoras, IDataGridViewEditingControl
    {
        private DataGridView grid;
        private bool valueChanged;
       
        public NumberEditingControl()
        {
            
        }

        public void SendToGridValueChanged()
        {
            valueChanged = true;
            if (grid != null)
                grid.NotifyCurrentCellDirty(true);
        }

        #region Miembros de IDataGridViewEditingControl

        public DataGridView EditingControlDataGridView
        {
            get { return grid; }
            set { grid = value; }
        }

        

        public int EditingControlRowIndex { get; set; }

        public bool EditingControlValueChanged
        {
            get { return valueChanged; }
            set { valueChanged = value; }
        }

        public Cursor EditingPanelCursor
        {
            get { return base.Cursor; }
        }

        public bool RepositionEditingControlOnValueChange
        {
            get { return false; }
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            this.Font = dataGridViewCellStyle.Font;
            this.TextAlign = HorizontalAlignment.Right;
            this.SelectAll();
        }

        protected override void OnTextChanged(EventArgs eventargs)
        {
            base.OnTextChanged(eventargs);
            SendToGridValueChanged();
        }

        public object EditingControlFormattedValue
        {
            get
            {
                return this.Value.ToString();
            }
            set
            {
                try { this.Value = decimal.Parse((string)value); }
                catch { this.Value = 0m; }
                SendToGridValueChanged();
            }
        }


        public bool EditingControlWantsInputKey(Keys keyData, bool dataGridViewWantsInputKey)
        {
            switch (keyData & Keys.KeyCode)
            {
                case Keys.Left:
                case Keys.Up:
                case Keys.Down:
                case Keys.Right:
                case Keys.Home:
                case Keys.End:
                case Keys.PageDown:
                case Keys.PageUp:
                    return true;
                default:
                    return !dataGridViewWantsInputKey;
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return EditingControlFormattedValue;
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {
            
        }


        #endregion
    }

}
