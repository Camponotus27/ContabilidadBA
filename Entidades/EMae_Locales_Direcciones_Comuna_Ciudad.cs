using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EMae_Locales_Direcciones_Comuna_Ciudad : Entidad
    {
        uint id_local;
        string dir;
        uint id_com;
        string nom_comuna;
        string nom_ciudad;

        public uint Id_local { get => id_local; set => id_local = value; }
        public string Dir { get => dir; set => dir = value; }
        public uint Id_com { get => id_com; set => id_com = value; }
        public string Nom_comuna { get => nom_comuna; set => nom_comuna = value; }
        public string Nom_ciudad { get => nom_ciudad; set => nom_ciudad = value; }
    }
}
