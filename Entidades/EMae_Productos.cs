using Herramientas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable()]
    [XmlRoot(ElementName = "DMae_Productos")]
    public class EMae_Productos : Entidad
    {
        uint id;
        int id_word_press;
        int id_clasificacion_word_press;
        string clasificacion_word_press;
        string link_word_press;
        string link_imagen_word_press;
        string path_local_imagen;
        string cod_producto;
        uint id_clasificacion;
        string nom_producto;
        decimal pmp;
        decimal stock_gral;
        decimal stock_val;
        uint id_marca;
        uint id_unidad_venta;
        string nom_unidad_compra;
        uint id_unidad_compra;
        string nom_unidad_venta;
        decimal pre_vta_iva;
        BoolDB prior_vta = BoolDB.N;
        BoolDB disp_vta = BoolDB.S;
        BoolDB disp_comp = BoolDB.S;
        BoolDB disp_web = BoolDB.N;
        decimal porc_comision;
        decimal precio_vta_bruto;
        decimal margen;
        decimal precio_base;

        decimal ultima_compra;
        DateTime? fecha_ultima_compra;

        List<ERel_Productos_Cod_Bar> cod_barras;
        List<ERel_Productos_Cod_Prov> cod_proveedores;

        public uint Id { get => id; set => id = value; }
        public string Cod_producto { get => cod_producto; set => cod_producto = value; }
        public uint Id_clasificacion { get => id_clasificacion; set => id_clasificacion = value; }
        public string Nom_producto { get => nom_producto; set => nom_producto = value; }
        public decimal Pmp { get => pmp; set => pmp = value; }
        public decimal Stock_gral { get => stock_gral; set => stock_gral = value; }
        public decimal Stock_val { get => stock_val; set => stock_val = value; }
        public uint Id_marca { get => id_marca; set => id_marca = value; }
        public uint Id_unidad_venta { get => id_unidad_venta; set => id_unidad_venta = value; }
        public uint Id_unidad_compra { get => id_unidad_compra; set => id_unidad_compra = value; }
        public decimal Pre_vta_iva { get => pre_vta_iva; set => pre_vta_iva = value; }
        public BoolDB Prior_vta { get => prior_vta; set => prior_vta = value; }
        public BoolDB Disp_vta { get => disp_vta; set => disp_vta = value; }
        public BoolDB Disp_comp { get => disp_comp; set => disp_comp = value; }
        public BoolDB Disp_web { get => disp_web; set => disp_web = value; }
        public decimal Porc_comision { get => porc_comision; set => porc_comision = value; }
        public decimal Precio_base { get => precio_base; set => precio_base = value; }
        public decimal Margen { get => margen; set => margen = value; }
        public List<ERel_Productos_Cod_Bar> Cod_barras { get => cod_barras; set => cod_barras = value; }
        public List<ERel_Productos_Cod_Prov> Cod_proveedores { get => cod_proveedores; set => cod_proveedores = value; }
        public decimal Ultima_compra { get => ultima_compra; set => ultima_compra = value; }
        public DateTime? Fecha_ultima_compra { get => fecha_ultima_compra; set => fecha_ultima_compra = value; }
        public string Fecha_ultima_compra_texto_mostrar {
            get
            {
                if(this.fecha_ultima_compra == null)
                {
                    if(this.id == 0)
                    {
                        return "--";
                    }
                    else
                    {
                        return "Sin compra";
                    }
                }
                else
                {
                    DateTime fecha_date = (DateTime)this.fecha_ultima_compra;
                    return fecha_date.ToString("dd-MM-yyyy");
                }
            }
        }

        public string Nom_unidad_compra { get => nom_unidad_compra; set => nom_unidad_compra = value; }
        public string Nom_unidad_venta { get => nom_unidad_venta; set => nom_unidad_venta = value; }
        public bool Is_stock_gral_entera {
            get
            {
                return Int32.TryParse(Formateador.ToString(this.stock_gral), out int temp_num);
            }
        }

        public int Stock_gral_int {
            get
            {
                if (int.TryParse(Math.Round(this.stock_gral).ToString(), out int stock_general))
                {
                    return stock_general;
                }

                return 0;
            }
        }

        public int Id_word_press { get => id_word_press; set => id_word_press = value; }
        public string Link_word_press { get => link_word_press; set => link_word_press = value; }
        public string Link_imagen_word_press { get => link_imagen_word_press; set => link_imagen_word_press = value; }
        public string Path_local_imagen { get => path_local_imagen; set => path_local_imagen = value; }
        public int Id_clasificacion_word_press { get => id_clasificacion_word_press; set => id_clasificacion_word_press = value; }
        public string Clasificacion_word_press { get => clasificacion_word_press; set => clasificacion_word_press = value; }

        public decimal Precio_vta_bruto()
        {
            EMae_Productos_DTE producto_dte = new EMae_Productos_DTE();
            producto_dte.Precio_base = this.precio_base;
            producto_dte.Margen_base = this.margen;

            if (this.precio_base == 0)
                return 0;

            EDetalle_Comun_Emision det_comun = new EDetalle_Comun_Emision(
                                                   producto_dte,
                                                   Sesion.MiSesion.Empresa.Parametros,
                                                   Sesion.MiSesion.Local.Lista_precios
                                                   );

            return det_comun.Precio_bruto_unit;
        }

        public bool EsBusquedaPorCodProveedor()
        {
            if (string.IsNullOrEmpty(this.Cod_producto))
                return false;

            bool es_busqueda_por_cod_proveedor = this.Cod_producto.Substring(this.Cod_producto.Length - 1, 1) == "*";

            if (es_busqueda_por_cod_proveedor)
                this.Cod_producto = this.Cod_producto.Substring(0, this.Cod_producto.Length - 1);

            return es_busqueda_por_cod_proveedor;
        }
    }
}
