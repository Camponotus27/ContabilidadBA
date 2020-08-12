using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EDTE_Referencia : Entidad
    {
        uint id;
        uint id_movimiento;
        uint id_movimiento_referencia;
        CausaAnulacion causa_referencia = CausaAnulacion.NINGUNO;

        public uint Id { get => id; set => id = value; }
        public uint Id_movimiento { get => id_movimiento; set => id_movimiento = value; }
        public uint Id_movimiento_referencia { get => id_movimiento_referencia; set => id_movimiento_referencia = value; }
        public CausaAnulacion Causa_referencia { get => causa_referencia; set => causa_referencia = value; }
    }
}
