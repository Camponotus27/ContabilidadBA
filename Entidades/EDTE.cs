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
    [XmlRoot(ElementName = "DDTE")]
    public class EDTE : Entidad
    {
        uint id;
        uint id_emp;
        uint tipo;
        uint folio;
        uint tipo_traslado_bienes;
        DateTime fecha_documento;
        DateTime fecha_vencimiento;
        uint cli_rut;
        string cli_dv;
        string cli_razon_social;
        string cli_giro;
        string cli_direccion;
        string cli_comuna;
        string cli_ciudad;
        uint id_folio;
        uint id_local;
        uint id_local_destino;
        uint id_bodega;
        uint id_listas_precio;
        uint id_vendedor;
        uint id_apertura_caja;
        uint id_nota_venta;
        uint cod_n_vta;

        decimal dte_subtotal_bruto;
        decimal dte_subtotal_neto;
        decimal dte_desc_porcentaje;
        decimal dte_desc_monto_bruto;
        decimal dte_desc_monto_neto;
        decimal dte_neto;
        decimal dte_iva_porcentaje;
        decimal dte_iva_monto;
        decimal dte_total;
        Origen dte_origen;
        BoolDB is_factura_guias = BoolDB.N;
        BoolDB is_convenio = BoolDB.N;
        BoolDB is_anulada = BoolDB.N;
        string glosa_anulacion;
        DateTime? fecha_anulacion;
        decimal monto_pagar;
        decimal monto_pagado;
        decimal monto_adeudado;
        EMae_Vendedores vendedor;
        EMae_Entidades cliente;
        List<EDTE_Detalle> detalle;
        List<EDTE_Referencia_DTE> referencia;
        List<ERel_Dte_Medios_De_Pagos> pagos;
        EDTE_Transportistas transportista;


        BoolDB is_ingresada;
        uint id_bodega_ingreso;
        DateTime? fecha_ingreso;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Tipo { get => tipo; set => tipo = value; }
        public uint Folio { get => folio; set => folio = value; }
        public DateTime Fecha_documento {
            get
            {
                if (fecha_documento < DateTime.Parse("2000-01-01") && this.tipo == 0)
                    return DateTime.Now.Date;

                return fecha_documento;
            }
            set => fecha_documento = value; }
        public DateTime Fecha_vencimiento {
            get
            {
                if (this.fecha_vencimiento < this.fecha_documento)
                    return fecha_documento;

                return fecha_vencimiento;
            }
            set => fecha_vencimiento = value; }
        /// <summary>
        /// Fecha en formato "yyyy-MM-dd"
        /// </summary>
        public string Fecha_documento_texto { get => fecha_documento.ToString("yyyy-MM-dd");set { } }
        /// <summary>
        /// Fecha en formato "yyyy-MM-dd"
        /// </summary>
        public string Fecha_vencimiento_texto { get => fecha_vencimiento.ToString("yyyy-MM-dd"); set { } }
        public uint Cli_rut { get => cli_rut; set => cli_rut = value; }
        public string Cli_dv { get => cli_dv; set => cli_dv = value; }
        public string Cli_razon_social { get => cli_razon_social; set => cli_razon_social = value; }
        public string Cli_giro { get => cli_giro; set => cli_giro = value; }
        public string Cli_direccion { get => cli_direccion; set => cli_direccion = value; }
        public string Cli_comuna { get => cli_comuna; set => cli_comuna = value; }
        public string Cli_ciudad { get => cli_ciudad; set => cli_ciudad = value; }
        public uint Id_folio { get => id_folio; set => id_folio = value; }
        public uint Id_local { get => id_local; set => id_local = value; }
        public uint Id_local_destino { get => id_local_destino; set => id_local_destino = value; }
        public uint Id_bodega { get => id_bodega; set => id_bodega = value; }
        public uint Id_listas_precio { get => id_listas_precio; set => id_listas_precio = value; }
        public uint Id_vendedor { get => id_vendedor; set => id_vendedor = value; }
        public uint Id_apertura_caja { get => id_apertura_caja; set => id_apertura_caja = value; }
        public uint Id_nota_venta { get => id_nota_venta; set => id_nota_venta = value; }
        public uint Cod_n_vta { get => cod_n_vta; set => cod_n_vta = value; }


        public decimal Dte_subtotal_bruto { get => Math.Round(dte_subtotal_bruto, 4); set => dte_subtotal_bruto = value; }
        public decimal Dte_subtotal_neto { get => dte_subtotal_neto; set => dte_subtotal_neto = value; }
        public decimal Dte_desc_porcentaje { get => Math.Round(dte_desc_porcentaje, 2); set => dte_desc_porcentaje = value; }
        public decimal Dte_desc_porcentaje_dividido_100 { get => dte_desc_porcentaje / 100; }
        public decimal Dte_desc_monto_bruto { get => Math.Round(dte_desc_monto_bruto, 4); set => dte_desc_monto_bruto = value; }
        public decimal Dte_desc_monto_neto { get => dte_desc_monto_neto; set => dte_desc_monto_neto = value; }
        public decimal Dte_neto { get => Math.Round(dte_neto, 4); set => dte_neto = value; }
        public decimal Dte_iva_porcentaje { get => Math.Round(dte_iva_porcentaje, 2); set => dte_iva_porcentaje = value; }
        public decimal Dte_iva_monto { get => Math.Round(dte_iva_monto, 4); set => dte_iva_monto = value; }
        public decimal Dte_total { get => Math.Round(dte_total, 4); set => dte_total = value; }
        public Origen Dte_origen { get => dte_origen; set => dte_origen = value; }
        public BoolDB Is_factura_guias { get => is_factura_guias; set => is_factura_guias = value; }
        public BoolDB Is_convenio { get => is_convenio; set => is_convenio = value; }
        public bool IsConvenioBool { get => Enums.BoolDBToBool(is_convenio); }
        public bool IsAnuladaBool { get => Enums.BoolDBToBool(is_anulada); }
        public BoolDB Is_anulada { get => is_anulada; set => is_anulada = value; }
        public string Glosa_anulacion { get => glosa_anulacion; set => glosa_anulacion = value; }
        public DateTime? Fecha_anulacion { get => fecha_anulacion; set => fecha_anulacion = value; }
        public decimal Monto_pagar { get => Math.Round(monto_pagar, 4); set => monto_pagar = value; }
        public decimal Monto_pagado { get => Math.Round(monto_pagado, 4); set => monto_pagado = value; }
        public decimal Monto_adeudado { get => Math.Round(monto_adeudado, 4); set => monto_adeudado = value; }
        public EMae_Vendedores Vendedor { get => vendedor; set => vendedor = value; }
        public EMae_Entidades Cliente { get => cliente; set => cliente = value; }
        public List<EDTE_Detalle> Detalle {
            get => detalle;
            set => detalle = value;
        }
        public List<EDTE_Referencia_DTE> Referencia { get => referencia; set => referencia = value; }
        public List<ERel_Dte_Medios_De_Pagos> Pagos { get => pagos; set => pagos = value; }
        public uint Tipo_traslado_bienes { get => tipo_traslado_bienes; set => tipo_traslado_bienes = value; }
        public string FechaAnulacionTextoMostrar {
            get
            {

                return Formateador.DateToTextMostrar(this.fecha_anulacion);
            }
        }
        public string FechaIngresoTextoMostrar
        {
            get
            {

                return Formateador.DateToTextMostrar(this.fecha_ingreso);
            }
        }

        public BoolDB Is_ingresada { get => is_ingresada; set => is_ingresada = value; }
        public uint Id_bodega_ingreso { get => id_bodega_ingreso; set => id_bodega_ingreso = value; }
        public DateTime? Fecha_ingreso { get => fecha_ingreso; set => fecha_ingreso = value; }
        public bool IsIngresadaBool { get => Enums.BoolDBToBool(this.is_ingresada); }
        public EDTE_Transportistas Transportista { get => transportista; set => transportista = value; }


        /// <summary>
        /// Valida el rut con el tipo de documento si es valido
        /// </summary>
        /// <returns>True si es valido False si no lo es</returns>
        public bool ValidaRut(uint rut_por_defecto)
        {
            if(this.tipo == 33)
            {
                return this.cli_rut != 0 || this.cli_rut != rut_por_defecto;
            }
            else
            {
                return this.cli_rut != 0;
            }
        }

        public bool EsDTEAceptaReferencia()
        {
            return this.tipo == 61 || this.tipo == 56;
        }
    }
}
