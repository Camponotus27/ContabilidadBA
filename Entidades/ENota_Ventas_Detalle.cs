using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class ENota_Ventas_Detalle : EDetalle_Comun_Emision
    {
        uint id_n_vta;

        public uint Id_n_vta { get => id_n_vta; set => id_n_vta = value; }

        public ENota_Ventas_Detalle() { }

        public ENota_Ventas_Detalle(EMae_Productos_DTE producto_dte, EEmp_Parametros parametros, EMae_Lista_Precios lista_precios) : base(producto_dte, parametros, lista_precios)
        {

        }
    }
}
