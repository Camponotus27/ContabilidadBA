using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    public class RespuestaCreacion : Res
    {
        private int _newID;

        public int NewID { get => _newID; set => _newID = value; }
    }
}
