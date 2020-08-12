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
    public partial class TextBoxPassPitagoras : TextBoxPitagoras
    {
        public TextBoxPassPitagoras()
        {
            InitializeComponent();

            this.UseSystemPasswordChar = true;
            this.CharacterCasing = CharacterCasing.Normal;
        }
    }
}
