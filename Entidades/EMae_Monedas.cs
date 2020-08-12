using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EMae_Monedas : Entidad
    {
        uint id;
        uint id_emp;
        uint cod_moneda;
        string nom_moneda;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Cod_moneda { get => cod_moneda; set => cod_moneda = value; }
        public string Nom_moneda { get => nom_moneda; set => nom_moneda = value; }
    }
}
