using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlType(TypeName = "DAper_Caja_Movimientos")]
    public class EAper_Caja_Movimientos : Entidad
    {
        uint id;
        uint id_apertura_caja;
        uint id_concepto;
        DateTime fecha;
        uint folio_documento;
        uint rut;
        string dv;
        string descripcion;
        decimal monto;
        string comentario;
        IngEgre tipo;

        public uint Id { get => id; set => id = value; }
        public uint Id_apertura_caja { get => id_apertura_caja; set => id_apertura_caja = value; }
        public uint Id_concepto { get => id_concepto; set => id_concepto = value; }
        public DateTime Fecha { get
            {
                if (fecha == null)
                    return DateTime.Now;

                return fecha;
            }
            set => fecha = value; }
        public string Fecha_texto
        {
            get{return Formateador.DateToTextDB(Fecha);} set { }
        }
        public uint Folio_documento { get => folio_documento; set => folio_documento = value; }
        public uint Rut { get => rut; set => rut = value; }
        public string Dv { get => dv; set => dv = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Monto { get => monto; set => monto = value; }
        public string Comentario { get => comentario; set => comentario = value; }
        public IngEgre Tipo { get => tipo; set => tipo = value; }
        public string Tipo_texto { get => Enums.ToString(tipo); set { } }

        public bool ValidaRut()
        {
            return Entidad.ValidaRut(this.rut + "-" + this.dv);
        }

        public void ActualizarTipoDesdeConceptos(List<EMae_Conceptos> conceptos)
        {
            if (conceptos != null)
            {
                foreach (EMae_Conceptos concepto in conceptos)
                {
                    if(concepto.Id == this.id_concepto)
                    {
                        this.tipo = concepto.Tipo_concepto;
                        return;
                    }
                }
            }

            this.tipo = IngEgre.N;
        }
    }
}
