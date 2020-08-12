using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EMae_Marcas : Entidad
    {
        uint id;
        uint id_emp;
        uint cod_marca;
        string nom_marca;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Cod_marca { get => cod_marca; set => cod_marca = value; }
        public string Nom_marca { get => nom_marca; set => nom_marca = value; }
    }
}
