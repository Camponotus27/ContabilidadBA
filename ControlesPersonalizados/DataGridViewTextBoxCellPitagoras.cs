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
    public partial class DataGridViewTextBoxCellPitagoras : DataGridViewTextBoxCell
    {
        public DataGridViewTextBoxCellPitagoras()
        {
            InitializeComponent();
        }

        void RecuperarColor()
        {

        }

        void AsignarColor()
        {

        }

        public override bool ReadOnly
        {
            get
            {
                return base.ReadOnly;
            }
            set
            {
                base.ReadOnly = value;

                if (!base.ReadOnly)
                {
                    this.Style.BackColor = Color.White;
                    this.Style.SelectionBackColor = Color.White;
                }
            }
        }
        
        protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (!this.ReadOnly && Cursor.Current == Cursors.Default)
            {
                Cursor.Current = Cursors.IBeam;
            }
        }

        protected override void OnMouseEnter(int rowIndex)
        {
            base.OnMouseEnter(rowIndex);

       
        }

        protected override void OnLeave(int rowIndex, bool throughMouseClick)
        {
            base.OnLeave(rowIndex, throughMouseClick);

            if (Cursor.Current == Cursors.Hand)
            {
                Cursor.Current = Cursors.Default;
            }
        }

    }
}
