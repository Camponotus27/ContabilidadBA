using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class ENota_Ventas : Entidad
    {
        uint id;
        uint id_emp;
        uint id_local;
        uint cod_n_vta;
        DateTime fecha_documento;
        decimal n_vta_subtotal_bruto;
        decimal n_vta_subtotal_neto;
        decimal n_vta_desc_porcentaje;
        decimal n_vta_desc_monto_bruto;
        decimal n_vta_desc_monto_neto;
        decimal n_vta_neto;
        decimal n_vta_iva_porcentaje;
        decimal n_vta_iva_monto;
        decimal n_vta_total;
        uint cli_rut;
        string cli_dv;
        string cli_razon_social;
        string cli_giro;
        string cli_direccion;
        string cli_comuna;
        string cli_ciudad;
        uint id_bodega;
        uint id_listas_precio;
        uint id_vendedor;
        uint id_caja_apertura;
        uint id_caja;
        uint correlativo_caja;

        EMae_Vendedores vendedor;
        EMae_Entidades cliente;
        List<ENota_Ventas_Detalle> detalle;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Id_local { get => id_local; set => id_local = value; }
        public uint Cod_n_vta { get => cod_n_vta; set => cod_n_vta = value; }
        public DateTime Fecha_documento
        {
            get
            {
                if (fecha_documento < DateTime.Parse("2000-01-01") && this.cod_n_vta == 0)
                    return DateTime.Now.Date;

                return fecha_documento;
            }
            set => fecha_documento = value;
        }
        /// <summary>
        /// Fecha en formato "yyyy-MM-dd"
        /// </summary>
        public string Fecha_documento_texto { get => Formateador.DateToTextDB(this.fecha_documento); set { } }
        public decimal N_vta_subtotal_bruto { get => n_vta_subtotal_bruto; set => n_vta_subtotal_bruto = value; }
        public decimal N_vta_subtotal_neto { get => n_vta_subtotal_neto; set => n_vta_subtotal_neto = value; }
        public decimal N_vta_desc_porcentaje { get => n_vta_desc_porcentaje; set => n_vta_desc_porcentaje = value; }
        public decimal N_vta_desc_monto_bruto { get => n_vta_desc_monto_bruto; set => n_vta_desc_monto_bruto = value; }
        public decimal N_vta_desc_monto_neto { get => n_vta_desc_monto_neto; set => n_vta_desc_monto_neto = value; }
        public decimal N_vta_neto { get => n_vta_neto; set => n_vta_neto = value; }
        public decimal N_vta_iva_porcentaje { get => n_vta_iva_porcentaje; set => n_vta_iva_porcentaje = value; }
        public decimal N_vta_iva_monto { get => n_vta_iva_monto; set => n_vta_iva_monto = value; }
        public decimal N_vta_total { get => n_vta_total; set => n_vta_total = value; }
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
        public EMae_Vendedores Vendedor { get => vendedor; set => vendedor = value; }
        public EMae_Entidades Cliente { get => cliente; set => cliente = value; }
        public List<ENota_Ventas_Detalle> Detalle { get => detalle; set => detalle = value; }
    }
}
