using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable()]
    [XmlRoot(ElementName = "DOrden_Compra_Detalle")]
    [XmlType(TypeName = "DOrden_Compra_Detalle")]
    public  class EOrden_Compra_Detalle : EDetalle_Comun_Ingreso
    {
        decimal stock;
        decimal venta;


        uint id_orden_compra;
        string codigo_proveedor;



        public EOrden_Compra_Detalle()
        {

        }

        public EOrden_Compra_Detalle(EProducto_CodProv_Entradas_Salidas producto)
        {
            this.cantidad = 0;
            this.stock = producto.Stock_gral;
            this.venta = producto.Sum_salida;

            this.id_unidad_compra = producto.Id_unidad_compra;
            this.nom_unidad_compra = producto.Nom_unidad_compra;
            this.desc_compra = producto.Desc_comp;

            this.cant_comp = producto.Cant_comp;
            this.cant_vta = producto.Cant_vta;

            this.id_producto = producto.Id;

            this.nom_producto = producto.Nom_producto;

            this.codigo_producto = producto.Cod_producto;
            this.cod_prod_proveedor = producto.Cod_prod_proveedor;

            this.precio_neto_unit = producto.Precio_ultima_compra;


            if (this.cant_comp == 0)
                this.cant_comp = 1;
            if (this.cant_vta == 0)
                this.cant_vta = 1;

            this.ActivarReactividad();
            
        }

        public decimal Stock { get => stock; set => stock = value; }
        public decimal Venta { get => venta; set => venta = value; }
        public uint Id_orden_compra { get => id_orden_compra; set => id_orden_compra = value; }
        public string Codigo_proveedor { get => codigo_proveedor; set => codigo_proveedor = value; }

        public static BindingList<EOrden_Compra_Detalle> Convertir(BindingList<EProducto_CodProv_Entradas_Salidas> lista_productos_cod_prov_e_s)
        {
            BindingList<EOrden_Compra_Detalle> lista = new BindingList<EOrden_Compra_Detalle>();

            if(lista_productos_cod_prov_e_s != null)
            {
                foreach(EProducto_CodProv_Entradas_Salidas producto in lista_productos_cod_prov_e_s)
                {
                    lista.Add(new EOrden_Compra_Detalle(producto));
                }
            }

            return lista;
        }

        /*
         * public EDTE_Compra_Detalle(EMae_Productos_DTE_Compra producto_dte_compra, bool activar = true) : base(producto_dte_compra, activar)
        {

        }*/

    }
}
