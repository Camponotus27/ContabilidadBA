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
    public partial class EsperaAsyncAwaitVerRegistro : Form
    {
        public EsperaAsyncAwaitVerRegistro(string registro)
        {
            InitializeComponent();

            this.txtRegistro.Text = registro;
        }
    }
}
