using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EEmp_Contab_Ctas_Conts : Entidad
    {
        uint id_emp;
        uint id_contab_ctas_conts_existencia;
        uint id_contab_ctas_conts_iva_debito;
        uint id_contab_ctas_conts_impuestos_adicionales;
        uint id_contab_ctas_conts_boletas_ventas;
        uint id_contab_ctas_conts_facturas_ventas;
        uint id_contab_ctas_conts_costo_ventas;
        uint id_contab_ctas_conts_caja;
        uint id_contab_ctas_conts_ajuste_caja;
        uint id_contab_ctas_conts_ingresos_por_venta;
        uint id_contab_ctas_conts_transback_debito;
        uint id_contab_ctas_conts_transback_credito;
        uint id_contab_ctas_conts_doc_por_cobrar;

        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Id_contab_ctas_conts_existencia { get => id_contab_ctas_conts_existencia; set => id_contab_ctas_conts_existencia = value; }
        public uint Id_contab_ctas_conts_iva_debito { get => id_contab_ctas_conts_iva_debito; set => id_contab_ctas_conts_iva_debito = value; }
        public uint Id_contab_ctas_conts_impuestos_adicionales { get => id_contab_ctas_conts_impuestos_adicionales; set => id_contab_ctas_conts_impuestos_adicionales = value; }
        public uint Id_contab_ctas_conts_boletas_ventas { get => id_contab_ctas_conts_boletas_ventas; set => id_contab_ctas_conts_boletas_ventas = value; }
        public uint Id_contab_ctas_conts_facturas_ventas { get => id_contab_ctas_conts_facturas_ventas; set => id_contab_ctas_conts_facturas_ventas = value; }
        public uint Id_contab_ctas_conts_costo_ventas { get => id_contab_ctas_conts_costo_ventas; set => id_contab_ctas_conts_costo_ventas = value; }
        public uint Id_contab_ctas_conts_caja { get => id_contab_ctas_conts_caja; set => id_contab_ctas_conts_caja = value; }
        public uint Id_contab_ctas_conts_ajuste_caja { get => id_contab_ctas_conts_ajuste_caja; set => id_contab_ctas_conts_ajuste_caja = value; }
        public uint Id_contab_ctas_conts_ingresos_por_venta { get => id_contab_ctas_conts_ingresos_por_venta; set => id_contab_ctas_conts_ingresos_por_venta = value; }
        public uint Id_contab_ctas_conts_transback_debito { get => id_contab_ctas_conts_transback_debito; set => id_contab_ctas_conts_transback_debito = value; }
        public uint Id_contab_ctas_conts_transback_credito { get => id_contab_ctas_conts_transback_credito; set => id_contab_ctas_conts_transback_credito = value; }
        public uint Id_contab_ctas_conts_doc_por_cobrar { get => id_contab_ctas_conts_doc_por_cobrar; set => id_contab_ctas_conts_doc_por_cobrar = value; }
    }
}
