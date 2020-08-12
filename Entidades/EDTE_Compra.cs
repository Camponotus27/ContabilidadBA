using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlRoot(ElementName = "DDTE_Compra")]
    public class EDTE_Compra : Entidad
    {
        uint id;
        uint id_emp;
        uint tipo;
        uint folio;
        uint tipo_traslado_bienes;

        uint id_orden_compra;
        uint cod_orden_compra;

        DateTime fecha_documento;
        uint prov_rut;
        string prov_dv;


        string prov_razon_social;
        string prov_giro;
        string prov_direccion;
        string prov_comuna;
        string prov_ciudad;

        EDTE_Compra_Local local;
        List<EDTE_Referencia_DTE_Compra> referencia;
        List<EDTE_Compra_Detalle> detalle;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Tipo { get => tipo; set => tipo = value; }
        public uint Folio { get => folio; set => folio = value; }
        public uint Tipo_traslado_bienes { get => tipo_traslado_bienes; set => tipo_traslado_bienes = value; }

        public uint Id_orden_compra { get => id_orden_compra; set => id_orden_compra = value; }
        public uint Cod_orden_compra { get => cod_orden_compra; set => cod_orden_compra = value; }

        public DateTime Fecha_documento
        {
            get
            {
                if (fecha_documento < DateTime.Parse("2000-01-01") && this.tipo == 0)
                    return DateTime.Now.Date;

                return fecha_documento;
            }
            set => fecha_documento = value;
        }
        public string Fecha_documento_texto
        {
            get
            {
                return Formateador.DateToTextDB(this.Fecha_documento);
            }
            set { }
        }
        public uint Prov_rut { get => prov_rut; set => prov_rut = value; }
        public string Prov_dv { get => prov_dv; set => prov_dv = value; }
        public string Prov_razon_social { get => prov_razon_social; set => prov_razon_social = value; }
        public string Prov_giro { get => prov_giro; set => prov_giro = value; }
        public string Prov_direccion { get => prov_direccion; set => prov_direccion = value; }
        public string Prov_comuna { get => prov_comuna; set => prov_comuna = value; }
        public string Prov_ciudad { get => prov_ciudad; set => prov_ciudad = value; }
        public EDTE_Compra_Local Local { get => local; set => local = value; }
        public List<EDTE_Referencia_DTE_Compra> Referencia { get => referencia; set => referencia = value; }
        public List<EDTE_Compra_Detalle> Detalle { get => detalle; set => detalle = value; }


        public string Prov_RutCompleto()
        {
            if (this.Prov_rut == 0 || string.IsNullOrEmpty(this.Prov_dv))
            {
                return "XXXXXXXX-X";
            }

            return this.Prov_rut + "-" + this.Prov_dv;
        }
    }
}
