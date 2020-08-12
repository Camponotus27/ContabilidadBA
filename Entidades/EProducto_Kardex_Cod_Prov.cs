using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Esta clase se usa en informes y para cargar el resultado del procedimiento SpBuscarProductosCodProvEntradasSalidas
    /// </summary>
    public class EProducto_CodProv_Entradas_Salidas : Entidad
    {
        // producto
        uint id;
        string cod_producto;
        string nom_producto;
        decimal precio_ultima_compra;
        decimal stock_gral;
        BoolDB disp_comp;

        uint id_unidad_compra;
        string nom_unidad_compra;

        // kardex
        decimal sum_entrada;
        decimal sum_salida;

        // cod_prov
        string cod_prod_proveedor;
        string desc_comp;
        uint cant_comp = 1;
        uint cant_vta = 1;

        public uint Id { get => id; set => id = value; }
        public string Cod_producto { get => cod_producto; set => cod_producto = value; }
        public string Nom_producto { get => nom_producto; set => nom_producto = value; }
        public decimal Precio_ultima_compra { get => precio_ultima_compra; set => precio_ultima_compra = value; }
        public decimal Stock_gral { get => stock_gral; set => stock_gral = value; }
        public BoolDB Disp_comp { get => disp_comp; set => disp_comp = value; }
        public uint Id_unidad_compra { get => id_unidad_compra; set => id_unidad_compra = value; }
        public string Nom_unidad_compra { get => nom_unidad_compra; set => nom_unidad_compra = value; }
        public decimal Sum_entrada { get => sum_entrada; set => sum_entrada = value; }
        public decimal Sum_salida { get => sum_salida; set => sum_salida = value; }
        public string Cod_prod_proveedor { get => cod_prod_proveedor; set => cod_prod_proveedor = value; }
        public string Desc_comp { get => desc_comp; set => desc_comp = value; }
        public uint Cant_comp { get => cant_comp; set => cant_comp = value; }
        public uint Cant_vta { get => cant_vta; set => cant_vta = value; }
    }
}
