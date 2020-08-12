using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EEmp_Parametros : Entidad
    { 
	    uint id_emp;
        AjusteMargenPrecio ajuste_margen_precio = AjusteMargenPrecio.MantPrecioAjusMargen; // ENUM('MntMargenAjusPrecio','MantPrecioAjusMargen') NOT NULL DEFAULT 'MantPrecioAjusMargen',
	    BoolDB stock_negativo = BoolDB.N; // ENUM('S','N') NOT NULL DEFAULT 'N',
	    BoolDB modificar_fecha_dte = BoolDB.N; // ENUM('S','N') NOT NULL DEFAULT 'N',
        PrecioBaseParaCalculoPrecioVenta precio_base_para_calculo_precio_venta = PrecioBaseParaCalculoPrecioVenta.Mayor; // ENUM('PrecioUltimaCompra','CostoPromedio','Mayor') NOT NULL DEFAULT 'Mayor',
        NivelMargenCalculoPrecioVenta nivel_margen_calculo_precio_venta = NivelMargenCalculoPrecioVenta.N1; // ENUM('N1','N2') NOT NULL DEFAULT 'N1',
        decimal margen_minimo_comercializacion;
	    string prefijo_ean_13;
        decimal iva;
        decimal ila;
        decimal otros_impuestos;
        
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public AjusteMargenPrecio Ajuste_margen_precio { get => ajuste_margen_precio; set => ajuste_margen_precio = value; }
        public BoolDB Stock_negativo { get => stock_negativo; set => stock_negativo = value; }
        public BoolDB Modificar_fecha_dte { get => modificar_fecha_dte; set => modificar_fecha_dte = value; }
        public PrecioBaseParaCalculoPrecioVenta Precio_base_para_calculo_precio_venta { get => precio_base_para_calculo_precio_venta; set => precio_base_para_calculo_precio_venta = value; }
        public NivelMargenCalculoPrecioVenta Nivel_margen_calculo_precio_venta { get => nivel_margen_calculo_precio_venta; set => nivel_margen_calculo_precio_venta = value; }
        public decimal Margen_minimo_comercializacion { get => margen_minimo_comercializacion; set => margen_minimo_comercializacion = value; }
        public string Prefijo_ean_13 { get => prefijo_ean_13; set => prefijo_ean_13 = value; }
        public decimal Iva {
            get => iva;
            set => iva = value; }
        public decimal Ila { get => ila; set => ila = value; }
        public decimal Otros_impuestos { get => otros_impuestos; set => otros_impuestos = value; }
    }
}
