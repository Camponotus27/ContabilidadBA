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

namespace ControlesPersonalizados
{
    public partial class CheckBoxPitagoras : CheckBox
    {
        public CheckBoxPitagoras()
        {
            InitializeComponent();
        }

        public BoolDB Value
        {
            get
            {
                if (this.Checked)
                    return BoolDB.S;
                else
                    return BoolDB.N;
            }
            set
            {
                if (value == BoolDB.S)
                    this.Checked = true;
                else
                    this.Checked = false;
            }
        }
    }
}
