using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlRoot(ElementName = "DMae_Cajas")]
    public class EMae_Cajas : Entidad
    {
        uint id;
        uint id_emp;
        uint cod_caja;
        string nom_caja;
        uint id_local;
        uint id_equipo;
        decimal monto_apertura_por_defecto;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Cod_caja { get => cod_caja; set => cod_caja = value; }
        public string Nom_caja { get => nom_caja; set => nom_caja = value; }
        public uint Id_local { get => id_local; set => id_local = value; }
        public uint Id_equipo { get => id_equipo; set => id_equipo = value; }
        public decimal Monto_apertura_por_defecto { get => monto_apertura_por_defecto; set => monto_apertura_por_defecto = value; }

        internal string Mostrar()
        {
            return this.id + " - " + this.nom_caja;
        }
    }
}
