using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EEmp_Contab_Ctas_Conts_Nom_Ctas : EEmp_Contab_Ctas_Conts
    {
        string cta_contable_ctas_conts_existencia;
        string cta_contable_ctas_conts_iva_debito;
        string cta_contable_ctas_conts_impuestos_adicionales;
        string cta_contable_ctas_conts_boletas_ventas;
        string cta_contable_ctas_conts_facturas_ventas;
        string cta_contable_ctas_conts_costo_ventas;
        string cta_contable_ctas_conts_caja;
        string cta_contable_ctas_conts_ajuste_caja;
        string cta_contable_ctas_conts_ingresos_por_venta;
        string cta_contable_ctas_conts_transback_debito;
        string cta_contable_ctas_conts_transback_credito;
        string cta_contable_ctas_conts_doc_por_cobrar;

        public string Cta_contable_ctas_conts_existencia { get => cta_contable_ctas_conts_existencia; set => cta_contable_ctas_conts_existencia = value; }
        public string Cta_contable_ctas_conts_iva_debito { get => cta_contable_ctas_conts_iva_debito; set => cta_contable_ctas_conts_iva_debito = value; }
        public string Cta_contable_ctas_conts_impuestos_adicionales { get => cta_contable_ctas_conts_impuestos_adicionales; set => cta_contable_ctas_conts_impuestos_adicionales = value; }
        public string Cta_contable_ctas_conts_boletas_ventas { get => cta_contable_ctas_conts_boletas_ventas; set => cta_contable_ctas_conts_boletas_ventas = value; }
        public string Cta_contable_ctas_conts_facturas_ventas { get => cta_contable_ctas_conts_facturas_ventas; set => cta_contable_ctas_conts_facturas_ventas = value; }
        public string Cta_contable_ctas_conts_costo_ventas { get => cta_contable_ctas_conts_costo_ventas; set => cta_contable_ctas_conts_costo_ventas = value; }
        public string Cta_contable_ctas_conts_caja { get => cta_contable_ctas_conts_caja; set => cta_contable_ctas_conts_caja = value; }
        public string Cta_contable_ctas_conts_ajuste_caja { get => cta_contable_ctas_conts_ajuste_caja; set => cta_contable_ctas_conts_ajuste_caja = value; }
        public string Cta_contable_ctas_conts_ingresos_por_venta { get => cta_contable_ctas_conts_ingresos_por_venta; set => cta_contable_ctas_conts_ingresos_por_venta = value; }
        public string Cta_contable_ctas_conts_transback_debito { get => cta_contable_ctas_conts_transback_debito; set => cta_contable_ctas_conts_transback_debito = value; }
        public string Cta_contable_ctas_conts_transback_credito { get => cta_contable_ctas_conts_transback_credito; set => cta_contable_ctas_conts_transback_credito = value; }
        public string Cta_contable_ctas_conts_doc_por_cobrar { get => cta_contable_ctas_conts_doc_por_cobrar; set => cta_contable_ctas_conts_doc_por_cobrar = value; }
    }
}
