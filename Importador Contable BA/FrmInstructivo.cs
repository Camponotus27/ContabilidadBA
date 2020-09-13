using ControlesPersonalizados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Importador_Contable_BA
{
    public partial class FrmInstructivo : FormPitagoras
    {
        public FrmInstructivo()
        {
            InitializeComponent();

            web.Navigate(this.urlInstructivo);
        }

        public Uri urlInstructivo = new Uri("https://parcelacionaculeo.limonay.com/aplicacioncontable/instrucciones/index.php");
    }
}
