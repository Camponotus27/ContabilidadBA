using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    [Serializable()]
    public class EMae_Paises : Entidad
    {
        uint id;
        string nom_pais;
        uint cod_telefonico;
        uint cod_sii;

        public uint Id { get => id; set => id = value; }
        public string Nom_pais { get => nom_pais; set => nom_pais = value; }
        public uint Cod_telefonico { get => cod_telefonico; set => cod_telefonico = value; }
        public uint Cod_sii { get => cod_sii; set => cod_sii = value; }

    }
}
