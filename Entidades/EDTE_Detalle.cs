using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class SuperoStockDisponible : EventArgs
    {
        EDTE_Detalle detalle;

        public EDTE_Detalle Detalle { get => detalle; set => detalle = value; }
    }

    public class EDTE_Detalle : EDetalle_Comun_Emision
    {
        uint id_dte;

        public uint Id_dte { get => id_dte; set => id_dte = value; }

        public EDTE_Detalle() { }

        public EDTE_Detalle(EMae_Productos_DTE producto_dte, EEmp_Parametros parametros, EMae_Lista_Precios lista_precios, EDetalleComportamiento comportamiento = EDetalleComportamiento.Normal) : base(producto_dte, parametros, lista_precios, comportamiento)
        {

        }
    }
}
