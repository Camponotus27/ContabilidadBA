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
    [XmlRoot(ElementName = "DDTE_Transportistas")]
    [XmlType(TypeName = "DDTE_Transportistas")]
    public class EDTE_Transportistas : Entidad
    {
        uint id;
        uint id_dte;
        uint rut;
        string dv;
        string nombre;
        string patente;
        DateTime fecha_despacho;

        public uint Id { get => id; set => id = value; }
        public uint Id_dte { get => id_dte; set => id_dte = value; }
        public uint Rut { get => rut; set => rut = value; }
        public string Dv { get => dv; set => dv = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Patente { get => patente; set => patente = value; }
        public DateTime Fecha_despacho { get => fecha_despacho; set => fecha_despacho = value; }
        public string Fecha_despacho_texto { get => Formateador.DateToTextDB(fecha_despacho); set { } }

        public bool ValidaRut()
        {
            return Entidad.ValidaRut(this.RutCompleto());
        }

        public string RutCompleto()
        {
            return this.rut.ToString("N0") + "-" + this.dv;
        }

        internal string ConjuntoImpresionXSL()
        {
            return RutCompleto() + " " + this.nombre + " " + this.patente;
        }
    }
}
