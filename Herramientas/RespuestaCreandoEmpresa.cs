using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    public class RespuestaCreandoEmpresa : Res
    {
        private bool _isValidRutRepresentante;

        public bool IsValidRutRepresentante { get => _isValidRutRepresentante; set => _isValidRutRepresentante = value; }

        private bool _isValidRutRepresentanteLegal;

        public bool IsValidRutRepresentanteLegal { get => _isValidRutRepresentanteLegal; set => _isValidRutRepresentanteLegal = value; }
    }
}
