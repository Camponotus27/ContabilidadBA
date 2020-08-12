using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class ERel_Dte_Medios_De_Pagos
    {
        uint id;
        uint id_dte;
        uint id_medios_de_pagos;
        decimal monto_pagado;
        uint numero_operacion;
        uint id_bco_ctas_ctes;
        DateTime fecha;

        public ERel_Dte_Medios_De_Pagos()
        {
        }

        public ERel_Dte_Medios_De_Pagos(uint id, decimal monto, uint numero_operacion = 0, uint id_bco_ctas_ctes = 0)
        {
            this.Id_medios_de_pagos = id;
            this.monto_pagado = monto;
            this.numero_operacion = numero_operacion;
            this.id_bco_ctas_ctes = id_bco_ctas_ctes;
        }

        public uint Id { get => id; set => id = value; }
        public uint Id_dte { get => id_dte; set => id_dte = value; }
        public uint Id_medios_de_pagos { get => id_medios_de_pagos; set => id_medios_de_pagos = value; }
        public decimal Monto_pagado { get => monto_pagado; set => monto_pagado = value; }
        public uint Numero_operacion { get => numero_operacion; set => numero_operacion = value; }
        public uint Id_bco_ctas_ctes { get => id_bco_ctas_ctes; set => id_bco_ctas_ctes = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }

        public bool ExisteUnMonto()
        {
            if (this.monto_pagado == 0)
                return false;

            return true;
        }
    }
}
