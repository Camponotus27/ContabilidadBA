using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EMae_Unidades : Entidad
    {
        uint id;
        uint id_emp;
        string nom_unidad;
        uint cod_unidad;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public string Nom_unidad { get => nom_unidad; set => nom_unidad = value; }
        public uint Cod_unidad { get => cod_unidad; set => cod_unidad = value; }
    }
}
