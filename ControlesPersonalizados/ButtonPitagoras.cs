using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlesPersonalizados
{
    public partial class ButtonPitagoras : Button
    {
        public ButtonPitagoras()
        {
            InitializeComponent();

            this.Size = new Size(75, 23);
            this.FlatStyle = FlatStyle.Popup;
            this.Font = new Font("Microsoft Sans Serif", 8F);
            this.ImageAlign = ContentAlignment.MiddleLeft;
            this.Size = new Size(100, 23);
            this.UseVisualStyleBackColor = true;
        }
    }
}
