using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion
{
    /// <summary>
    /// Tipos de combos disponibles
    /// </summary>
    public enum Tabla
    {
        Ninguna, // no buscara en nada

        Bco_Ctas_Ctes,
        Mae_Marcas,
        Mae_Unidades,
        Mae_Monedas,
        Mae_Productos,
        Mae_Clasificaciones,
        Mae_Paises,
        Mae_Regiones,
        Mae_Entidades,
        Mae_Bancos,
        Mae_Comunas,
        Mae_Ciudades,
        Mae_Vendedores,
        Contab_Ctas_Conts,
        Mae_Lista_Precios,
        Mae_Locales,
        Mae_Doc_Tributarios,
        Mae_Accesos,
        Mae_Roles,
        Mae_Conceptos,
        Mae_Cajas,
        DTE_Productos,
        DTE,
        UltimaCompra,
        Rel_Documento_Tributario_Tipo_Traslado_Equipo,
        Nota_Venta,
        DireccionesEmpresaMenosLaPropia,
        Mae_Bodegas,
        DTE_Compra,
        Orden_Compra,
        Ordenes_Word_Press,
        Cotizacion,
    }
    public enum Comun
    {
        Ninguna,

        IngEgre,
        CondVenta,
        CausaAnulacion,
        Ambiente,
        DireccionesEmpresaMenosLaPropia
    }

    public class ParametrosControles
    {

    }
}
