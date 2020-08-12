using ControlesPersonalizados;
using Herramientas;
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
    public partial class TextDateTimeEditingControl : TextDateTimeGrid, IDataGridViewEditingControl
    {
        private DataGridView grid;
        private bool valueChanged;
       
        public TextDateTimeEditingControl() : base()
        {
            this.MaxLength = 10;
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
                string texto_temporal = this.Text;
                if (texto_temporal.Length == 10 && texto_temporal.Substring(4, 1) == "-" && texto_temporal.Substring(7, 1) == "-")
                {
                    texto_temporal = Formateador.GirarFechaConGuion(texto_temporal);
                }
                else
                {
                    texto_temporal = texto_temporal.Replace("-", "").Replace("/", "");
                    if (texto_temporal.Length == 8)
                    {
                        texto_temporal = texto_temporal.Insert(4, "-").Insert(2, "-");
                    }
                    else if (texto_temporal.Length == 6)
                    {
                        texto_temporal = texto_temporal.Insert(4, "20");
                        texto_temporal = texto_temporal.Insert(4, "-").Insert(2, "-");
                    }
                }

                
                return texto_temporal;
                //return this.Value.ToString();
            }
            set
            {
                try { this.Text = value.ToString(); }
                catch { this.Text = null; }
                //SendToGridValueChanged();
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
     
            if(context.HasFlag(DataGridViewDataErrorContexts.Commit))
            {
                try
                {
                    DateTime fecha = Convert.ToDateTime(this.EditingControlFormattedValue);
                    return fecha.ToString("dd-MM-yyyy");
                }
                catch
                {
                    return "";
                }

            }
            else
            {
                return EditingControlFormattedValue;
            }
        }

        public void PrepareEditingControlForEdit(bool selectAll)
        {

        }

        #endregion
    }

}
