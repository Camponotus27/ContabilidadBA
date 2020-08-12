using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EEnt_Direcciones_Despacho : Entidad
    {
        uint id;
        uint id_emp;
        uint id_entidad;
        uint cod_dir;
        string dir;
        uint id_com;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Id_entidad { get => id_entidad; set => id_entidad = value; }
        public uint Cod_dir { get => cod_dir; set => cod_dir = value; }
        public string Dir { get => dir; set => dir = value; }
        public uint Id_com { get => id_com; set => id_com = value; }
    }
}
