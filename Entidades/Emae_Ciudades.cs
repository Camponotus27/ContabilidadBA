using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class EMae_Ciudades : Entidad
    {
        /// <summary>
        /// ID de la Ciudad, tipo uint _> int UNSIGNED
        /// </summary>
        uint id;
        string nom_ciudad;
        uint id_region;
     


        public uint Id { get => id; set => id = value; }
        public string Nom_ciudad { get => nom_ciudad; set => nom_ciudad = value; }
        public uint Id_region { get => id_region; set => id_region = value; }
    }
}
