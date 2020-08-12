using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ERel_Emp_Medios_De_Pagos : Entidad
    {
        uint id;
        uint id_emp;
        uint id_medios_de_pagos;
        BoolDB habilitada;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Id_medios_de_pagos { get => id_medios_de_pagos; set => id_medios_de_pagos = value; }
        public BoolDB Habilitada { get => habilitada; set => habilitada = value; }
    }
}
