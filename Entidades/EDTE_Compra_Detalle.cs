using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable()]
    [XmlRoot(ElementName = "DDTE_Compra_Detalle")]
    [XmlType(TypeName = "DDTE_Compra_Detalle")]
    public class EDTE_Compra_Detalle : EDetalle_Comun_Ingreso
    {
        public EDTE_Compra_Detalle()
        {

        }
        
        public EDTE_Compra_Detalle(EMae_Productos_DTE_Compra producto_dte_compra, bool activar = true) : base(producto_dte_compra, activar)
        {

        }

        public EDTE_Compra_Detalle(EOrden_Compra_Detalle orden_compra_detalle, bool activar = true)
        {
            this.id_producto = orden_compra_detalle.Id_producto;

            this.nom_producto = orden_compra_detalle.Nom_producto;
            this.desc_compra = orden_compra_detalle.Desc_compra;

            this.codigo_producto = orden_compra_detalle.Codigo_producto;
            this.cod_prod_proveedor = orden_compra_detalle.Cod_prod_proveedor;

            this.precio_neto_unit = orden_compra_detalle.Precio_neto_unit;
            this.cantidad = orden_compra_detalle.Cantidad;
            this.precio_neto_linea = orden_compra_detalle.Precio_neto_linea;

            this.desc_porcentaje = orden_compra_detalle.Desc_porcentaje;
            this.monto_desc_neto_linea = orden_compra_detalle.Monto_desc_neto_linea;

            this.id_unidad_compra = orden_compra_detalle.Id_unidad_compra;
            this.nom_unidad_compra = orden_compra_detalle.Nom_unidad_compra;

            this.cant_comp = orden_compra_detalle.Cant_comp;
            this.cant_vta = orden_compra_detalle.Cant_vta;

            if (this.cant_comp == 0)
                this.cant_comp = 1;
            if (this.cant_vta == 0)
                this.cant_vta = 1;


            if (activar)
                this.ActivarReactividad();
        }
    }
}
