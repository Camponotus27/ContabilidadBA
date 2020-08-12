using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable()]
    public class EMae_Empresas_Comuna_Ciudad : EMae_Empresas
    {
        string nom_comuna;
        string nom_ciudad;

        [XmlIgnoreAttribute]
        public string Nom_comuna { get => nom_comuna; set => nom_comuna = value; }
        [XmlIgnoreAttribute]
        public string Nom_ciudad { get => nom_ciudad; set => nom_ciudad = value; }
    }
}
