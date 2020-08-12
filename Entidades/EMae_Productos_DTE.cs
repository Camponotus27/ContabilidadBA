using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EMae_Productos_DTE : EMae_Productos
    {
        decimal stock_bodega;
        decimal precio;
        //decimal precio_base;
        decimal margen_base;
        string nom_unidad_venta;
        string nom_unidad_compra;
        //decimal ultima_compra;
        //DateTime? fecha_ultima_compra;

        public decimal Stock_bodega { get => stock_bodega; set => stock_bodega = value; }
        //public decimal Precio_base { get => precio_base; set => precio_base = value; }
        public decimal Margen_base { get => margen_base; set => margen_base = value; }
        public decimal Margen_base_dividido_100 { get { return this.margen_base / 100; } }
        public string Nom_unidad_venta { get => nom_unidad_venta; set => nom_unidad_venta = value; }
        public string Nom_unidad_compra { get => nom_unidad_compra; set => nom_unidad_compra = value; }
        public decimal Precio { get => precio; set => precio = value; }
        //public decimal Ultima_compra { get => ultima_compra; set => ultima_compra = value; }
        //public DateTime? Fecha_ultima_compra { get => fecha_ultima_compra; set => fecha_ultima_compra = value; }
    }
}
