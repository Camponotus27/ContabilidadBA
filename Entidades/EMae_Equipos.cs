using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable()]
    public class EMae_Equipos : Entidad
    {
        uint id;
        uint id_emp;
        uint id_local;
        string nom_equipo;
        string mac;
        DateTime? ultima_actividad;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Id_local { get => id_local; set => id_local = value; }
        public string Nom_equipo {
            get
            {
                if (string.IsNullOrEmpty(nom_equipo))
                    return Formateador.NombreEquipo();

                return nom_equipo;
            }
            set => nom_equipo = value; }
        public string Mac { get => mac; set => mac = value; }
        public DateTime? Ultima_actividad { get => ultima_actividad; set => ultima_actividad = value; }
    }
}
