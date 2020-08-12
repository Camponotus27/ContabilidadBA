using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class EDTE_Compra_Local
    {
        uint id;
        uint id_dte;
        uint id_local;
        uint id_bodega;
        uint id_bodega_destino;
        uint id_guia_devolucion;
        uint folio_guia_devolucion;
        decimal dte_subtotal_neto;
        decimal dte_desc_porcentaje;
        decimal dte_desc_monto_neto;
        decimal dte_neto;
        decimal dte_iva_porcentaje;
        decimal dte_iva_monto;
        decimal dte_total;
        DateTime fecha_vencimiento;
        DateTime fecha_recepcion;
        BoolDB objetada = BoolDB.N;
        string glosa;

        public uint Id { get => id; set => id = value; }
        public uint Id_dte { get => id_dte; set => id_dte = value; }
        public uint Id_local { get => id_local; set => id_local = value; }
        public uint Id_bodega { get => id_bodega; set => id_bodega = value; }
        public uint Id_bodega_destino { get => id_bodega_destino; set => id_bodega_destino = value; }
        public uint Id_guia_devolucion { get => id_guia_devolucion; set => id_guia_devolucion = value; }
        public decimal Dte_subtotal_neto { get => dte_subtotal_neto; set => dte_subtotal_neto = value; }
        public decimal Dte_desc_porcentaje { get => dte_desc_porcentaje; set => dte_desc_porcentaje = value; }
        public decimal Dte_desc_monto_neto { get => dte_desc_monto_neto; set => dte_desc_monto_neto = value; }
        public decimal Dte_neto { get => dte_neto; set => dte_neto = value; }
        public decimal Dte_iva_porcentaje { get => dte_iva_porcentaje; set => dte_iva_porcentaje = value; }
        public decimal Dte_iva_monto { get => dte_iva_monto; set => dte_iva_monto = value; }
        public decimal Dte_total { get => dte_total; set => dte_total = value; }
        public DateTime Fecha_vencimiento {
            get
            {
                if (fecha_vencimiento < DateTime.Parse("2000-01-01") )
                    return DateTime.Now.Date;

                return fecha_vencimiento;
            }set => fecha_vencimiento = value; }
        public string Fecha_vencimiento_texto { get => Formateador.DateToTextDB(fecha_vencimiento); set { } }
        public DateTime Fecha_recepcion {
            get
            {
                if (fecha_recepcion < DateTime.Parse("2000-01-01"))
                    return DateTime.Now.Date;

                return fecha_recepcion;
            }
            set => fecha_recepcion = value; }
        public string Fecha_recepcion_texto { get => Formateador.DateToTextDB(fecha_recepcion); set { } }
        public BoolDB Objetada { get => objetada; set => objetada = value; }
        public string Glosa { get => glosa; set => glosa = value; }
        public uint Folio_guia_devolucion { get => folio_guia_devolucion; set => folio_guia_devolucion = value; }

        public void CalcularDescuentoFaltate()
        {
            throw new NotImplementedException();
        }
    }
}
