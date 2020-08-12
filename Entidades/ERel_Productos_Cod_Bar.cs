using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class ERel_Productos_Cod_Bar : Entidad
    {
        uint id;
        uint id_emp;
        uint id_producto;
        string cod_bar;

        public uint Id { get => id; set => id = value; }
        public uint Id_emp { get => id_emp; set => id_emp = value; }
        public uint Id_producto { get => id_producto; set => id_producto = value; }
        public string Cod_bar { get => cod_bar; set => cod_bar = value; }

        public bool Validate()
        {
            if(this.Cod_bar == "")
                return false;

            return true;
        }
    }
}
