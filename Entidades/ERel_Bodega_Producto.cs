using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class ERel_Bodega_Producto : Entidad
    {
        uint id;
        uint id_bodega;
        uint id_producto;
        string nombre_bodega;
        string nombre_local;
        decimal stock_valorizado;
        decimal stock;

        public uint Id { get => id; set => id = value; }
        public uint Id_bodega { get => id_bodega; set => id_bodega = value; }
        public uint Id_producto { get => id_producto; set => id_producto = value; }
        public string Nombre_bodega { get => nombre_bodega; set => nombre_bodega = value; }
        public string Nombre_local { get => nombre_local; set => nombre_local = value; }
        public decimal Stock { get => stock; set => stock = value; }
        public decimal Stock_valorizado { get => stock_valorizado; set => stock_valorizado = value; }
    }
}
