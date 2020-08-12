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
    public partial class ConjuntoTextBoxPassPitagoras : UserControl
    {
        public new string Text
        {
            get
            {
                return this.txt_pass.Text;
            }
            set
            {
                this.txt_pass.Text = value;
            }
        }

        /// <summary>
        /// En este caso es igual que el Text
        /// </summary>
        public string Value
        {
            get
            {
                return this.Text;
            }
            set
            {
                this.Text = value;
            }
        }

        public bool MascaraPass
        {
            get
            {
                return this.txt_pass.UseSystemPasswordChar;
            }
            set
            {
                this.check_box.Checked = value;
            }
        }

        public TextBoxPitagoras GetTextBox
        {
            get
            {
                return this.txt_pass;
            }
        }

        public ConjuntoTextBoxPassPitagoras()
        {
            InitializeComponent();

            this.check_box.Checked = true;

            this.check_box.CheckedChanged += (sender, e) => {
                this.txt_pass.UseSystemPasswordChar = this.check_box.Checked;
            };
        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConjuntoTextBoxPassPitagoras_Resize(object sender, EventArgs e)
        {
            int margen_derecha_check_box = 2;

            this.check_box.Location = new Point(this.Size.Width - this.check_box.Width - margen_derecha_check_box, this.check_box.Location.Y);

            this.txt_pass.Top = 1;
            this.txt_pass.Left = 1;
            this.txt_pass.Size = new Size(this.Width - this.txt_pass.Left - this.check_box.Width - (margen_derecha_check_box * 2), this.txt_pass.Height);
        }

        private void ConjuntoTextBoxPassPitagoras_Load(object sender, EventArgs e)
        {
            this.ConjuntoTextBoxPassPitagoras_Resize(this, new EventArgs());
        }

        private void txt_pass_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
