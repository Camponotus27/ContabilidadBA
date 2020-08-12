using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EMae_Regiones : Entidad
    {
        uint id;
        string nom_region;
        uint id_pais;

        public uint Id { get => id; set => id = value; }
        public string Nom_region { get => nom_region; set => nom_region = value; }
        public uint Id_pais { get => id_pais; set => id_pais = value; }
    }
}
