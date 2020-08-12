using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EBco_Ctas_Ctes : Entidad
    {
        uint id;
        uint id_emp;
        uint id_banco;
        string num_cta_cte;
        DateTime? fecha_apertura;
        uint id_moneda;
        uint id_cta_cont;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Id_banco { get => id_banco; set => id_banco = value; }
        public string Num_cta_cte { get => num_cta_cte; set => num_cta_cte = value; }
        public DateTime? Fecha_apertura { get => fecha_apertura; set => fecha_apertura = value; }
        public uint Id_moneda { get => id_moneda; set => id_moneda = value; }
        public uint Id_cta_cont { get => id_cta_cont; set => id_cta_cont = value; }
    }
}
