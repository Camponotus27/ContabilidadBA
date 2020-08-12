using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Esta calse es una extendida de codigo proveedor, se usa para tener en pantalla
    /// el codugo de proveedor mas datos relevantes de la entidad como el rut y la razon social
    /// </summary>
    [Serializable()]
    public class ERel_Productos_Cod_Prov_Entidad : ERel_Productos_Cod_Prov
    {
        uint rut;
        uint resp_rut;
        string razon_social;

        public uint Rut { get => rut;
            set
            {
                rut = value;
                //if (resp_rut == 0)
                  //  resp_rut = value;
            }
        }
        public uint Resp_rut { get => resp_rut; set => resp_rut = value; }
        public string Razon_social { get => razon_social; set => razon_social = value; }

        public void RecuperarRespaldoRut()
        {
            this.rut = this.resp_rut;
        }

        public void RespaldarRut()
        {
            this.resp_rut = this.rut;
        }
    }
}
