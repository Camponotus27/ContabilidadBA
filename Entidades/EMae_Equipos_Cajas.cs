using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable()]
    [XmlRoot(ElementName = "DMae_Equipos")]
    public class EMae_Equipos_Cajas : EMae_Equipos
    {
        uint id_caja;

        public uint Id_caja { get => id_caja; set => id_caja = value; }
    }
}
