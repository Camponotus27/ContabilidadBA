using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    public class RespuestaMovimiento : Res
    {
        private bool _isGuardarXMLSPCorrect = false;
        private bool _isImpresionCorrect = false;
        private bool _isGenerarXMLSIICorrect = false;
        private int _folio = 0;

        public bool IsGuardarXMLSPCorrect { get => _isGuardarXMLSPCorrect; set => _isGuardarXMLSPCorrect = value; }
        public int Folio { get => _folio; set => _folio = value; }
        public bool IsGenerarXMLSIICorrect { get => _isGenerarXMLSIICorrect; set => _isGenerarXMLSIICorrect = value; }
        public bool IsImpresionCorrect { get => _isImpresionCorrect; set => _isImpresionCorrect = value; }
    }
}
