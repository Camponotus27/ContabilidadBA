using Herramientas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class GridPitagoras : DataGridView
    {
        private bool sePuedeCrearLieneaNuevaConEnter = true;
        private bool mantenerPorLoMenosUnaFila = false;
        private CMSGridPitagoras cMSGridPitagotas;

        public bool SePuedeCrearLieneaNuevaConEnter { get => sePuedeCrearLieneaNuevaConEnter; set => sePuedeCrearLieneaNuevaConEnter = value; }
        public bool MantenerPorLoMenosUnaFila { get => mantenerPorLoMenosUnaFila; set => mantenerPorLoMenosUnaFila = value; }
        public CMSGridPitagoras CMSGridPitagotas { get => cMSGridPitagotas; set => cMSGridPitagotas = value; }

        public GridPitagoras()
        {
            InitializeComponent();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            char s = Char.ToUpper(e.KeyChar);
            e.KeyChar = s;
        }

        protected override void OnDataSourceChanged(EventArgs e)
        {
            base.OnDataSourceChanged(e);
            this.ReadOnly = this.read_only;
        }

        private bool read_only;
        [
            TypeConverter(typeof(bool)),
            Description("India si el control es de solo lectura Pitagoras")
        ]
        public new bool ReadOnly
        {
            get
            {
                return read_only;
            }
            set {
                if (!read_only && value)
                {
                    // se guarda el estado de las columnas
                    this.estado_previo_cambio_read_only = new Dictionary<int, bool>();
                    if (this.Columns != null)
                    {
                        foreach (DataGridViewColumn col in this.Columns)
                        {
                            this.estado_previo_cambio_read_only.Add(col.Index, col.ReadOnly);
                            col.ReadOnly = value;
                        }
                    }
                }
                else if (read_only && !value)
                {
                    if (this.estado_previo_cambio_read_only != null)
                    {
                        foreach (KeyValuePair<int, bool> keyValuePair in this.estado_previo_cambio_read_only)
                        {
                            this.Columns[keyValuePair.Key].ReadOnly = keyValuePair.Value;
                        }
                    }
                }else if(value)
                {
                    if (this.Columns != null)
                    {
                        foreach (DataGridViewColumn col in this.Columns)
                        {
                            col.ReadOnly = value;
                        }
                    }
                }

                read_only = value;
            }
        }

        protected override void OnCellMouseDown(DataGridViewCellMouseEventArgs e)
        {
            base.OnCellMouseDown(e);

            if (e.RowIndex != -1 && e.ColumnIndex != -1 && e.Button == MouseButtons.Right && this.CMSGridPitagotas != null)
            {
                this.EndEdit();
                this.CurrentCell = this.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.CMSGridPitagotas.IndexRow = e.RowIndex;
                this.CMSGridPitagotas.IndexColumn = e.ColumnIndex;
                this.CMSGridPitagotas.Show(MousePosition);
            }
        }

        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            DataGridViewCell current_cell = this.CurrentCell;
            if (
                current_cell != null
                && current_cell.OwningColumn is DataGridViewComboBoxColumn // si es tipo combo
                && this.Focused
                && !current_cell.ReadOnly // si no es read only
                && !this.IsCurrentCellInEditMode // si no la estoy editando
                && !current_cell.OwningColumn.ReadOnly
                )
            {
                this.BeginEdit(true);
            }


            base.OnCellClick(e);
        }

        protected override void OnCurrentCellDirtyStateChanged(EventArgs e)
        {
            base.OnCurrentCellDirtyStateChanged(e);

            if (this.IsCurrentCellDirty
                &&
                (
                    this.CurrentCell.OwningColumn is DataGridViewCheckBoxColumn
                    || this.CurrentCell.OwningColumn is DataGridViewComboBoxColumn
                )
               )
            {
                this.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ProcessTabKey(e.KeyData);
                return true;
            }
            return base.ProcessDataGridViewKey(e);
        }

        protected override void OnBindingContextChanged(EventArgs e)
        {
            base.OnBindingContextChanged(e);
        }

        protected override void OnReadOnlyChanged(EventArgs e)
        {
            base.OnReadOnlyChanged(e);
        }

        Dictionary<int, bool> estado_previo_cambio_read_only;

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                if (this.EstoyEnLaUltimaCelda())
                {
                    this.ProcessEnterKey(keyData);
                }
                else
                {
                    this.ProcessTabKey(keyData);
                }

                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (
              e.KeyCode == Keys.Enter
              && this.SePuedeCrearLieneaNuevaConEnter
              && this.EstoyEnLaUltimaCelda())
            {
                this.CrearYAvanzaAUnaNuevaFila();
            }
        }

        protected override void OnRowsRemoved(DataGridViewRowsRemovedEventArgs e)
        {
            base.OnRowsRemoved(e);
            this.MetodoMantenerPorLoMenosUnaFila();
        }


        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            this.MetodoMantenerPorLoMenosUnaFila();
        }

        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            base.OnEditingControlShowing(e);

            if (e.Control is NumberEditingControl)
            {
                NumberEditingControl control = (NumberEditingControl)e.Control;
                control.ShortcutsEnabled = false;
            }
            else if (e.Control is DataGridViewTextBoxEditingControl)
            {
                DataGridViewTextBoxEditingControl control = (DataGridViewTextBoxEditingControl)e.Control;
                control.ShortcutsEnabled = false;
            }else if (e.Control is DataGridViewComboBoxEditingControl)
            {
                DataGridViewComboBoxEditingControl control = (DataGridViewComboBoxEditingControl)e.Control;
                if (control.Focused)
                {
                    control.DroppedDown = true;
                }
            }
        }

        private void MetodoMantenerPorLoMenosUnaFila()
        {
            if (this.mantenerPorLoMenosUnaFila && this.Rows.Count == 0)
                this.Rows.Add();
        }

        private void CrearYAvanzaAUnaNuevaFila()
        {
           if(!this.isBindingSourse())
            {
                int posicion_nueva_fila = this.Rows.Add();

                bool encontró_posicion = false;
                int columna_actual = 0;
                while (!encontró_posicion && columna_actual < this.Columns.Count)
                {
                    if (this.Rows[posicion_nueva_fila].Cells[columna_actual].Visible)
                    {
                        encontró_posicion = true;
                        break;
                    }
                    else
                        columna_actual++;
                }

                if (encontró_posicion)
                    this.CurrentCell = this.Rows[posicion_nueva_fila].Cells[columna_actual];
                else
                    Interacciones.MessajeBoxAviso("No se encontro una ceda visible para marcar");
            }
        }

        private bool isBindingSourse()
        {
            return this.DataBindings != null;
        }

        private bool EstoyEnLaUltimaCelda()
        {
            DataGridViewCell cell = this.CurrentCell;
            int total_filas = this.Rows.Count;
            int total_colunnas = this.Columns.Count;

            if (total_colunnas == 0)
                return false;

            if (cell != null)
            {
                if (cell.RowIndex == total_filas - 1 && cell.ColumnIndex == total_colunnas - 1)
                    return true;
            }

            return false;
        }

        [DllImport("user32")]
        private static extern IntPtr GetWindowDC(IntPtr hwnd);
        private const int WM_NCPAINT = 0x85;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCPAINT && this.Focused && Parametros.anchoBorde != 0)
            {
                var dc = GetWindowDC(Handle);
                using (Graphics g = Graphics.FromHdc(dc))
                {
                    g.DrawRectangle(new Pen(Parametros.colorBorde, Parametros.anchoBorde), 0, 0, Width - 0, Height - 0);
                }
            }
        }

        #region Validacion
        public bool ErroresRow(int newIndex)
        {
            foreach (DataGridViewCell cell in this.Rows[newIndex].Cells)
            {
                if (!string.IsNullOrEmpty(cell.ErrorText))
                    return true;
            }

            return false;
        }

        public void RowsError(int newIndex, string descripcionError = "")
        {
            if (descripcionError == string.Empty)
            {
                this.Rows[newIndex].DefaultCellStyle.BackColor = this.DefaultCellStyle.BackColor;
                this.Rows[newIndex].DefaultCellStyle.SelectionBackColor = this.DefaultCellStyle.SelectionBackColor;
            }
            else
            {
                this.Rows[newIndex].DefaultCellStyle.BackColor = Color.LightCoral;
                this.Rows[newIndex].DefaultCellStyle.SelectionBackColor = Color.LightCoral;
            }

        }

        public int ContadorCeldaValor(string nombre_columna, object valor)
        {
            int contador = 0;
            if (this.Columns.Contains(nombre_columna))
            {
                foreach (DataGridViewRow row in this.Rows)
                {
                    if (Formateador.ToString(row.Cells[nombre_columna].Value) == Formateador.ToString(valor))
                        contador++;
                }
            }
            else
            {
                Interacciones.Ex("No se encontro la columna proporcioanda");
            }

            return contador;
        }

        public bool Errores()
        {
            foreach (DataGridViewRow row in this.Rows)
            {
                if (this.ErroresRow(row.Index))
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Causa errores en la columna indicada en los que la id este repeda. No se
        /// toma en cuanta como repetidos a dos registros con valor cero, nulo o vacio
        /// </summary>
        /// <param name="nombre_columna">Nombre de la columna a validar</param>
        /// <param name="texto_del_error">Texto del error aplicado a la columna</param>
        public void ValidarIDRepetidas(string nombre_columna,  string texto_del_error = "Repetido")
        {

            var result = from item in this.Rows.Cast<DataGridViewRow>()
                         group item by Formateador.ToString(item.Cells[nombre_columna].Value) into g
                         select new
                         {
                             Value = g.Key,
                             rows = g
                         };

            foreach (DataGridViewRow row in this.Rows)
            {
                string error_actual = row.Cells[nombre_columna].ErrorText;
                if (error_actual == texto_del_error)
                    row.Cells[nombre_columna].ErrorText = string.Empty;
            }

            foreach (var item in result)
            {
                if (item.rows.Count() > 1 && Formateador.ToInt32(item.Value) != 0)
                {
                    foreach (DataGridViewRow row in item.rows)
                    {
                        string error_actual = row.Cells[nombre_columna].ErrorText;
                        if(string.IsNullOrEmpty(error_actual))
                        row.Cells[nombre_columna].ErrorText = texto_del_error;
                    }
                }
            }
        }

        /// <summary>
        ///  Causa errores en la columna indicada en los que los regitros esten repeditos.
        /// </summary>
        /// <param name="nombre_columna"></param>
        /// <param name="texto_del_error"></param>
        public void ValidasStrRepetidos(string nombre_columna, string texto_del_error = "Repetido")
        {
            var result = from item in this.Rows.Cast<DataGridViewRow>()
                         group item by Formateador.ToString(item.Cells[nombre_columna].Value) into g
                         select new
                         {
                             Value = g.Key,
                             rows = g
                         };

            foreach (DataGridViewRow row in this.Rows)
            {
                row.Cells[nombre_columna].ErrorText = string.Empty;
            }

            foreach (var item in result)
            {
                if (item.rows.Count() > 1)
                {
                    foreach (DataGridViewRow row in item.rows)
                    {
                        row.Cells[nombre_columna].ErrorText = texto_del_error;
                    }
                }
            }

            this.Refresh();
        }
        #endregion
    }
}
