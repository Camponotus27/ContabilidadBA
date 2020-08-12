using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class EMae_Productos_DTE_Compra : EMae_Productos
    {
        string cod_prod_proveedor;
        string nom_unidad_compra;
        string desc_comp;
        uint cant_comp;
        uint cant_vta;

        public string Cod_prod_proveedor { get => cod_prod_proveedor; set => cod_prod_proveedor = value; }
        public string Nom_unidad_compra { get => nom_unidad_compra; set => nom_unidad_compra = value; }
        public string Desc_comp { get => desc_comp; set => desc_comp = value; }
        public uint Cant_comp { get => cant_comp; set => cant_comp = value; }
        public uint Cant_vta { get => cant_vta; set => cant_vta = value; }
    }
}
