using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DTE_Compra_Local : Entidad
    {
        uint id;
        uint id_dte;
        uint id_local;
        uint id_bodega;
        decimal dte_subtotal_neto;
        decimal dte_desc_porcentaje;
        decimal dte_desc_monto_neto;
        decimal dte_neto;
        decimal dte_iva_porcentaje;
        decimal dte_iva_monto;
        decimal dte_total;
        DateTime? fecha_aceptacion_contenido;
        DateTime? fecha_acuse_recibo;
        BoolDB objetada = BoolDB.N;
        string glosa;

        public uint Id { get => id; set => id = value; }
        public uint Id_dte { get => id_dte; set => id_dte = value; }
        public uint Id_local { get => id_local; set => id_local = value; }
        public uint Id_bodega { get => id_bodega; set => id_bodega = value; }
        public decimal Dte_subtotal_neto { get => dte_subtotal_neto; set => dte_subtotal_neto = value; }
        public decimal Dte_desc_porcentaje { get => dte_desc_porcentaje; set => dte_desc_porcentaje = value; }
        public decimal Dte_desc_monto_neto { get => dte_desc_monto_neto; set => dte_desc_monto_neto = value; }
        public decimal Dte_neto { get => dte_neto; set => dte_neto = value; }
        public decimal Dte_iva_porcentaje { get => dte_iva_porcentaje; set => dte_iva_porcentaje = value; }
        public decimal Dte_iva_monto { get => dte_iva_monto; set => dte_iva_monto = value; }
        public decimal Dte_total { get => dte_total; set => dte_total = value; }
        public DateTime? Fecha_aceptacion_contenido { get => fecha_aceptacion_contenido; set => fecha_aceptacion_contenido = value; }
        public DateTime? Fecha_acuse_recibo { get => fecha_acuse_recibo; set => fecha_acuse_recibo = value; }
        public BoolDB Objetada { get => objetada; set => objetada = value; }
        public string Glosa { get => glosa; set => glosa = value; }
    }
}
