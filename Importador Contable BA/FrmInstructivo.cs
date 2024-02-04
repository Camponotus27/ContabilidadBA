using ControlesPersonalizados;
using System;

namespace Importador_Contable_BA
{
    public partial class FrmInstructivo : FormPitagoras
    {
        public FrmInstructivo()
        {
            InitializeComponent();

            web.Navigate(urlInstructivo);
        }

        public Uri urlInstructivo = new Uri("https://parcelacionaculeo.limonay.com/aplicacioncontable/instrucciones/index.php");
    }
}
