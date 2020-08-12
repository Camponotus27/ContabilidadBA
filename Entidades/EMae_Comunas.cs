using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EMae_Comunas : Entidad
    {
        uint id;
        string nom_comuna;
        uint id_ciudad;
        uint comu_orden;


        public uint Id { get => id; set => id = value; }
        public string Nom_comuna { get => nom_comuna; set => nom_comuna = value; }
        public uint Id_ciudad { get => id_ciudad; set => id_ciudad = value; }
        public uint Comu_orden { get => comu_orden; set => comu_orden = value; }

    }
}
