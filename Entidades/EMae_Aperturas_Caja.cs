using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable()]
    [XmlRoot(ElementName = "DMae_Aperturas_Caja")]
    public class EMae_Aperturas_Caja : Entidad
    {
        uint id;
        DateTime fecha_apertura;
        uint id_emp;
        uint id_caja;
        uint cod_apertura;
        decimal monto_apertura;
        DateTime? fecha_cierre;
        uint cant_efectivo;
        uint cant_debito;
        uint cant_credito;
        uint cant_transferencia;
        uint cant_cheque;
        uint cant_convenio;
        decimal monto_gastos;
        decimal monto_efectivo;
        decimal monto_debito;
        decimal monto_credito;
        decimal monto_transferencia;
        decimal monto_cheque;
        decimal monto_convenio;
        decimal venta;
        decimal diferencia;
        List<EAper_Caja_Movimientos> movimientos;
        List<EDTE> dte_convenios;

        uint cod_caja;

        public uint Id { get => id; set => id = value; }
        public DateTime Fecha_apertura { get => fecha_apertura; set => fecha_apertura = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Id_caja { get => id_caja; set => id_caja = value; }
        public uint Cod_apertura { get => cod_apertura; set => cod_apertura = value; }
        public decimal Monto_apertura { get => monto_apertura; set => monto_apertura = value; }
        public DateTime? Fecha_cierre { get => fecha_cierre; set => fecha_cierre = value; }
        public uint Cant_efectivo { get => cant_efectivo; set => cant_efectivo = value; }
        public uint Cant_debito { get => cant_debito; set => cant_debito = value; }
        public uint Cant_credito { get => cant_credito; set => cant_credito = value; }
        public uint Cant_transferencia { get => cant_transferencia; set => cant_transferencia = value; }
        public uint Cant_cheque { get => cant_cheque; set => cant_cheque = value; }
        public uint Cant_convenio { get => cant_convenio; set => cant_convenio = value; }
        public decimal Monto_gastos { get => monto_gastos; set => monto_gastos = value; }
        public decimal Monto_efectivo { get => monto_efectivo; set => monto_efectivo = value; }
        public decimal Monto_debito { get => monto_debito; set => monto_debito = value; }
        public decimal Monto_credito { get => monto_credito; set => monto_credito = value; }
        public decimal Monto_transferencia { get => monto_transferencia; set => monto_transferencia = value; }
        public decimal Monto_cheque { get => monto_cheque; set => monto_cheque = value; }
        public decimal Monto_convenio { get => monto_convenio; set => monto_convenio = value; }
        public decimal Venta { get => venta; set => venta = value; }
        public decimal Diferencia { get => diferencia; set => diferencia = value; }
        public List<EAper_Caja_Movimientos> Movimientos { get => movimientos; set => movimientos = value; }

        public decimal Monto_deposito
        {
            get
            {
                return this.monto_efectivo - this.monto_gastos;
            }

            set
            {
            }
        }

        public decimal Total_pagos
        {
            get
            {
                return this.Monto_efectivo + this.Monto_credito + this.Monto_debito + this.Monto_cheque + this.Monto_transferencia;
            }
            set
            {

            }
        }

        public List<EDTE> Dte_convenios { get => dte_convenios; set => dte_convenios = value; }
        public uint Cod_caja { get => cod_caja; set => cod_caja = value; }
    }
}
