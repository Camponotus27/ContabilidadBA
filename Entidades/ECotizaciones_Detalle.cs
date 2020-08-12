using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable()]
    public class ECotizaciones_Detalle : EDetalle_Comun_Emision
    {
        uint id_cot;

        public uint Id_cot { get => id_cot; set => id_cot = value; }

        public ECotizaciones_Detalle() { }

        public ECotizaciones_Detalle(EMae_Productos_DTE producto_dte, EEmp_Parametros parametros, EMae_Lista_Precios lista_precios) : base(producto_dte, parametros, lista_precios)
        {

        }
    }
}
