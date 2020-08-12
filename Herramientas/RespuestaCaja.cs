using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herramientas
{
    public class RespuestaCaja : Res
    {
        private int correlativo = 0;
        private DateTime fecha_apertura = DateTime.Now;
        private float monto_apertura = 0;

        public int Correlativo { get => correlativo; set => correlativo = value; }
        public DateTime Fecha_apertura { get => fecha_apertura; set => fecha_apertura = value; }
        public float Monto_apertura { get => monto_apertura; set => monto_apertura = value; }
    }
}
