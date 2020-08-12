using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class ERel_Productos_Cod_Prov : Entidad
    {
        uint id;
        uint id_producto;
        uint id_entidad;
        string cod_prod_proveedor;
        string desc_comp;
        uint cant_comp = 1;
        uint cant_vta = 1;
        EMae_Entidades entidad_;

        public uint Id { get => id; set => id = value; }
        public uint Id_producto { get => id_producto; set => id_producto = value; }
        public uint Id_entidad { get => id_entidad; set => id_entidad = value; }
        public string Cod_prod_proveedor { get => cod_prod_proveedor; set => cod_prod_proveedor = value; }
        public string Desc_comp { get => desc_comp; set => desc_comp = value; }
        public uint Cant_comp { get => cant_comp; set => cant_comp = value; }
        public uint Cant_vta { get => cant_vta; set => cant_vta = value; }
        public EMae_Entidades Entidad_ { get => entidad_;
            set
            {
                this.entidad_ = value;
            }
        }
    }
}
