using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class ECotizaciones : Entidad
    {
        uint id;
        uint id_emp;
        uint id_local;
        uint cod_cot;
        DateTime fecha_documento;
        uint cli_rut;
        string cli_dv;
        string cli_razon_social;
        string cli_giro;
        string cli_direccion;
        string cli_comuna;
        string cli_ciudad;
        decimal cot_subtotal_bruto;
        decimal cot_subtotal_neto;
        decimal cot_desc_porcentaje;
        decimal cot_desc_monto_bruto;
        decimal cot_desc_monto_neto;
        decimal cot_neto;
        decimal cot_iva_porcentaje;
        decimal cot_iva_monto;
        decimal cot_total;
        uint id_bodega;
        uint id_listas_precio;
        uint id_vendedor;
        uint id_caja_apertura;
        uint id_caja;
        uint correlativo_caja;

        EMae_Vendedores vendedor;
        EMae_Entidades cliente;
        List<ECotizaciones_Detalle> detalle;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Id_local { get => id_local; set => id_local = value; }
        public uint Cod_cot { get => cod_cot; set => cod_cot = value; }
        public DateTime Fecha_documento
        {
            get
            {
                if (fecha_documento < DateTime.Parse("2000-01-01") && this.cod_cot == 0)
                    return DateTime.Now.Date;

                return fecha_documento;
            }
            set => fecha_documento = value;
        }
        /// <summary>
        /// Fecha en formato "yyyy-MM-dd"
        /// </summary>
        public string Fecha_documento_texto { get => Formateador.DateToTextDB(this.fecha_documento); set { } }
        public uint Cli_rut { get => cli_rut; set => cli_rut = value; }
        public string Cli_dv { get => cli_dv; set => cli_dv = value; }
        public string Cli_razon_social { get => cli_razon_social; set => cli_razon_social = value; }
        public string Cli_giro { get => cli_giro; set => cli_giro = value; }
        public string Cli_direccion { get => cli_direccion; set => cli_direccion = value; }
        public string Cli_comuna { get => cli_comuna; set => cli_comuna = value; }
        public string Cli_ciudad { get => cli_ciudad; set => cli_ciudad = value; }
        public uint Id_bodega { get => id_bodega; set => id_bodega = value; }
        public uint Id_listas_precio { get => id_listas_precio; set => id_listas_precio = value; }
        public uint Id_vendedor { get => id_vendedor; set => id_vendedor = value; }
        public uint Id_caja_apertura { get => id_caja_apertura; set => id_caja_apertura = value; }
        public uint Id_caja { get => id_caja; set => id_caja = value; }
        public uint Correlativo_caja { get => correlativo_caja; set => correlativo_caja = value; }
        public decimal Cot_subtotal_bruto { get => cot_subtotal_bruto; set => cot_subtotal_bruto = value; }
        public decimal Cot_subtotal_neto { get => cot_subtotal_neto; set => cot_subtotal_neto = value; }
        public decimal Cot_desc_porcentaje { get => cot_desc_porcentaje; set => cot_desc_porcentaje = value; }
        public decimal Cot_desc_monto_bruto { get => cot_desc_monto_bruto; set => cot_desc_monto_bruto = value; }
        public decimal Cot_desc_monto_neto { get => cot_desc_monto_neto; set => cot_desc_monto_neto = value; }
        public decimal Cot_neto { get => cot_neto; set => cot_neto = value; }
        public decimal Cot_iva_porcentaje { get => cot_iva_porcentaje; set => cot_iva_porcentaje = value; }
        public decimal Cot_iva_monto { get => cot_iva_monto; set => cot_iva_monto = value; }
        public decimal Cot_total { get => cot_total; set => cot_total = value; }
        public EMae_Vendedores Vendedor { get => vendedor; set => vendedor = value; }
        public EMae_Entidades Cliente { get => cliente; set => cliente = value; }
        public List<ECotizaciones_Detalle> Detalle { get => detalle; set => detalle = value; }

    }
}
