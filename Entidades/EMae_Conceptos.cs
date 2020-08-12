using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EMae_Conceptos : Entidad
    {
        uint id;
        uint id_emp;
        IngEgre tipo_concepto;
        uint cod_concepto;
        string nom_concepto;
        uint id_cta_cont;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public IngEgre Tipo_concepto { get => tipo_concepto; set => tipo_concepto = value; }
        public uint Cod_concepto { get => cod_concepto; set => cod_concepto = value; }
        public string Nom_concepto { get => nom_concepto; set => nom_concepto = value; }
        public uint Id_cta_cont { get => id_cta_cont; set => id_cta_cont = value; }
    }
}
