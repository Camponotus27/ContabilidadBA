using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    public class RespuestaCreacionActualizacion : Res
    {
        private int _newID;
        private bool _isCreado = false;
        private bool _isActualizado = false;

        public int NewID { get => _newID; set => _newID = value; }
        public bool IsCreado { get => _isCreado; set => _isCreado = value; }
        public bool IsActualizado { get => _isActualizado; set => _isActualizado = value; }
    }
}
